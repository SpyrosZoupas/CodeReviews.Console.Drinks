
using Drinks.SpyrosZoupas.Model;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.SpyrosZoupas
{
    public class DrinksService
    {
        public void GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
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
    }
}
