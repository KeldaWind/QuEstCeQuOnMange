using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GroupDisplay : MonoBehaviour
{
    public TextMeshProUGUI groupNameText;
    public Transform groupListParent;
    public Image endSeperator;

    public void SetUpGroup(string groupName, Color groupColor)
    {
        groupNameText.text = groupName;
        groupNameText.color = groupColor;

        endSeperator.color = groupColor;
    }

    public void AddToGroup(GameObject toAdd)
    {
        toAdd.transform.SetParent(groupListParent);
    }
}
