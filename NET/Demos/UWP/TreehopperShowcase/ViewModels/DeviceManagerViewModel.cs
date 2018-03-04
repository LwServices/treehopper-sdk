﻿using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Treehopper;
using Treehopper.Utilities;
using Treehopper.Uwp;

namespace TreehopperShowcase.ViewModels
{
    public class DeviceManagerViewModel : Mvvm.ViewModelBase
    {
        public DeviceManagerViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                SelectedBoard = Boards[1];
            }
        }

        public ObservableCollection<TreehopperUsb> Boards => ConnectionService.Instance.Boards;

        string newName;
        public string NewName {
            get {
                return newName;
            } set {
                Set(ref newName, value);
            }
        }

        TreehopperUsb selectedBoard;
        public TreehopperUsb SelectedBoard {
            get {
                return selectedBoard;
            } set {
                if (selectedBoard != null)
                    selectedBoard.Disconnect();
                Set(ref selectedBoard, value);
                if(selectedBoard != null)
                {
                    selectedBoard.ConnectAsync().ConfigureAwait(false);
                    NewName = selectedBoard.Name;
                    RaisePropertyChanged("UpdateName");
                    RaisePropertyChanged("GenerateSerial");
                    RaisePropertyChanged("UpdateFirmwareFromEmbeddedImage");
                }
                
            }
        }

        private RelayCommand generateSerial;

        public RelayCommand GenerateSerial
        {
            get
            {
                return generateSerial
                    ?? (generateSerial = new RelayCommand(
                    async () =>
                    {
                        await SelectedBoard.UpdateSerialNumberAsync(Utility.RandomString(8));
                        SelectedBoard.Reboot();
                    },
                    () => SelectedBoard != null));
            }
        }

        private RelayCommand updateName;

        public RelayCommand UpdateName
        {
            get
            {
                return updateName
                    ?? (updateName = new RelayCommand(
                    async () =>
                    {
                        await SelectedBoard.UpdateDeviceNameAsync(newName);
                        await SelectedBoard.UpdateSerialNumberAsync(Utility.RandomString(8));
                        SelectedBoard.Reboot();
                    },
                    () => SelectedBoard != null));
            }
        }
    }
}
