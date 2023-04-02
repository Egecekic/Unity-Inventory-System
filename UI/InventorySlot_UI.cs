using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] Image iteamSprite;
    [SerializeField] GameObject _slotHighlight;
    [SerializeField] TextMeshProUGUI iteamCount;
    [SerializeField] InventorySlot assignedInventroySlot;

    private Button button;

    public InventorySlot AssignedInventroySlot => assignedInventroySlot;
    public InventoryDisplay ParentDisplay{get; private set;}

    private void Awake()
    {
        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ClearSlot();
        ParentDisplay=transform.parent.GetComponent<InventoryDisplay>();

    }
    public void Init(InventorySlot slot)
    {
        assignedInventroySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if (slot.ItemData != null)
        {
            iteamSprite.sprite = slot.ItemData.icon;
            iteamSprite.color = Color.white;

            if (slot.StackSize > 1) iteamCount.text = slot.StackSize.ToString();
            else iteamCount.text = "";
            
        }
        else ClearSlot();
        if (true)
        {

        }
    }
    public void UpdateUISlot()
    {
        if (assignedInventroySlot != null) UpdateUISlot(assignedInventroySlot);
    }

    public void OnUISlotClick()
    {
        ParentDisplay?.SlotClicked(this);
    }
    public void ClearSlot()
    {
        assignedInventroySlot?.ClearSlot();
        iteamSprite.sprite = null;
        iteamSprite.color = Color.clear;
        iteamCount.text = "";

    }

    internal void ToggleHighlight()
    {
        _slotHighlight.SetActive(!_slotHighlight.activeInHierarchy);
    }
}
