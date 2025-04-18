using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using static UnityEditor.Progress;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    public Dictionary<ItemSO, int> items = new Dictionary<ItemSO, int>();
    public int maxSlots = 50;

    public delegate void OnInventoryChanged();
    public event OnInventoryChanged onInventoryUpdated;
    public ItemSO key;

    public string savePath;

    private void Start()
    {

        DontDestroyOnLoad(this.gameObject);
        savePath = Path.Combine(Application.persistentDataPath, "Inventory.Json");
    }
    public void AddItem(ItemSO newItem, int amount)
    {
       if(items.ContainsKey(newItem))
        {
            items[newItem] += amount;
        }
        else
        {
            if(items.Count >= maxSlots)
            {
                Debug.Log("Inventory full");
                return;
            }
            items.Add(newItem, amount);
        }
       //update inventory UI here
       onInventoryUpdated?.Invoke();
    }

    public void RemoveItem(ItemSO itemToRemove, int amount)
    {
        if (items.ContainsKey(itemToRemove))
        {
            items[itemToRemove] -= amount;
            if (items[itemToRemove] <=0)
            {
                items.Remove(itemToRemove);
                
                
            }
        }
        //update inventory UI here
        onInventoryUpdated?.Invoke();
    }

    public bool HasItem(ItemSO item, int amount)
    {
        return items.ContainsKey(item) && items[item] >= amount;
    }

    public void SaveInventory ()
    {
        InventoryData data = new InventoryData(items);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Inventory saved:" + json);
    }

    public void LoadInventory ()
    {
        if (File.Exists(savePath))
        {
            Debug.Log("found file at " + savePath);
            string json = File.ReadAllText(savePath);
            InventoryData data = JsonUtility.FromJson<InventoryData>(json);
            items = data.ToDictionary();

            Debug.Log("inventory after loading =" + items.Count + "items");
            onInventoryUpdated?.Invoke();
        }
        else
        {
            Debug.Log("No save file found");
        }
    }
    public void UseItem()
    {

    }
    
}
