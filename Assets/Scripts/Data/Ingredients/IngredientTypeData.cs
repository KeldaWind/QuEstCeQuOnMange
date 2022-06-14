using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuEstCeQuOnMange/Ingredient Type", fileName = "NewIngredientType")]
public class IngredientTypeData : ScriptableObject
{
    public string ingredientTypeDisplayName = "NewIngredientType";
    public Color ingredientTypeDisplayColor = Color.red;
}
