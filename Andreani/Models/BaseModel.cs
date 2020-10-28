using Newtonsoft.Json;

namespace Andreani.Models
{
    public class BaseModel
    {
        public T ToObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string ToJson(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
