using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecWheels.Models.Engine;
using System.Collections.Generic;

namespace SpecWheels.Test
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void CreateTest()
        {
            EngineModel engineModel = new EngineModel();
            engineModel.Brand = "Brembo";
            engineModel.Name = "Brembo";
            engineModel.HorsePower = "400";

            EngineDataAccess engineDataAccess = new EngineDataAccess();
            engineDataAccess.Create(engineModel);

            Assert.IsNotNull(engineModel);
        }

        [TestMethod]
        public void ListTest()
        {
            EngineDataAccess engineDataAccess = new EngineDataAccess();
            List<EngineModel> engineList = engineDataAccess.List();

            Assert.IsTrue(engineList.Count > 0);
        }

        [TestMethod]
        public void EditTest()
        {
            EngineDataAccess engineDataAccess = new EngineDataAccess();
            List<EngineModel> breakList = engineDataAccess.List();

            // This method will be executed after the CreateTest, so items should exist
            if (breakList == null || breakList.Count == 0)
            {
                Assert.Fail();
            }

            string newName = "New Name";

            EngineModel model = breakList[0];
            model.Name = newName;

            engineDataAccess.Update(model);

            model = engineDataAccess.Read(model.Id);

            Assert.AreEqual(newName, model.Name);
        }

        [TestMethod]
        public void DeleteTest()
        {
            EngineDataAccess engineDataAccess = new EngineDataAccess();
            List<EngineModel> breakList = engineDataAccess.List();

            // This method will be executed after the CreateTest, so items should exist
            if (breakList == null || breakList.Count == 0)
            {
                Assert.Fail();
            }

            EngineModel model = breakList[0];

            engineDataAccess.Delete(model.Id);

            model = engineDataAccess.Read(model.Id);

            Assert.IsNull(model);
        }

    }
}
