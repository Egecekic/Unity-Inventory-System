
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class InventoryHolder : MonoBehaviour
{
    [SerializeField]private int inventorySize;
    [SerializeField]protected InventorySystem primaryInventorySystem;
    [SerializeField]protected int offset = 4;

    public int Offset=>offset;

    public InventorySystem PrimaryInventorySystem => primaryInventorySystem;

    public static UnityAction<InventorySystem,int> OnDynamicInventoryDisplayRequested; //Inv system to display, amount to offset display by

    protected virtual void Awake()
    {
        SaveLoad.OnLoadGame += LoadInventory;
        primaryInventorySystem = new InventorySystem(inventorySize);
    }
    protected abstract void LoadInventory(SaveData dataData);
}
[System.Serializable]
public struct InventorySaveData
{
    public Vector3 Position;
    public Quaternion rotation;
    public InventorySystem InventorySystem;

    public InventorySaveData(Vector3 position, Quaternion rotation, InventorySystem ýnventorySystem)
    {
        Position = position;
        this.rotation = rotation;
        InventorySystem = ýnventorySystem;
    }

    public InventorySaveData(InventorySystem ýnventorySystem)
    {
        InventorySystem = ýnventorySystem;
        Position= Vector3.zero;
        rotation = Quaternion.identity;
    }
}
