using HMB_Client.Core;
using HMB_Client.Interfaces;
using HMB_Client.Models;
using HMB_Client.Presentation;
using System;
using System.Collections.ObjectModel;

namespace HMB_Client
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMedicineService medicineService;
        
        private readonly ICacheService cacheService;
        private Medicine selectedMedicine;
        private ObservableCollection<Medicine> medicines;
        private ObservableCollection<MedicineType> medicineTypes;

        public ObservableCollection<Medicine> Medicines
        {
            get { return medicines; }
            set
            {
                medicines = value;
                OnPropertyChanged(nameof(Medicines));
            }
        }

        public ObservableCollection<MedicineType> MedicineTypes
        {
            get { return medicineTypes; }
            set
            {
                medicineTypes = value;
                OnPropertyChanged(nameof(MedicineTypes));
            }
        }

        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                selectedMedicine = value;
                OnPropertyChanged(nameof(SelectedMedicine));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Code));
            }
        }

        public MedicineType MedicineType
        {
            get 
            {
                var type = selectedMedicine?.MedicineType;
                if (type != null) { 
                    return type;
                }
                else
                {
                   return cacheService.GetMedicineType(selectedMedicine.MedicineTypeId);
                }
            }
            set
            {
                selectedMedicine.MedicineType = value;
                selectedMedicine.MedicineTypeId = value.Id;
                OnPropertyChanged(nameof(MedicineType));
            }
        }

        public string Name
        {
            get { return selectedMedicine?.Name; }
            set
            {
                selectedMedicine.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Code
        {
            get { return selectedMedicine?.Code; }
            set
            {
                selectedMedicine.Code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        public RelayCommand AddNewCommand { get; set; }

        public RelayCommand SaveCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public MainViewModel(IMedicineService medicineService, ICacheService cacheService)
        {
            AddNewCommand = new RelayCommand(x => AddNewMedicine(), y => CanAdd());
            SaveCommand = new RelayCommand(x => SaveMedicine(), y => CanSave());
            DeleteCommand = new RelayCommand(x => Delete());
            AddNewMedicine();
            this.medicineService = medicineService;
            Medicines = new ObservableCollection<Medicine>(this.medicineService.GetList());
            MedicineTypes = new ObservableCollection<MedicineType>(cacheService.MedicineTypes);
            this.cacheService = cacheService;
        }

        public void AddNewMedicine()
        {
            SelectedMedicine = new Medicine() { CreatedDate  = DateTime.Today };
        }

        public void SaveMedicine()
        {
            Medicines.Add(medicineService.Save(SelectedMedicine));
            AddNewMedicine();
        }

        public void Delete()
        {
            medicineService.Delete(SelectedMedicine);
            Medicines.Remove(SelectedMedicine);
            AddNewMedicine();
        }

        //TODO: We need in base class RaiseCanExecute
        public bool CanAdd()
        {
            return true;
        }

        public bool CanSave()
        {
            return MedicineType != null; 
        }
    }
}
