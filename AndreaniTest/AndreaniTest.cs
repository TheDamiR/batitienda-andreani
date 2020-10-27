using Andreani;
using Andreani.Models.Shipping.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AndreaniTest
{
    [TestClass]
    public class AndreaniTest
    {
        [TestMethod]
        public void CanDoLogin()
        {
            var connector = new AndreaniConnector("test", "test");

            var result = connector.GetToken();

            // TODO: no pasa (rejected by policy. (from client))
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanCalcShippingFee()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.CalcShippingFee(new ShippingFeeParameters 
            { 
                PostalCodeDestination = 1400,
                CodeContract = "400006711",
                CodeCustomer = "CL0003750",
                BranchOfficeOrigin = "BAR",
                DeclaredAmount = 1500,
                Kilos = 1.5,
                Volume = 200
            });

            Assert.AreEqual(1500.00, result.ChargeableWeight);
        }

        [TestMethod]
        public void CanSearchShipping()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.SearchShipping(new ShippingParameters
            {
                ProductId = "00001235",
                RecipientDocumentNumber = "11222333",
                CodeContract = "400006711",
                CodeCustomer = "CL0003750"
            });

            // TODO: no pasa (token invalido)
            Assert.IsTrue(result.Envios?.Count > 0);
        }

        [TestMethod]
        public void CanGetSingleShipping()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.GetShipping("W00000000327001"); //numero de andreani

            // TODO: no pasa (token invalido)
            Assert.IsNotNull(result.NumeroDeTracking);
        }

        [TestMethod]
        public void CanGetProvinces()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.GetProvinces();

            Assert.IsTrue(result.Provinces?.Count > 0);
        }

        [TestMethod]
        public void CanGetBranchOffices()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.GetBranchOffices();

            Assert.IsTrue(result.BranchOffices?.Count > 0);
        }
    }
}
