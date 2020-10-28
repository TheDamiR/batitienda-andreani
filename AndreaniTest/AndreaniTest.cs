using Andreani;
using Andreani.Models;
using Andreani.Models.Orders;
using Andreani.Models.Orders.Parameters;
using Andreani.Models.Shipping.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AndreaniTest
{
    [TestClass]
    public class AndreaniTest
    {
        [TestMethod]
        public void CanDoLogin()
        {
            var connector = new AndreaniConnector("eCommerce_Integra", "passw0rd");

            var result = connector.GetToken();

            // TODO: no pasa (rejected by policy. (from client))
            Assert.IsNotNull(result, connector.GetLoginException()?.Detail);
        }

        [TestMethod]
        public void CanCreateOrder() {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz");

            var result = connector.CreateOrder(new OrderCreateParameters
            {
                CodeContract = "400006709",
                Origin = new OrderOrigin
                {
                    Postal = new OrderPostal
                    {
                        PostalCode = "3378",
                        Street = "Av Falsa",
                        Number = "380",
                        Location = "Puerto Esperanza",
                        Country = "Argentina",
                    }
                },
                Destination = new OrderDestination
                {
                    Postal = new OrderPostal
                    {
                        PostalCode = "1292",
                        Street = "Macacha Guemes",
                        Number = "28",
                        Location = "C.A.B.A.",
                        Region = "AR-B",
                        Country = "Argentina",
                        ComponentsAddress = new List<AdditionalData>()
                        {
                            new AdditionalData
                            {
                                Meta = "piso",
                                Content = "2"
                            },
                            new AdditionalData
                            {
                                Meta = "departamento",
                                Content = "B"
                            }
                        }
                    }
                },
                Sender = new OrderSender
                {
                    FullName = "Alberto Lopez",
                    EmailAddress = "remitente@andreani.com",
                    DocumentType = "DNI",
                    DocumentNumber = "33111222",
                    Phones = new List<Phone>()
                    {
                        new Phone
                        {
                            Type = 1,
                            Number = "113332244"
                        }
                    }
                },
                Recipients = new List<OrderRecipient>()
                {
                    new OrderRecipient
                    {
                        FullName = "Juana Gonzalez",
                        EmailAddress = "destinatario@andreani.com",
                        DocumentType = "DNI",
                        DocumentNumber = "33999888",
                        Phones = new List<Phone>()
                        {
                            new Phone
                            {
                                Type = 1,
                                Number = "1112345678"
                            }
                        }
                    },
                    new OrderRecipient
                    {
                        FullName = "Jose Gonzalez",
                        EmailAddress = "alter@andreani.com",
                        DocumentType = "DNI",
                        DocumentNumber = "33922288",
                        Phones = new List<Phone>()
                        {
                            new Phone
                            {
                                Type = 1,
                                Number = "153111231"
                            }
                        }
                    }
                },
                Packages = new List<OrderCreatePackage>()
                {
                    new OrderCreatePackage
                    {
                        Kilos = 2,
                        Length = 10,
                        Height = 50,
                        Width = 10,
                        Volume = 5000,
                        DeclaredAmountWithTaxes = 1452,
                        DeclaredAmountWithoutTaxes = 1200,
                        References = new List<AdditionalData>()
                        {
                            new AdditionalData
                            {
                                Meta = "detalle",
                                Content = "Secador de pelo"
                            },
                            new AdditionalData
                            {
                                Meta = "idCliente",
                                Content = "10000"
                            }
                        }
                    }
                }
            });

            Assert.IsNotNull(result.Status, connector.GetOrderException()?.Detail);
        }

        [TestMethod]
        public void CanGetOrder()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz");

            var result = connector.GetOrder("360000000036820");

            Assert.IsNotNull(result.Status, connector.GetOrderException()?.Detail);
        }

        [TestMethod]
        public void CanGetLabelFromOrder()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz");

            var result = connector.GetLabelFromOrder("360000000036820");

            Assert.IsTrue(!string.IsNullOrWhiteSpace(result), connector.GetOrderException()?.Detail);
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

            Assert.AreEqual(1500.00, result.ChargeableWeight, connector.GetShippingException()?.Detail);
        }

        [TestMethod]
        public void CanShippingTracking()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.ShippingTracking(new ShippingTrackingParameters
            {
                ProductId = "00001235",
                RecipientDocumentNumber = "11222333",
                CodeContract = "400006711",
                CodeCustomer = "CL0003750"
            });

            Assert.IsTrue(result.Shipping?.Count > 0, connector.GetShippingException()?.Detail);
        }

        [TestMethod]
        public void CanGetShippingTraces()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.GetShippingTraces("360000036137650");

            Assert.IsTrue(result.Events?.Count > 0, connector.GetShippingException()?.Detail);
        }

        [TestMethod]
        public void CanGetShipping()
        {
            var connector = new AndreaniConnector("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz"); // only for test

            var result = connector.GetShipping("360000036137650");

            Assert.IsNotNull(result.NumberTracking, connector.GetShippingException()?.Detail);
        }

        [TestMethod]
        public void CanGetProvinces()
        {
            var connector = new AndreaniConnector(); // no requiere token

            var result = connector.GetProvinces();

            Assert.IsTrue(result.Provinces?.Count > 0, connector.GetProvinceException()?.Detail);
        }

        [TestMethod]
        public void CanGetBranchOffices()
        {
            var connector = new AndreaniConnector(); // no requiere token

            var result = connector.GetBranchOffices();

            Assert.IsTrue(result.BranchOffices?.Count > 0, connector.GetBranchOfficeException()?.Detail);
        }
    }
}
