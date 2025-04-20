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
        }
    }
}
