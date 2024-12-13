using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int itemValue = 1;  // Value of the item

    // Detect when the player enters the trigger area (collects the item)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collected the item
        if (other.CompareTag("Player"))
        {
            // Access the PlayerInventory script attached to the player
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null)
            {
                // Update the player's item count
                playerInventory.CollectItem(itemValue);
            }

            // Destroy the item after it's collected
            Destroy(gameObject);
        }
    }
}
