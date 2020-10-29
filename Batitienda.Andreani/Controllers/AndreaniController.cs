using Batitienda.Andreani.Models;
using Andreani;
using Andreani.Models.Shipping.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Batitienda.Andreani.Controllers
{
    public class AndreaniController : Controller
    {
        private readonly AndreaniConnector andreani;
        private readonly ILogger<AndreaniController> _logger;

        public AndreaniController(ILogger<AndreaniController> logger)
        {
            andreani = new AndreaniConnector("test", "test", true);
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Label(string andreaniNumber)
        {
            var result = andreani.GetLabelFromOrder(andreaniNumber);

            if (result == null) 
            {
                return Json(andreani.GetOrderException());
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult RateShipment(long productId, int postalCode)
        {
            var item = new Product().GetProduct(productId);

            var result = andreani.CalcShippingFee(new ShippingFeeParameters 
            { 
                PostalCodeDestination = postalCode,
                CodeCustomer = "CL0003750",
                CodeContract = "400006709",
                Width = item.Width,
                Height = item.Height,
                Weight = item.Weight,
                Length = item.Length,
                DeclaredAmount = item.Amount
            });

            if (result == null)
            {
                return Json(andreani.GetShippingException());
            }

            return Json(result);
        }
    }
}
