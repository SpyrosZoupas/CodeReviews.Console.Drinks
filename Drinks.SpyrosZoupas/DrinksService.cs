
using Drinks.SpyrosZoupas.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace Drinks.SpyrosZoupas
{
    public class DrinksService
    {
        RestClient client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        
        public void GetCategories()
        {
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialise = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialise.CategoriesList;

                TableVisualisationEngine.ShowTable(returnedList, "Categories Menu");
            }
        }

        public void GetDrinksByCategory(string category)
        {
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialise = JsonConvert.DeserializeObject<Model.Drinks>(rawResponse);

                List<Drink> returnedList = serialise.DrinksList;

                TableVisualisationEngine.ShowTable(returnedList, "Drinks Menu");
            }
        }
    }
}
