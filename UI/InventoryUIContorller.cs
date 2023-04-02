using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIContorller : MonoBehaviour
{
    public DynamicInventorySystem inventoryPanel;
    private void Awake()
    {
        inventoryPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInvontory;
        
    }
    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInvontory;
        
    }

    private void DisplayInvontory(InventorySystem invToDisplay,int offset)
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.RefresDynamicInventory(invToDisplay,offset);
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (inventoryPanel.gameObject.activeInHierarchy&& Input.GetKey(KeyCode.Escape))
        {
            inventoryPanel.gameObject.SetActive(false);
        }
    }
}
