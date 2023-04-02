using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicInventorySystem : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefap;

    public override void AssignSlot(InventorySystem inventoryDisplay,int offset)
    {
        ClearSlots();

        slotDictionary=new Dictionary<InventorySlot_UI,InventorySlot>();

        if (inventoryDisplay == null) return;

        for (int i = offset; i < inventoryDisplay.InventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefap,transform);
            slotDictionary.Add(uiSlot, inventoryDisplay.InventorySlots[i]);
            uiSlot.Init(inventoryDisplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }   
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        
        base.Start();

    }

    public void RefresDynamicInventory(InventorySystem invToDisply,int offset)
    {
        ClearSlots();
        inventorySystem = invToDisply;
        inventorySystem.OnInventorySlotChanged += UpdateSlot;
        AssignSlot(invToDisply, offset);
    }
    private void ClearSlots()
    {
        foreach (var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }
        if (slotDictionary !=null )
        {
            slotDictionary.Clear();
        }
    }
    private void OnDisable()
    {
        if (inventorySystem !=null)
        {
            inventorySystem.OnInventorySlotChanged -= UpdateSlot;
        }
    }
}
