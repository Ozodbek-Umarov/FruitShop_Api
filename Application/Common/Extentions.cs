using Domain.Entities;
using FluentValidation.Results;
using System.Text;

namespace Application.Common;

public static class Extentions
{
    public static bool IsExists(this Fruit fruit, List<Fruit> fruits)
        => fruits.Any(c =>  c.Name == fruit.Name && c.Id != fruit.Id);

    public static bool IsExists(this Category category, List<Category> categories)
        => categories.Any(c => c.Name == category.Name && c.Id != category.Id);


    public static string GetErrorMessage(this ValidationResult result)
    {
        var resultMessage = new StringBuilder();
        foreach(var error in result.Errors)
        {
            resultMessage.Append(error.ErrorMessage);
        }
        return resultMessage.ToString();
    }
}
