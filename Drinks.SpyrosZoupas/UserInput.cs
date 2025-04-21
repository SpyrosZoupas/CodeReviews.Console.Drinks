using Spectre.Console;

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

            string category = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Choose category:[/]")
                    .PageSize(20)
                    .AddChoices(categories.Select(c => c.StrCategory))
                );

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category!");
                category = Console.ReadLine();
            }

            if (!categories.Any(x => x.StrCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            var drinks = _drinksService.GetDrinksByCategory(category);

            string drink = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[hotpink]Choose drink or go back to category menu by pressing 0:[/]")
                    .PageSize(20)
                    .AddChoices("0")
                    .AddChoices(drinks.Select(d => d.IdDrink))
                );

            if (drink == "0")
                GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink!");
                drink = Console.ReadLine();
            }

            if (!drinks.Any(x => x.IdDrink == drink))
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
