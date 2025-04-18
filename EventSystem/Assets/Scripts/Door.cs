using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.Progress;


public class Door : MonoBehaviour
{
    public ItemSO key;
    public ItemSO Item;
    public Inventory inventory;
  

    [SerializeField]
    public bool HasItem;

    private void OnTriggerEnter(Collider other)
    {
        if (HasItem == true)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<Inventory>().RemoveItem(key, 1);
                Destroy(gameObject);

            }
        }
    }
    
}
