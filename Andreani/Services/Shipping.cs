using Andreani.Clients;
using Andreani.Models.Shipping;
using Andreani.Models.Shipping.Parameters;
using System.Web;
using System.Collections.Generic;

namespace Andreani.Services
{
    public class Shipping : Service
    {
        public Shipping(string endpoint, string token) : base(endpoint)
        {
            var headers = new Dictionary<string, string>()
            {
                { "x-authorization-token", token }
            };


            Client = new RestClient(endpoint, headers);
        }

        public ShippingFeeResponse ShippingFee(ShippingFeeParameters data)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrWhiteSpace(data.Country))
                query.Add("pais", data.Country);

            if (data.PostalCodeDestination.HasValue)
                query.Add("cpDestino", data.PostalCodeDestination.ToString());

            if (!string.IsNullOrWhiteSpace(data.CodeContract))
                query.Add("contrato", data.CodeContract);

            if (!string.IsNullOrWhiteSpace(data.CodeCustomer))
                query.Add("cliente", data.CodeCustomer);

            if (!string.IsNullOrWhiteSpace(data.BranchOfficeOrigin))
                query.Add("sucursalOrigen", data.BranchOfficeOrigin);

            if (data.Length.HasValue)
                query.Add("bultos[0][largoCm]", data.Length.ToString());

            if (data.Width.HasValue)
                query.Add("bultos[0][anchoCm]", data.Width.ToString());

            if (data.High.HasValue)
                query.Add("bultos[0][altoCm]", data.High.ToString());

            if (data.Volume.HasValue)
                query.Add("bultos[0][volumen]", data.Volume.ToString());

            if (data.Kilos.HasValue)
                query.Add("bultos[0][kilos]", data.Kilos.ToString());

            if (data.ChargeableWeight.HasValue)
                query.Add("bultos[0][pesoAforado]", data.ChargeableWeight.ToString());

            if (data.DeclaredAmount.HasValue)
                query.Add("bultos[0][valorDeclarado]", data.DeclaredAmount.ToString());

            if (!string.IsNullOrWhiteSpace(data.Category))
                query.Add("bultos[0][categoria]", data.Category);

            var response = new ShippingFeeResponse();
            var result = Client.Get("/v1/tarifas", "?" + query.ToString());

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingFeeResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingSingleResponse GetShipping(string number)
        {
            var response = new ShippingSingleResponse();
            var result = Client.Get("/v1/envios/", number);

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingSingleResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingListResponse SearchShipping(ShippingParameters data)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrWhiteSpace(data.CodeCustomer))
                query.Add("codigoCliente", data.CodeCustomer);

            if (!string.IsNullOrWhiteSpace(data.ProductId))
                query.Add("idDeProducto", data.ProductId);

            if (!string.IsNullOrWhiteSpace(data.RecipientDocumentNumber))
                query.Add("numeroDeDocumentoDestinatario", data.RecipientDocumentNumber);

            if (data.CreationDateSince.HasValue)
                query.Add("fechaCreacionDesde", data.CreationDateSince.Value.ToString("yyyyMMddTHH:mm:ss"));

            if (data.CreationDateUntil.HasValue)
                query.Add("fechaCreacionHasta", data.CreationDateUntil.Value.ToString("yyyyMMddTHH:mm:ss"));

            if (!string.IsNullOrWhiteSpace(data.CodeContract))
                query.Add("contrato", data.CodeContract);

            query.Add("limit", data.Limit.ToString());

            var response = new ShippingListResponse();
            var result = Client.Get("/v1/envios", "?" + query.ToString());

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingListResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
