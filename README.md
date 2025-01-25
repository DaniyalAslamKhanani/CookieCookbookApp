string readmeContent = @"
# CookieCookbookApp

## Overview


This application lets the user create and save cookie recipes. The user can select the ingredients that will be included in the recipe from a list. The recipe is then saved to a text file along with recipes that have been created before. The text file might be either in a *.txt or a *.json format, depending on the setting defined in the program.

## Glossary
- **Ingredient**: Represents a single ingredient that can be included in the recipe, for example, Wheat Flour or Sugar. Each ingredient has an ID, a name, and a string with instructions on preparing it.
- **Recipe**: A collection of Ingredients (for example, we could have a simple recipe with three ingredients: Wheat Flour, Butter, and Sugar).

## Main Application Workflow
- [Only if some recipes are already saved] When the application starts and some recipes are already saved, it prints all existing recipes.
- The application prints: 'Create a new cookie recipe! Available ingredients are:'
- The user can select ingredients from the list of ingredients.
- If no ingredients are selected: 'No ingredients have been selected. Recipe will not be saved.' is printed.
- If at least one ingredient is selected: 'Recipe added:' is printed, and the newly-added recipe is printed.
- The new recipe is saved in the text file.
- The application prints: 'Press any key to exit.'

## Implementation Details
The project is implemented using .NET 8 and follows several key principles and design patterns:

- **SOLID Principles**: 
  - **Single Responsibility Principle (SRP)**: Each class has a single responsibility, such as managing ingredients or handling user interactions.
  - **Dependency Inversion Principle (DIP)**: High-level modules do not depend on low-level modules; both depend on abstractions. This is achieved through interfaces like `IStringsRepository`.

- **Template Method Design Pattern**: The `Run` method in `CookieRecipeApp` defines the skeleton of the algorithm, deferring some steps to subclasses.

## Storing Recipes in a Text File
The program supports both *.txt and *.json file formats. The format is controlled by a const variable in the program. Recipes are saved as a collection of ingredient IDs.

Example content of the *.txt file:
1,2,3 
1,2

Example content of the JSON file:
["1,2,3", "1,2"]

## Getting Started
To get started with CookieCookbookApp, follow these steps:

1. Clone the repository:
git clone https://github.com/DaniyalAslamKhanani/CookieCookbookApp.git

2. Navigate to the project directory:
cd CookieCookbookApp

3. Build the project:
dotnet build

4. Run the application:
dotnet run --project CookieCookbookApp