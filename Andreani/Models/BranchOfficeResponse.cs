using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models
{
    public class ComponentesDeDireccion
    {
        public string meta { get; set; }
        public string contenido { get; set; }
    }

    public class Direccion
    {
        public string localidad { get; set; }
        public string region { get; set; }
        public string pais { get; set; }
        public string codigoPostal { get; set; }
        public IList<ComponentesDeDireccion> componentesDeDireccion { get; set; }
    }

    public class Telefono
    {
        public int tipo { get; set; }
        public string numero { get; set; }
    }

    public class Geocoordenadas
    {
        public int elevacion { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }

    public class DatosAdicionale
    {
        public string meta { get; set; }
        public string contenido { get; set; }
    }

    public class BranchOffice
    {
        public string id { get; set; }
        public string nomenclatura { get; set; }
        public string descripcion { get; set; }
        public string horarioDeAtencion { get; set; }
        public Direccion direccion { get; set; }
        public IList<Telefono> telefonos { get; set; }
        public Geocoordenadas geocoordenadas { get; set; }
        public IList<DatosAdicionale> datosAdicionales { get; set; }
        public string tipo { get; set; }
    }


    public class BranchOfficeResponse : BaseModel
    {
        public IList<BranchOffice> BranchOffices { get; set; }
    }
}
