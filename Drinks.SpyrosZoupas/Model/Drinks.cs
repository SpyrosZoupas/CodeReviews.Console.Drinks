using Newtonsoft.Json;

namespace Drinks.SpyrosZoupas.Model
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; }
    }
}
