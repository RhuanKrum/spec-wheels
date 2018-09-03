using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecWheels.Models.Break;
using System.Collections.Generic;

namespace SpecWheels.Test
{
    [TestClass]
    public class BreakTest
    {
        [TestMethod]
        public void CreateTest()
        {
            BreakModel breakModel = new BreakModel();
            breakModel.Brand = "Brembo";
            breakModel.Name = "Brembo";
            breakModel.Size = "400 mm";
            breakModel.Type = "Racing";

            BreakDataAccess breakDataAccess = new BreakDataAccess();
            breakDataAccess.Create(breakModel);

            Assert.IsNotNull(breakModel);
        }

        [TestMethod]
        public void ListTest()
        {
            BreakDataAccess breakDataAccess = new BreakDataAccess();
            List<BreakModel> breakList = breakDataAccess.List();

            Assert.IsTrue(breakList.Count > 0);
        }

        [TestMethod]
        public void EditTest()
        {
            BreakDataAccess breakDataAccess = new BreakDataAccess();
            List<BreakModel> breakList = breakDataAccess.List();

            // This method will be executed after the CreateTest, so items should exist
            if (breakList == null || breakList.Count == 0)
            {
                Assert.Fail();
            }

            string newName = "New Name";

            BreakModel model = breakList[0];
            model.Name = newName;

            breakDataAccess.Update(model);

            model = breakDataAccess.Read(model.Id);

            Assert.AreEqual(newName, model.Name);
        }

        [TestMethod]
        public void DeleteTest()
        {
            BreakDataAccess breakDataAccess = new BreakDataAccess();
            List<BreakModel> breakList = breakDataAccess.List();

            // This method will be executed after the CreateTest, so items should exist
            if (breakList == null || breakList.Count == 0)
            {
                Assert.Fail();
            }

            BreakModel model = breakList[0];

            breakDataAccess.Delete(model.Id);

            model = breakDataAccess.Read(model.Id);

            Assert.IsNull(model);
        }

    }
}
