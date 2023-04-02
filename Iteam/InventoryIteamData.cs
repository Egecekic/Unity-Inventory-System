using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Item Data")]
public class InventoryIteamData : ScriptableObject
{
    public int ID=-1;
    public string displayName;
    [TextArea(4,4)]
    public string description;
    public Sprite icon;
    public int maxStackSice;
    public int Value;

    internal virtual void UseItem(GameObject gameObject)
    {
        Debug.Log("Object name: "+displayName);
    }

}
