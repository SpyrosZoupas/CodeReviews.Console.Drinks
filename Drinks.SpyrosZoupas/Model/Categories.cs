using Newtonsoft.Json;

namespace Drinks.SpyrosZoupas.Model;

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}
