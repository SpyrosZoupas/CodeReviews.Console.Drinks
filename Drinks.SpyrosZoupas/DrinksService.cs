using Drinks.SpyrosZoupas.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;

namespace Drinks.SpyrosZoupas
{
    public class DrinksService
    {
        RestClient client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        
        public List<Category> GetCategories()
        {
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> categories = new List<Category>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialise = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialise.CategoriesList;
                TableVisualisationEngine.ShowTable(categories, "Categories Menu");
            }

            return categories;
        }

        public List<Drink> GetDrinksByCategory(string category)
        {
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new List<Drink>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialise = JsonConvert.DeserializeObject<Model.Drinks>(rawResponse);

                drinks = serialise.DrinksList;

                TableVisualisationEngine.ShowTable(drinks, "Drinks Menu");
            }

            return drinks;
        }

        public void GetDrink(string drink)
        {
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialise = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialise.DrinkDetailList;

                DrinkDetail drinkDetail = returnedList[0];

                List<object> prepList = new List<object>();

                string formattedName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("Str"))
                        formattedName = prop.Name.Substring(3);
                    else
                        formattedName = prop.Name;

                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }

                TableVisualisationEngine.ShowTable(prepList, drink);
            }
        }
    }
}
