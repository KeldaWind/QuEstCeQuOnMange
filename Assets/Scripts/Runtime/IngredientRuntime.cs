using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IngredientRuntime
{
    public string ingredientDisplayName;
    public IngredientTypeData ingredientType;

    public IngredientRuntime(IngredientData ingredientData)
    {
        ingredientDisplayName = ingredientData.ingredientDisplayName;
        ingredientType = ingredientData.ingredientType;
    }
}
