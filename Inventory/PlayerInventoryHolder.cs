using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerInventoryHolder : InventoryHolder
{
    
    public static UnityAction OnPlayerInventoryChanged;
    private void Start()
    {
        SaveGameManager.data.playerInventory=new InventorySaveData(primaryInventorySystem);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B)) OnDynamicInventoryDisplayRequested?.Invoke(primaryInventorySystem, offset);

    }
    public bool AddToInventory(InventoryIteamData data ,int amount)
    {
        if (primaryInventorySystem.AddToInventory(data,amount))
        {
            return true;
        }
        
        return false;
    }

    protected override void LoadInventory(SaveData saveData)
    {
        if (saveData.playerInventory.InventorySystem!=null)
        {
            this.primaryInventorySystem = saveData.playerInventory.InventorySystem;
            OnPlayerInventoryChanged?.Invoke();
        }
    }
}
