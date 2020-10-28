using Andreani.Services;
using Andreani.Models;
using Andreani.Models.Shipping;
using Andreani.Models.Shipping.Parameters;
using Andreani.Models.Orders;
using Andreani.Models.Orders.Parameters;

namespace Andreani
{
    public class AndreaniConnector
    {
        #region Constants

        public const string VERSION = "0.0.4";

        private const string REQUEST_HOST_PRODUCTION = "https://api.andreani.com";
        private const string REQUEST_HOST_DEVELOPMENT = "https://api.qa.andreani.com";

        #endregion

        private string Endpoint;
        private string Token;

        private Provinces Provinces;
        private BranchOffices BranchOffices;
        private Shipping Shipping;
        private Orders Orders;
        private Login Login;

        public AndreaniConnector(string accessToken = "")
        {
            Endpoint = REQUEST_HOST_DEVELOPMENT;
            Token = accessToken;

            Init();
        }

        public AndreaniConnector(string username, string password, bool isDevMode = true)
        {
            Endpoint = isDevMode ? REQUEST_HOST_DEVELOPMENT : REQUEST_HOST_PRODUCTION;

            Login = new Login(Endpoint, username, password);
            Token = GetToken();

            Init();
        }

        private void Init()
        {
            Provinces = new Provinces(Endpoint);
            BranchOffices = new BranchOffices(Endpoint);
            Shipping = new Shipping(Endpoint, Token);
            Orders = new Orders(Endpoint, Token);
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

        public ErrorResponse GetShippingException()
        {
            return Shipping.GetResponseException();
        }

        public ErrorResponse GetOrderException()
        {
            return Orders.GetResponseException();
        }
        #endregion

        public string GetToken()
        {
            return Login.Get();
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

        public ShippingTracesResponse GetShippingTraces(string number)
        {
            return Shipping.GetShippingTraces(number);
        }

        public ShippingListResponse ShippingTracking(ShippingTrackingParameters data)
        {
            return Shipping.ShippingTracking(data);
        }

        public ShippingResponse GetShipping(string number)
        {
            return Shipping.GetShipping(number);
        }

        public OrderResponse GetOrder(string number)
        {
            return Orders.Get(number);
        }

        public string GetLabelFromOrder(string number)
        {
            return Orders.GetLabel(number);
        }

        public OrderResponse CreateOrder(OrderCreateParameters data)
        {
            return Orders.Create(data);
        }
    }
}
