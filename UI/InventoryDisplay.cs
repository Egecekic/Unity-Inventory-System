using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseIteamData mouseInventoryIteam;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;
    
    public InventorySystem InventorySystem=> inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    public abstract void AssignSlot(InventorySystem inventoryDisplay, int offset);

    protected virtual void Start()
    {

    }

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value==updatedSlot)// Slot value - the "under the hood" inventory slot.
            {
                slot.Key.UpdateUISlot(updatedSlot);// Slot Key - the UI representation of the value.
            }
        }
    }
    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        //Clicked slot has an item mouse doesn't have an item pick up that item.

        if (clickedUISlot.AssignedInventroySlot.ItemData!=null && mouseInventoryIteam.AssignedInventroySlot.ItemData==null)
        {
            //if player holding shift key? Split the stack
            if (isShiftPressed&&clickedUISlot.AssignedInventroySlot.SplitStack(out InventorySlot halfStackSize))
            {
                mouseInventoryIteam.UpdateMouseSlot(halfStackSize);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else 
            {
                mouseInventoryIteam.UpdateMouseSlot(clickedUISlot.AssignedInventroySlot);
                clickedUISlot.ClearSlot();
                return;
            }

            
        }

        // Clicked slot doesn't have an item-Mouse does have an item- place the mouse item into the empty slot.
        if (clickedUISlot.AssignedInventroySlot.ItemData == null && mouseInventoryIteam.AssignedInventroySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventroySlot.AssignIteam(mouseInventoryIteam.AssignedInventroySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryIteam.ClearSlot();
        }

        //Both sþpt have an iteam- decide what to do...
        //Are both iteam the Same? If so combine them
        //is the slot stack size + mouse stack size >the slot size Max stack Size? if so, take from mouse 

        //if different iteams then swap the iteams.
        if (clickedUISlot.AssignedInventroySlot.ItemData != null && mouseInventoryIteam.AssignedInventroySlot.ItemData != null)
        {
            bool isSameIteam = clickedUISlot.AssignedInventroySlot.ItemData == mouseInventoryIteam.AssignedInventroySlot.ItemData;
            if (isSameIteam && clickedUISlot.AssignedInventroySlot.RoomLeftInStack(mouseInventoryIteam.AssignedInventroySlot.StackSize))
            {
                clickedUISlot.AssignedInventroySlot.AssignIteam(mouseInventoryIteam.AssignedInventroySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryIteam.ClearSlot();
                return;
            }
            else if (isSameIteam && !clickedUISlot.AssignedInventroySlot.RoomLeftInStack(mouseInventoryIteam.AssignedInventroySlot.StackSize, out int leftInStack))
            {
                if (leftInStack<1)
                {
                    SwapSlot(clickedUISlot);//stack is full swap to iteams.
                }
                else
                {
                    int remainingOnMouse = mouseInventoryIteam.AssignedInventroySlot.StackSize - leftInStack;
                    clickedUISlot.AssignedInventroySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();

                    var newIteam = new InventorySlot(mouseInventoryIteam.AssignedInventroySlot.ItemData, remainingOnMouse);
                    mouseInventoryIteam.ClearSlot();
                    mouseInventoryIteam.UpdateMouseSlot(newIteam);
                    return;
                }
            }
            else if (!isSameIteam)
            {
                SwapSlot(clickedUISlot);
                return;
            }
        }
    }
    private void SwapSlot(InventorySlot_UI clickedUISlot)
    {
        
        var cloneSlot= new InventorySlot(mouseInventoryIteam.AssignedInventroySlot.ItemData, mouseInventoryIteam.AssignedInventroySlot.StackSize);
        mouseInventoryIteam.ClearSlot();

        mouseInventoryIteam.UpdateMouseSlot(clickedUISlot.AssignedInventroySlot);
        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventroySlot.AssignIteam(cloneSlot);
        clickedUISlot.UpdateUISlot();
    }

}
