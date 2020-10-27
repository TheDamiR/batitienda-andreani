using System;

namespace Andreani.Models.Shipping.Parameters
{
    public class ShippingParameters
    {
        public string CodeCustomer { get; set; }
        public string CodeContract { get; set; }
        public string ProductId { get; set; }
        public string RecipientDocumentNumber { get; set; }
        public DateTime? CreationDateSince { get; set; }
        public DateTime? CreationDateUntil { get; set; }
        public int Limit { get; set; }

        public ShippingParameters()
        {
            Limit = 10;
        }
    }
}
