using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO item;
    public int amount = 1;
    public AudioSource audioSource;
    public AudioClip clip;
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory)
            {
               inventory.AddItem(item, amount);
                door.HasItem = true;
                Destroy(gameObject);    
               
            }
        }


    }
    
    public void PlaySoundEffect()
    {
        audioSource.Play();
        AudioClip clip = audioSource.clip;
    }
}
