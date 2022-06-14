using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IIngredientDisplay : MonoBehaviour
{
    protected IngredientRuntime _ingredient;
    public void SetIngredient(IngredientRuntime ingr, bool refreshDisplay)
    {
        _ingredient = ingr;

        if (refreshDisplay)
            RefreshDisplay();
    }

    public abstract void RefreshDisplay();
}
