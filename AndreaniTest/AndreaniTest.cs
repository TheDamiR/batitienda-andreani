using Andreani;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AndreaniTest
{
    [TestClass]
    public class AndreaniTest
    {
        [TestMethod]
        public void CanGetProvinces()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz");

            var result = connector.GetProvinces();

            Assert.IsTrue(result.Provinces.Count > 0);
        }

        [TestMethod]
        public void CanGetBranchOffices()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz");

            var result = connector.GetBranchOffices();

            Assert.IsTrue(result.BranchOffices.Count > 0);
        }
    }
}
