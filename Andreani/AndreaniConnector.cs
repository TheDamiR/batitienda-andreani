using System;
using Andreani.Models;
using Andreani.Services;

namespace Andreani
{
    public class AndreaniConnector
    {
        #region Constants

        public const string VERSION = "0.0.1";

        private const string REQUEST_HOST_PRODUCTION = "https://api.andreani.com";
        private const string REQUEST_HOST_DEVELOPMENT = "https://api.qa.andreani.com";

        #endregion

        private Provinces Provinces;
        private BranchOffices BranchOffices;

        public AndreaniConnector(string accessToken, bool isDevMode = true)
        {
            var endpoint = isDevMode ? REQUEST_HOST_DEVELOPMENT : REQUEST_HOST_PRODUCTION;
            var token = accessToken;

            Provinces = new Provinces(endpoint, token);
            BranchOffices = new BranchOffices(endpoint, token);
        }

        public ProvinceResponse GetProvinces()
        {
            return Provinces.Execute();
        }

        public BranchOfficeResponse GetBranchOffices()
        {
            return BranchOffices.Execute();
        }
    }
}
