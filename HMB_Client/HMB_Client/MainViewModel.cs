﻿using System;
using HMB_Client.Core;
using HMB_Client.Interfaces;
using HMB_Client.Models;
using HMB_Client.Presentation;
using System.Collections.ObjectModel;
using System.Linq;

namespace HMB_Client {
    public class MainViewModel : ViewModelBase {
        private readonly IMedicineService medicineService;

        private readonly ICacheService cacheService;
        private MedicineModel selectedMedicine;
        private ObservableCollection<MedicineModel> medicines;
        private ObservableCollection<MedicineTypeModel> medicineTypes;

        #region Properties

        public ObservableCollection<MedicineModel> Medicines {
            get { return medicines; }
            set {
                medicines = value;
                OnPropertyChanged(nameof(Medicines));
            }
        }

        public ObservableCollection<MedicineTypeModel> MedicineTypes {
            get { return medicineTypes; }
            set {
                medicineTypes = value;
                OnPropertyChanged(nameof(MedicineTypes));
            }
        }

        public MedicineModel SelectedMedicine {
            get { return selectedMedicine; }
            set {
                selectedMedicine = value;
                OnPropertyChanged(nameof(SelectedMedicine));
                OnPropertyChanged(nameof(MedicineType));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Code));
            }
        }

        //TODO: refactor this?
        public MedicineTypeModel MedicineType {
            get {
                var type = selectedMedicine?.MedicineTypeId;
                if (type != null) {
                    return cacheService.GetMedicineType(selectedMedicine.MedicineTypeId);
                } else {
                    return cacheService.MedicineTypes.FirstOrDefault();
                }
            }
            set {
                selectedMedicine.MedicineType = value;
                selectedMedicine.MedicineTypeId = value.Id;
                OnPropertyChanged(nameof(MedicineType));
            }
        }

        public string Name {
            get { return selectedMedicine?.Name; }
            set {
                selectedMedicine.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Code {
            get { return selectedMedicine?.Code; }
            set {
                selectedMedicine.Code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        #endregion

        #region Commands

        public RelayCommand AddNewCommand { get; set; }

        public RelayCommand SaveCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        #endregion

        #region ctor

        public MainViewModel(IMedicineService medicineService, ICacheService cacheService) {
            AddNewCommand = new RelayCommand(x => AddNewMedicine(), y => CanAdd());
            SaveCommand = new RelayCommand(x => SaveMedicine(), y => CanSave());
            DeleteCommand = new RelayCommand(x => Delete(x));
            this.medicineService = medicineService;
            this.cacheService = cacheService;
        }

        public void Initialize() {
            Medicines = new ObservableCollection<MedicineModel>(this.medicineService.GetList());
            MedicineTypes = new ObservableCollection<MedicineTypeModel>(cacheService.MedicineTypes);
            AddNewMedicine();
        }

        #endregion

        #region Command handlers

        public bool CanSave() {
            return MedicineType != null
                && Name != null
                && Code != null;
        }

        public void SaveMedicine() {
            var obj = medicineService.Save(SelectedMedicine);
            if (SelectedMedicine.Id == 0) {
                Medicines.Add(obj);
            } else {
                Medicines.Remove(Medicines.First(x => x.Code == obj.Code));
                Medicines.Add(obj);
            }
            AddNewMedicine();
        }

        public void Delete(object med) {
            var medicine = med as MedicineModel;
            if (medicine == null)
                return;
            medicineService.Delete(medicine);
            Medicines.Remove(medicine);
            AddNewMedicine();
        }

        //TODO: We need in base class RaiseCanExecute
        public bool CanAdd() {
            return true;
        }

        public void AddNewMedicine() {
            SelectedMedicine = new MedicineModel() { CreatedDate = DateTime.Today };
        }

        #endregion

        #region Methods


        #endregion

    }
}
