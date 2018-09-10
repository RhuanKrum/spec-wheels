using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecWheels.Models.Tire;
using System.Collections.Generic;

namespace SpecWheels.Test
{
    [TestClass]
    public class TireTest
    {
        [TestMethod]
        public void CreateTest()
        {
            TireModel tireModel = new TireModel();
            tireModel.Brand = "Brembo";
            tireModel.Name = "Brembo";
            tireModel.Size = "400 mm";
           

            TireDataAccess tireDataAccess = new TireDataAccess();
            tireDataAccess.Create(tireModel);

            Assert.IsNotNull(tireModel);
        }

        [TestMethod]
        public void ListTest()
        {
            TireDataAccess tireDataAccess = new TireDataAccess();
            List<TireModel> tireList = tireDataAccess.List();

            Assert.IsTrue(tireList.Count > 0);
        }

        [TestMethod]
        public void EditTest()
        {
            TireDataAccess tireDataAccess = new TireDataAccess();
            List<TireModel> tireList = tireDataAccess.List();

            // This method will be executed after the CreateTest, so items should exist
            if (tireList == null || tireList.Count == 0)
            {
                Assert.Fail();
            }

            string newName = "New Name";

            TireModel model = tireList[0];
            model.Name = newName;

            tireDataAccess.Update(model);

            model = tireDataAccess.Read(model.Id);

            Assert.AreEqual(newName, model.Name);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TireDataAccess tireDataAccess = new TireDataAccess();
            List<TireModel> tireList = tireDataAccess.List();

            // This method will be executed after the CreateTest, so items should exist
            if (tireList == null || tireList.Count == 0)
            {
                Assert.Fail();
            }

            TireModel model = tireList[0];

            tireDataAccess.Delete(model.Id);

            model = tireDataAccess.Read(model.Id);

            Assert.IsNull(model);
        }

    }
}
