using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientsDisplayIngredientsPanel : IIngredientDisplay
{
    public Image typeColorImage;
    public TextMeshProUGUI ingredientName;

    public override void RefreshDisplay()
    {
        typeColorImage.color = _ingredient.ingredientType.ingredientTypeDisplayColor;
        ingredientName.text = _ingredient.ingredientDisplayName;
    }
}
