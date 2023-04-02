using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarDisplay : StaticInventoryDisplay
{
    private int _maxIndexSize = 3;
    private int _currnetIndex= 0;
    public GameObject PlayerGameObject;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _currnetIndex = 0;
        _maxIndexSize = slots.Length - 1;
        slots[_currnetIndex].ToggleHighlight();
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0.1f) ChangeIndex(1);
        if (Input.mouseScrollDelta.y < -0.1f) ChangeIndex(-1);
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseItem();
        }
    }

    private void ChangeIndex(int dir)
    {
        slots[_currnetIndex].ToggleHighlight();
        _currnetIndex += dir;
        if (_currnetIndex > _maxIndexSize) _currnetIndex = 0;
        if (_currnetIndex < 0) _currnetIndex = _maxIndexSize;

        slots[_currnetIndex].ToggleHighlight();
    }

    private void UseItem() 
    {
        if (slots[_currnetIndex].AssignedInventroySlot.ItemData!=null)
        {
            slots[_currnetIndex].AssignedInventroySlot.ItemData.UseItem(PlayerGameObject);
            ClearSlot();
            Debug.Log(slots[_currnetIndex].AssignedInventroySlot.StackSize);
        }
    }
    private void ClearSlot()
    {
        if (slots[_currnetIndex].AssignedInventroySlot.StackSize<=1)
        {
            slots[_currnetIndex].AssignedInventroySlot.ClearSlot();
            slots[_currnetIndex].AssignedInventroySlot.RemoveFromStack(1);
        }
        else
        {
            slots[_currnetIndex].AssignedInventroySlot.RemoveFromStack(1);
        }
        InventorySystem.OnInventorySlotChanged?.Invoke(slots[_currnetIndex].AssignedInventroySlot);
    }
}
