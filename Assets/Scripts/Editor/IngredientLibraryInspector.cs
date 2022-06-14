using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(IngredientsLibrary))]
public class IngredientLibraryInspector : Editor
{
    public override void OnInspectorGUI() 
    {
        if(GUILayout.Button("Auto Fill Library"))
            AutoFillLibrary();

        base.OnInspectorGUI();
    }

    private async void AutoFillLibrary() 
    {
        var targetLibrary = target as IngredientsLibrary;

        var ingredients = new List<IngredientData>();

        var ingredientsUntyped = AssetDatabase.FindAssets("t:IngredientData");
        foreach(var ingredientUntyped in ingredientsUntyped) {
            var ingredient = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(ingredientUntyped), typeof(IngredientData)) as IngredientData;
            ingredients.Add(ingredient);
        }

        targetLibrary.ingredients = new IngredientData[ingredients.Count];
        for(int i=0;i<ingredients.Count;i++)
            targetLibrary.ingredients[i] = ingredients[i];

        targetLibrary.ingredients = targetLibrary.ingredients.OrderBy(ingr => ingr.name).ToArray();
    }
}
