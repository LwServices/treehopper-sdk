﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

namespace Treehopper.Libraries.Sensors.Inertial
{
    /// <summary>
    ///     A simple filter for fusing accelerometer and gyroscope data together to determine roll and pitch.
    /// </summary>
    public class ComplementaryFilter : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        ///     Delegate of the callback function to be invoked when the filter is updated
        /// </summary>
        /// <param name="sender">The filter that called this function</param>
        /// <param name="e">An empty EventArgs object</param>
        public delegate void FilterUpdateEventHandler(object sender, EventArgs e);

        private readonly IAccelerometer accel;
        private readonly Poller<IAccelerometer> accelPoller;
        private readonly IGyroscope gyro;
        private readonly Poller<IAccelerometer> gyroPoller;

        private readonly Stopwatch sw = new Stopwatch();

        private Vector3 Xaxis = new Vector3(1, 0, 0);
        private Vector3 Yaxis = new Vector3(0, 1, 0);
        private Vector3 Zaxis = new Vector3(0, 0, 1);

        /// <summary>
        ///     Construct a new Complementary filter with the specified accelerometer and gyroscope (which is often the same IC)
        /// </summary>
        /// <param name="accelerometer">The accelerometer to use</param>
        /// <param name="gyroscope">The gyroscope to use</param>
        /// <param name="samplePeriodMs">The sample period to poll these devices at</param>
        /// <param name="useHighResolutionTimer">Whether to use an accurate (but CPU-hungry) timer</param>
        public ComplementaryFilter(IAccelerometer accelerometer, IGyroscope gyroscope, int samplePeriodMs = 10,
            bool useHighResolutionTimer = false)
        {
            //RollQuaternion = new Quaternion(Xaxis, 0);
            //PitchQuaternion = new Quaternion(Yaxis, 0);

            accel = accelerometer;
            gyro = gyroscope;

            accelPoller = new Poller<IAccelerometer>(accelerometer, samplePeriodMs, useHighResolutionTimer);
            accelPoller.OnNewSensorValue += PollerEvent;
            if (accelerometer != gyroscope) // if we have two different sensors
            {
                gyroPoller = new Poller<IAccelerometer>(accelerometer, samplePeriodMs, useHighResolutionTimer);
                gyroPoller.OnNewSensorValue += PollerEvent;
            }
        }

        /// <summary>
        ///     The current calculated pitch
        /// </summary>
        public double Pitch { get; private set; }

        /// <summary>
        ///     The current calculated roll
        /// </summary>
        public double Roll { get; private set; }

        /// <summary>
        ///     The yaw reported by the gyroscope. This value will drift, as the accelerometer cannot correct for it
        /// </summary>
        public double Yaw { get; private set; }

        /// <summary>
        ///     Shut down the polling loop and dispose of this filter
        /// </summary>
        public void Dispose()
        {
            accelPoller.Dispose();
            if (gyroPoller != null)
                gyroPoller.Dispose();
        }

        /// <summary>
        ///     Fires whenever a property has been updated
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void PollerEvent(object sender, EventArgs e)
        {
            update();
        }

        /// <summary>
        ///     Fires after the filter update function has executed
        /// </summary>
        public event FilterUpdateEventHandler FilterUpdate;

        //public Quaternion RollQuaternion { get; private set; }
        //public Quaternion PitchQuaternion { get; private set; }
        //public Quaternion YawQuaternion { get; private set; } = new Quaternion();

        //public Quaternion Transform { get; private set; } = new Quaternion();

        private void update()
        {
            sw.Stop();
            var dt = sw.Elapsed.TotalSeconds;
            sw.Restart();

            double pitchAcc, rollAcc;

            var accelContrib = 0.01;
            var gyroContrib = 1 - accelContrib;

            // SCALAR IMPLEMENTATION

            // Integrate the gyroscope data -> int(angularSpeed) = angle
            Roll += gyro.Gyroscope.X * dt;
            Pitch += gyro.Gyroscope.Y * dt;
            Yaw += gyro.Gyroscope.Z * dt;

            // Turning around the Y axis results in a vector on the X-axis
            rollAcc = Math.Atan2(-accel.Accelerometer.Y, -accel.Accelerometer.Z) * 180.0 / Math.PI;
            Roll = Roll * gyroContrib + rollAcc * accelContrib;

            // Turning around the X axis results in a vector on the Y-axis
            pitchAcc = Math.Atan2(accel.Accelerometer.X,
                           Math.Sqrt(accel.Accelerometer.Y * accel.Accelerometer.Y +
                                     accel.Accelerometer.Z * accel.Accelerometer.Z)) * 180.0 / Math.PI;
            Pitch = Pitch * gyroContrib + pitchAcc * accelContrib;

            //// quaternion implementation
            //RollQuaternion = Quaternion.Multiply(RollQuaternion, new Quaternion(Xaxis, (float)(gyro.Gyroscope.X * dt)));
            //PitchQuaternion = Quaternion.Multiply(PitchQuaternion, new Quaternion(Yaxis, (float)(gyro.Gyroscope.Y * dt)));

            //Roll = RollQuaternion.Angle;
            //if (RollQuaternion.Axis.X == -1)
            //    Roll = -Roll;

            //Pitch = PitchQuaternion.Angle;
            //if (PitchQuaternion.Axis.Y == -1)
            //    Pitch = -Pitch;

            //Transform = Quaternion.Multiply(new Quaternion(Xaxis, (float)Roll), new Quaternion(Yaxis, (float)Pitch));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pitch"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Roll"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Yaw"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Matrix"));
            FilterUpdate?.Invoke(this, new EventArgs());
        }
    }
}