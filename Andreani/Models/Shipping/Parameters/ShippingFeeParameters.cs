namespace Andreani.Models.Shipping.Parameters
{
    public class ShippingFeeParameters
    {
        public string Country { get; set; }
        public int? PostalCodeDestination { get; set; }
        public string CodeContract { get; set; }
        public string CodeCustomer { get; set; }
        public string BranchOfficeOrigin { get; set; }
        public double? Width { get; set; } //cm.
        public double? Length { get; set; } //cm.
        public double? Height { get; set; } //cm.
        public double? Volume { get; set; } //cm3.
        public double? Weight { get; set; } //kg.
        public double? ChargeableWeight { get; set; }
        public double? DeclaredAmount { get; set; }
        public string Category { get; set; }
    }
}
