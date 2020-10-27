﻿using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingSender
    {
        [JsonProperty("nombreYApellido")]
        public object NombreYApellido { get; set; }

        [JsonProperty("tipoYNumeroDeDocumento")]
        public object TipoYNumeroDeDocumento { get; set; }

        [JsonProperty("eMail")]
        public object EMail { get; set; }
    }
}
