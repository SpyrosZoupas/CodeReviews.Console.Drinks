
namespace Drinks.SpyrosZoupas
{
    public class UserInput
    {
        private readonly DrinksService _drinksService;

        public UserInput(DrinksService drinksService)
        {
            _drinksService = drinksService;
        }

        public void GetCategoriesInput()
        {
            _drinksService.GetCategories();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category!");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            _drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by pressing 0:");

            string drink = Console.ReadLine();

            if (drink == "0")
                GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink!");
                drink = Console.ReadLine();
            }
        }
    }
}
