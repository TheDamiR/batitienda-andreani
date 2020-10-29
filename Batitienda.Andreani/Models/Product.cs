namespace Batitienda.Andreani.Models
{
    public class Product
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public double Amount { get; set; }

        public Product GetProduct(long productId)
        {
            if (productId == 1000)
            {
                return new Product
                {
                    Amount = 1500,
                    Width = 10,
                    Height = 25,
                    Length = 10,
                    Weight = 2,
                };
            }
            else
            {
                return new Product
                {
                    Amount = 500,
                    Width = 5,
                    Height = 12,
                    Length = 16,
                    Weight = 2.7,
                };
            }
        }
    }
}
