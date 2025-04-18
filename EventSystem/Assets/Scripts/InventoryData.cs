using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventoryData 
{
   public List<string> itemNames = new List<string>();
   public List<int> itemQuantities = new List<int>();
    public InventoryData(Dictionary<ItemSO, int> inventory)
    {
        foreach(var entry in inventory)
        {
            itemNames.Add(entry.Key.itemName);
            itemQuantities.Add(entry.Value);
        }
    }

    public Dictionary<ItemSO, int> ToDictionary()
    {
        //tem inventory to pass out of here
        Dictionary<ItemSO, int> inventory = new Dictionary<ItemSO, int>();

        //load all the scriptable object from Resources/ScritableObjects
        foreach (ItemSO item in Resources.LoadAll<ItemSO>("ScriptableObjects"))
        {
            for (int i = 0; i < itemNames.Count; i++)
            {
                Debug.Log(itemNames.Count);
                if (item.itemName == itemNames[i])
                {
                    if (!inventory.ContainsKey(item))
                    {
                        inventory[item] = itemQuantities[i];
                    }
                    else
                    {
                        inventory[item] += itemQuantities[i];
                    }
                }
            }
        }
       
            Debug.Log("No items foudn in resources/scriptableObjects");
            return inventory;   
    }
}
