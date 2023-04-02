using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[System.Serializable]
public class InventorySlot:ISerializationCallbackReceiver
{

    [NonSerialized] private InventoryIteamData itemData;
    [SerializeField] private int _itemID=-1;
    [SerializeField] private int stackSize;

    public InventoryIteamData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryIteamData itemData, int stackSize)
    {
        this.itemData = itemData;
        _itemID = itemData.ID;
        this.stackSize = stackSize;
    }
    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        _itemID = -1;
        stackSize = -1;
    }
    public void UpdateInventorySlot(InventoryIteamData data,int amount)
    {
        itemData = data;
        _itemID = itemData.ID;
        stackSize = amount;
    }
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = itemData.maxStackSice - stackSize;
        return RoomLeftInStack(amountToAdd);
    }
    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.maxStackSice) return true;
        else return false;
    }
    public void AddToStack(int amount)
    {
        stackSize += amount;
    }
    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    internal void AssignIteam(InventorySlot invSlot)
    {
        
        if (itemData == invSlot.itemData) AddToStack(invSlot.stackSize);
        else
        {
            itemData = invSlot.itemData;
            _itemID = itemData.ID;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
        
    }

    internal bool SplitStack(out InventorySlot splitStack)
    {
        if (stackSize<=1)
        {
            splitStack = null;
            return false;
        }

        int halfStack =Mathf.RoundToInt(stackSize/2);
        RemoveFromStack(halfStack);

        splitStack = new InventorySlot(itemData,halfStack);
        return true;
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        if (_itemID == -1) return;
        var db = Resources.Load<DataBase>("Database");

        itemData = db.GetItem(_itemID);
    }
}
