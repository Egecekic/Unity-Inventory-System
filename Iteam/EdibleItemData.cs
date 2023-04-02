using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(menuName = "Inventory System/Item DataEdible")]
public class EdibleItemData : InventoryIteamData, IItemAction
{
    public string ActionName => "sa";
    [SerializeField]
    private List<ModifierData> modifiersData = new List<ModifierData>();

    public bool PerformAction(GameObject player, float valueF = 0, int valeuInt = 0)
    {
        if (player != null)
        {
            player.GetComponent<PlayerHealth>().health += valeuInt;
            return true;
        }
        else { return false; }
    }

    internal override void UseItem(GameObject gameObject)
    {
        base.UseItem(gameObject);
        PerformAction(gameObject, 0, 20);
    }
    [Serializable]
    public class ModifierData
    {
        public CharacterStatModifierSO statModifier;
        public float value;
    }
}
