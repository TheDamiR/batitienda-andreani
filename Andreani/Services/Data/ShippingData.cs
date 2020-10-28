using System.Web;
using System.Collections.Specialized;
using Andreani.Models.Shipping.Parameters;

namespace Andreani.Services.Data
{
    public class ShippingData
    {
        private NameValueCollection Query;

        public ShippingData()
        {
            Query = EmptyQuery();
        }

        private NameValueCollection EmptyQuery()
        {
            return HttpUtility.ParseQueryString(string.Empty);
        }

        private string Result(NameValueCollection query)
        {
            var result = (string)query.ToString().Clone();

            Query = EmptyQuery();

            return "?" + result;
        }

        public string ShippingFee(ShippingFeeParameters data)
        {
            if (!string.IsNullOrWhiteSpace(data.Country))
                Query.Add("pais", data.Country);

            if (data.PostalCodeDestination.HasValue)
                Query.Add("cpDestino", data.PostalCodeDestination.ToString());

            if (!string.IsNullOrWhiteSpace(data.CodeContract))
                Query.Add("contrato", data.CodeContract);

            if (!string.IsNullOrWhiteSpace(data.CodeCustomer))
                Query.Add("cliente", data.CodeCustomer);

            if (!string.IsNullOrWhiteSpace(data.BranchOfficeOrigin))
                Query.Add("sucursalOrigen", data.BranchOfficeOrigin);

            if (data.Length.HasValue)
                Query.Add("bultos[0][largoCm]", data.Length.ToString());

            if (data.Width.HasValue)
                Query.Add("bultos[0][anchoCm]", data.Width.ToString());

            if (data.High.HasValue)
                Query.Add("bultos[0][altoCm]", data.High.ToString());

            if (data.Volume.HasValue)
                Query.Add("bultos[0][volumen]", data.Volume.ToString());

            if (data.Kilos.HasValue)
                Query.Add("bultos[0][kilos]", data.Kilos.ToString());

            if (data.ChargeableWeight.HasValue)
                Query.Add("bultos[0][pesoAforado]", data.ChargeableWeight.ToString());

            if (data.DeclaredAmount.HasValue)
                Query.Add("bultos[0][valorDeclarado]", data.DeclaredAmount.ToString());

            if (!string.IsNullOrWhiteSpace(data.Category))
                Query.Add("bultos[0][categoria]", data.Category);

            return Result(Query);
        }

        public string ShippingTracking(ShippingTrackingParameters data)
        {
            if (!string.IsNullOrWhiteSpace(data.CodeCustomer))
                Query.Add("codigoCliente", data.CodeCustomer);

            if (!string.IsNullOrWhiteSpace(data.ProductId))
                Query.Add("idDeProducto", data.ProductId);

            if (!string.IsNullOrWhiteSpace(data.RecipientDocumentNumber))
                Query.Add("numeroDeDocumentoDestinatario", data.RecipientDocumentNumber);

            if (data.CreationDateSince.HasValue)
                Query.Add("fechaCreacionDesde", data.CreationDateSince.Value.ToString("yyyyMMddTHH:mm:ss"));

            if (data.CreationDateUntil.HasValue)
                Query.Add("fechaCreacionHasta", data.CreationDateUntil.Value.ToString("yyyyMMddTHH:mm:ss"));

            if (!string.IsNullOrWhiteSpace(data.CodeContract))
                Query.Add("contrato", data.CodeContract);

            Query.Add("limit", data.Limit.ToString());

            return Result(Query);
        }
    }
}
