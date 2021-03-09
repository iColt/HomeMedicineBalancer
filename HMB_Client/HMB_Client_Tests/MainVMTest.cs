using HMB_Client;
using HMB_Client.Interfaces;
using HMB_Client.Models;
using HMB_Client_Tests.Fakes;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HMB_Client_Tests
{
    public class MainVMTest
    {

        MainViewModel _sut;
        private Mock<ICacheService> _cacheServiceMock;
        private Mock<IMedicineService> _medicineServiceMock;

        [SetUp]
        public void Setup()
        {
            //Initialization
            _cacheServiceMock = new Mock<ICacheService>();
            _medicineServiceMock = new Mock<IMedicineService>();

            //Setups
            _cacheServiceMock.Setup(x => x.MedicineTypes).Returns(ModelFakes.GetMedicineTypes);

            _sut = new MainViewModel(_medicineServiceMock.Object, _cacheServiceMock.Object);
        }

        [Test]
        public void Test_Initialize_EmptyDB()
        {
            //Assume
            _medicineServiceMock.Setup(x => x.GetList()).Returns(new List<MedicineModel>());

            //Act
            _sut.Initialize();

            //Assert
            Assert.AreEqual(_sut.MedicineTypes.Count, ModelFakes.GetMedicineTypes().Count);
            Assert.AreEqual(0, _sut.Medicines.Count);
            Assert.AreEqual(0, _sut.SelectedMedicine.Id);

        }

        [Test]
        public void Test_Initialize_ServerReturnsResults()
        {
            //Assume
            _medicineServiceMock.Setup(x => x.GetList()).Returns(ModelFakes.GetMedicines());

            //Act
            _sut.Initialize();

            //Assert
            Assert.AreEqual(_sut.MedicineTypes.Count, ModelFakes.GetMedicineTypes().Count);
            Assert.AreEqual(3, _sut.Medicines.Count);
            Assert.AreEqual(0, _sut.SelectedMedicine.Id);

        }

        [Test]
        public void Test_CanSave_ReturnFalse_UnvalidInput()
        {
            //Assume
            _medicineServiceMock.Setup(x => x.GetList()).Returns(ModelFakes.GetMedicines());
            _sut.Initialize();

            //Act
            var canSave = _sut.SaveCommand.CanExecute(null);

            //Assert
            Assert.IsFalse(canSave);
            Assert.AreEqual(null, _sut.Name);
        }

        [Test]
        public void Test_CanSave_ReturnTrue()
        {
            //Assume
            _medicineServiceMock.Setup(x => x.GetList()).Returns(ModelFakes.GetMedicines());
            _sut.Initialize();
            SetupObjectForSuccesfullSave();

            //Act
            var canSave = _sut.SaveCommand.CanExecute(null);

            //Assert
            Assert.IsTrue(canSave);
            Assert.AreEqual("TestName", _sut.Name);
        }

        [Test]
        public void Test_Save_Successfull()
        {
            //Assume
            _medicineServiceMock.Setup(x => x.GetList()).Returns(ModelFakes.GetMedicines());
            _sut.Initialize();
            SetupObjectForSuccesfullSave();
            _medicineServiceMock.Setup(x => x.Save(It.IsAny<MedicineModel>())).Callback(() => {
                _sut.SelectedMedicine.Id = _sut.Medicines.OrderByDescending(x => x.Id).First().Id + 1;        
            }
            ).Returns(_sut.SelectedMedicine);

            //Act
            _sut.SaveCommand.Execute(null);

            //Assert
            Assert.AreEqual(ModelFakes.GetMedicines().Count + 1, _sut.Medicines.Count);
            Assert.Greater(_sut.Medicines.First(x => x.Name == "TestName").Id, 0);
            Assert.AreEqual(0, _sut.SelectedMedicine.Id);
        }

        [Test]
        public void Test_Save_Unseccsussfull_ServerValidation()
        {
            //Assume
            Assert.Fail("Need to be implemented");
        }

        [Test]
        public void Test_Delete_Successfull()
        {
            bool raised = false;

            //Assume
            _medicineServiceMock.Setup(x => x.GetList()).Returns(ModelFakes.GetMedicines());
            _sut.Initialize();
            SetupObjectForSuccesfullSave();
            _medicineServiceMock.Setup(x => x.Delete(It.IsAny<MedicineModel>())).Callback(() => raised = true);

            //Act
            _sut.DeleteCommand.Execute(_sut.Medicines.First(x => x.Id == 1));

            //Assert
            Assert.IsTrue(raised);
            Assert.AreEqual(ModelFakes.GetMedicines().Count - 1, _sut.Medicines.Count);
            Assert.AreEqual(null, _sut.Medicines.FirstOrDefault(x => x.Id == 1));
            Assert.AreEqual(0, _sut.SelectedMedicine.Id);
        }


        #region Methods

        private void SetupObjectForSuccesfullSave()
        {
            _sut.Name = "TestName";
            _sut.Code = "T_Nm";
            _sut.MedicineType = _sut.MedicineTypes.First();
        }

        #endregion
    }
}
