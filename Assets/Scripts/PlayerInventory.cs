using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro import
using UnityEngine.SceneManagement;


public class PlayerInventory : MonoBehaviour
{
    public int itemCount = 0;  // The number of items collected by the player
    public TextMeshProUGUI itemCountText;  // Reference to the UI TextMeshPro component

    void Start()
    {
        // Initialize the item count text to reflect the current value at the start
        UpdateItemCountUI();
    }

    // This function will be called by CollectibleItem when the player collects an item
    public void CollectItem(int value)
    {
        itemCount += value;  // Increase the item count by the item's value
        Debug.Log("Item Collected, total: " + itemCount);
        UpdateItemCountUI();  // Update the UI after collecting an item
    }

    // Update the UI with the current item count
    void UpdateItemCountUI()
    {
        itemCountText.text = "Fragments: " + itemCount.ToString();
        if (itemCount == 6)
        {
            SceneManager.LoadScene("StoryEnd");
        }
    }
}
