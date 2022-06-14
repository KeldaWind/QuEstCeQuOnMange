using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuEstCeQuOnMange/Ingredient", fileName = "NewIngredient")]
public class IngredientData : ScriptableObject
{
    public string ingredientDisplayName = "NewIngredient";
    public IngredientTypeData ingredientType;
}
