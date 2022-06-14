using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RuntimeDataManager : MonoBehaviour
{
    public static RuntimeDataManager instance;

    [Header("Data")]
    public IngredientsLibrary ingredientsLibrary;

    [Header("Runtime")]
    public List<IngredientRuntime> ingredients;
    private bool _ingredientsGenerated= false;


    #region Ingredients

    private void WarmupIngredients()
    {
        if (!_ingredientsGenerated)
            GenerateIngredients();
    }

    private void GenerateIngredients()
    {
        ingredients = new List<IngredientRuntime>();

        foreach(var ingredientData in ingredientsLibrary.ingredients)
            ingredients.Add(new IngredientRuntime(ingredientData));

        ingredients = ingredients.OrderBy(ingr => ingr.ingredientDisplayName).ToList();

        _ingredientsGenerated = true;
    }

    public ILookup<IngredientTypeData, IngredientRuntime> GetIngredientsByType()
    {
        WarmupIngredients();
        return ingredients.ToLookup(ingr => ingr.ingredientType);
    }

    #endregion


    void Awake()
    {
        instance = this;

        /*GenerateIngredients();

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
        }*/
    }
}
