using HMB_Client.Core;
using HMB_Client.Interfaces;
using HMB_Client.Models;
using HMB_Client.Presentation;
using HMB_Client.Repositories;
using HMB_Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Unity;

namespace HMB_Client
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;
        private string _code;
        private readonly IMedicineService _medicineService;
        private ObservableCollection<Medicine> _medicines;

        public ObservableCollection<Medicine> Medicines
        {
            get { return _medicines; }
            set
            {
                _medicines = value;
                OnPropertyChanged(nameof(Medicines));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        public RelayCommand AddCommand { get; set; }

        public MainViewModel(IMedicineService medicineService)
        {
            AddCommand = new RelayCommand(x => AddMedicine(), y => CanAdd());
            _medicineService = medicineService;
            Medicines = new ObservableCollection<Medicine>(_medicineService.GetListMedicine());
        }

        public void AddMedicine()
        {
            _medicineService.Save(new Medicine() { Code = Code, Name = Name });
            Medicines = new ObservableCollection<Medicine>(_medicineService.GetListMedicine());
        }

        //TODO: We need in base class RaiseCanExecute
        public bool CanAdd()
        {
            return true;
        }
    }
}
