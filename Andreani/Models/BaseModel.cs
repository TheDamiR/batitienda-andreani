using Newtonsoft.Json;

namespace Andreani.Models
{
    public class BaseModel
    {
        public T ToObject<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
