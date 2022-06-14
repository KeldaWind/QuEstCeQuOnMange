using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RuntimeDataManager : MonoBehaviour
{
    [Header("Data")]
    public IngredientsLibrary ingredientsLibrary;

    [Header("Runtime")]
    public List<IngredientRuntime> ingredients;


    #region Ingredients

    public void GenerateIngredients()
    {
        ingredients = new List<IngredientRuntime>();

        foreach(var ingredientData in ingredientsLibrary.ingredients)
            ingredients.Add(new IngredientRuntime(ingredientData));

        ingredients = ingredients.OrderBy(ingr => ingr.ingredientDisplayName).ToList();
    }

    public ILookup<IngredientTypeData, IngredientRuntime> GetIngredientsByType()
    {
        return ingredients.ToLookup(ingr => ingr.ingredientType);
    }

    #endregion


    void Start()
    {
        GenerateIngredients();


        var ingredientsByType = GetIngredientsByType();

        foreach (var typeGroup in ingredientsByType)
        {
            bool isFirst = true;
            var message = string.Format("{0} : ", typeGroup.Key.ingredientTypeDisplayName);

            foreach(var ingr in typeGroup)
            {
                message = string.Format("{0}{1}{2}", message, isFirst ? "" : ", ", ingr.ingredientDisplayName);

                if (isFirst)
                    isFirst = false;
            }

            Debug.Log(message);
        }
    }
}
