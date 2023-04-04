using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UniqueID))]
public class PickUp : MonoBehaviour
{
    public InventoryIteamData IteamData;
    [SerializeField] IteamPickUpData IteamSaveData;
    [SerializeField] string id;

    private void Awake()
    {
        SaveLoad.OnLoadGame += LoadGame;
        id = GetComponent<UniqueID>().ID;
        IteamSaveData = new IteamPickUpData(transform.position, transform.rotation, IteamData);
    }

    void Start()
    {
        SaveGameManager.data.activeIteam.Add(id,IteamSaveData);
    }

    private void LoadGame(SaveData arg0)
    {
        Debug.Log(SaveGameManager.data.collectedItems.Count);
        if (SaveGameManager.data.collectedItems.Contains(id))
        {
            Debug.Log(id);
            Destroy(this.gameObject);
        }   
    }
    private void OnDestroy()
    {
        if (SaveGameManager.data.activeIteam.ContainsKey(id))
        {
            SaveGameManager.data.activeIteam.Remove(id);
            
        }
        SaveLoad.OnLoadGame -= LoadGame;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory=other.GetComponent<PlayerInventoryHolder>();

        if (!inventory) return;
        if (inventory.AddToInventory(IteamData,1))
        {
            SaveGameManager.data.collectedItems.Add(id);
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public struct IteamPickUpData
{
    public InventoryIteamData SaveData;
    public Vector3 Position;
    public Quaternion rotation;


    public IteamPickUpData(Vector3 position, Quaternion rotation, InventoryIteamData SaveData)
    {
        Position = position;
        this.rotation = rotation;
        this.SaveData = SaveData;
    }
}
