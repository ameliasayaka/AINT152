using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class MyScriptableObjectClass : ScriptableObject
{
    public string objectName = "New MyScriptableObject";
    public int currentLevelBuildNumber;
}