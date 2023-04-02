using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem 
{
    [SerializeField]
    private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots=> inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;
    
    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }
    public bool AddToInventory(InventoryIteamData iteamToAdd, int amountToAdd)
    {
        if (ContainsItem(iteamToAdd, out List<InventorySlot> invSlot))//check whether item exists in inventory.
        {
            foreach (var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
            
        }
        if (HasFreeSlot(out InventorySlot freeSlot))//Gets this first available slot
        {
            freeSlot.UpdateInventorySlot(iteamToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }
    public bool ContainsItem(InventoryIteamData iteamToAdd,out List<InventorySlot> invSlot) {
        invSlot=InventorySlots.Where(i=>i.ItemData==iteamToAdd).ToList();

        return invSlot == null ? false : true;
    }
    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false: true ;
    }

}
