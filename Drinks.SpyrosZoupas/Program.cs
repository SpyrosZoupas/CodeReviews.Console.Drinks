using Drinks.SpyrosZoupas;

DrinksService drinksService = new DrinksService();
UserInput userInput = new UserInput(drinksService);
userInput.GetCategoriesInput();
