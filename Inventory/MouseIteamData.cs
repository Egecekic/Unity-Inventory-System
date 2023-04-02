using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseIteamData : MonoBehaviour
{
    public Image iteamSprite;
    public TextMeshProUGUI iteamCount;

    public InventorySlot AssignedInventroySlot;

    internal void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventroySlot.AssignIteam(invSlot);
        iteamSprite.sprite = invSlot.ItemData.icon;
        iteamSprite.color = Color.white;
        iteamCount.text=invSlot.StackSize.ToString();
    }

    private void Awake()
    {
        iteamSprite.color= Color.clear;
        iteamCount.text = "";
    }
    private void Update()
    {
        if (AssignedInventroySlot.ItemData!=null)
        {
            transform.position=Mouse.current.position.ReadValue();
            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
                ClearSlot();
            }
        }
    }

    public void ClearSlot()
    {
        AssignedInventroySlot.ClearSlot();
        iteamCount.text = "";
        iteamSprite.color = Color.clear;
        iteamSprite.sprite=null;
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition=new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results =new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition,results);
        return results.Count > 0;
    }

}
