using Newtonsoft.Json;

namespace Drinks.SpyrosZoupas.Model
{
    public class DrinkDetailObject
    {
        [JsonProperty("drinks")]
        public List<DrinkDetail> DrinkDetailList { get; set; }
    }
}