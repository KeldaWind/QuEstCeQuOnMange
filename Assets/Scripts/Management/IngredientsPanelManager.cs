using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsPanelManager : MonoBehaviour
{
    [Header("References")]
    public Transform ingredientsListParent;

    [Header("Prefabs")]
    public IIngredientDisplay ingredientDisplayPrefab;

    void Start()
    {
        var ingredientsByType = RuntimeDataManager.instance.GetIngredientsByType();
        
        foreach(var typeGroup in ingredientsByType)
        {
            foreach(var ingredient in typeGroup)
            {
                var newIngredientDisplay = Instantiate(ingredientDisplayPrefab, ingredientsListParent);
                newIngredientDisplay.SetIngredient(ingredient, true);
            }
        }
    }
}
