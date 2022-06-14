using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsPanelManager : MonoBehaviour
{
    [Header("References")]
    public Transform ingredientsListParent;

    [Header("Prefabs")]
    public GroupDisplay ingredientGroupDisplayPrefab;
    public IIngredientDisplay ingredientDisplayPrefab;

    void Start()
    {
        var ingredientsByType = RuntimeDataManager.instance.GetIngredientsByType();
        
        foreach(var typeGroup in ingredientsByType)
        {
            var newGroupDisplay = Instantiate(ingredientGroupDisplayPrefab, ingredientsListParent);
            newGroupDisplay.SetUpGroup(typeGroup.Key.ingredientTypeDisplayName, typeGroup.Key.ingredientTypeDisplayColor);

            foreach (var ingredient in typeGroup)
            {
                var newIngredientDisplay = Instantiate(ingredientDisplayPrefab);
                newIngredientDisplay.SetIngredient(ingredient, true);
                newGroupDisplay.AddToGroup(newIngredientDisplay.gameObject);
            }
        }
    }
}
