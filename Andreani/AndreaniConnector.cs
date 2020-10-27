using Andreani.Services;
using Andreani.Models;
using Andreani.Models.Shipping;
using Andreani.Models.Shipping.Parameters;

namespace Andreani
{
    public class AndreaniConnector
    {
        #region Constants

        public const string VERSION = "0.0.2";

        private const string REQUEST_HOST_PRODUCTION = "https://api.andreani.com";
        private const string REQUEST_HOST_DEVELOPMENT = "https://api.qa.andreani.com";

        #endregion

        private string CodeCustomer = "CL0003750";
        private string CodeShipmentsToBranchOffice = "400006711";
        private string CodeStandardShipmentsToHome = "400006709";
        private string CodeUrgentShipmentsToHome = "400006710";

        private string Endpoint;
        private string Token;

        private Provinces Provinces;
        private BranchOffices BranchOffices;
        private Shipping Shipping;
        private Login Login;

        public AndreaniConnector(string accessToken, bool isDevMode = true)
        {
            Endpoint = isDevMode ? REQUEST_HOST_DEVELOPMENT : REQUEST_HOST_PRODUCTION;
            Token = accessToken;

            Init();
        }

        public AndreaniConnector(string username, string password, bool isDevMode = true)
        {
            Endpoint = isDevMode ? REQUEST_HOST_DEVELOPMENT : REQUEST_HOST_PRODUCTION;

            Login = new Login(Endpoint, username, password);

            Init();
        }

        private void Init()
        {
            Provinces = new Provinces(Endpoint);
            BranchOffices = new BranchOffices(Endpoint);
            Shipping = new Shipping(Endpoint, Token);
        }

        #region Exceptions
        public ErrorResponse GetLoginException()
        {
            return Login.GetResponseException();
        }

        public ErrorResponse GetProvinceException()
        {
            return Provinces.GetResponseException();
        }

        public ErrorResponse GetBranchOfficeException()
        {
            return BranchOffices.GetResponseException();
        }
        #endregion

        public string GetToken()
        {
            return Login.Execute();
        }

        public ProvinceResponse GetProvinces()
        {
            return Provinces.Get();
        }

        public BranchOfficeResponse GetBranchOffices()
        {
            return BranchOffices.Get();
        }
        
        public ShippingFeeResponse CalcShippingFee(ShippingFeeParameters data)
        {
            return Shipping.ShippingFee(data);
        }

        public ShippingListResponse SearchShipping(ShippingParameters data)
        {
            return Shipping.SearchShipping(data);
        }

        public ShippingSingleResponse GetShipping(string number)
        {
            return Shipping.GetShipping(number);
        }
    }
}
