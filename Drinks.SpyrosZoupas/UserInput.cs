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
            var categories = _drinksService.GetCategories();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category!");
                category = Console.ReadLine();
            }

            if (!categories.Any(x => x.strCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            var drinks = _drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by pressing 0:");

            string drink = Console.ReadLine();

            if (drink == "0")
                GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink!");
                drink = Console.ReadLine();
            }

            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }

            _drinksService.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu.");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }
    }
}
