using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName ="Inventory System/Iteam database")]
public class DataBase : ScriptableObject
{
    [SerializeField] private List<InventoryIteamData>_itemDatabase;
    public List<InventoryIteamData> ItemDatabase => _itemDatabase;
    [ContextMenu("Set IDs")]
    public void SetItemIds()
    {
        _itemDatabase = new List<InventoryIteamData>();

        var foundItems = Resources.LoadAll<InventoryIteamData>("ItemData").OrderBy(i=>i.ID).ToList();

        var hasIDInRange=foundItems.Where(i=>i.ID!=-1 && i.ID<foundItems.Count).OrderBy(i => i.ID).ToList();
        var hasIDNotInRange = foundItems.Where(i => i.ID != -1 && i.ID >= foundItems.Count).OrderBy(i => i.ID).ToList();
        var noID= foundItems.Where(i => i.ID <= -1).ToList();

        var index = 0;
        for (int i = 0; i < foundItems.Count; i++)
        {
            Debug.Log($"Checking ID {i}");
            var itemToAdd = hasIDInRange.Find(d => d.ID == i);

            if (itemToAdd != null)
            {
                Debug.Log($"Found item {itemToAdd} which has an id of {itemToAdd.ID}");
                _itemDatabase.Add(itemToAdd);
            }
            else if (index < noID.Count)
            {
                noID[index].ID = i;
                Debug.Log($"Setting item {noID[index]} which has an invalid id to the id of {i}");
                itemToAdd = noID[index];
                index++;
                _itemDatabase.Add(itemToAdd);
            }
            #if UNITY_EDITOR
            if (itemToAdd) EditorUtility.SetDirty(itemToAdd);
            #endif
        }
        foreach (var item in hasIDNotInRange)
            {
                _itemDatabase.Add(item);
                #if UNITY_EDITOR
                if (item) EditorUtility.SetDirty(item);
                #endif
            }
            #if UNITY_EDITOR       
            AssetDatabase.SaveAssets();
            #endif
        }

        public InventoryIteamData GetItem(int id)
        {
            return _itemDatabase.Find(i => i.ID == id);
        }
    
        public InventoryIteamData GetItem(string displayName)
        {
            return _itemDatabase.Find(i => i.displayName== displayName);
        }
    
}
