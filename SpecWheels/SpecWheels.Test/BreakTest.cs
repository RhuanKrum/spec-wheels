using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecWheels.Models.Break;

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

            Assert.IsNotNull(breakModel);
            //BreakDataAccess breakDataAccess = new BreakDataAccess();
            //breakDataAccess.Create(breakModel);

            //Assert.ThrowsException(breakDataAccess.Create(breakModel));
        }
    }
}
