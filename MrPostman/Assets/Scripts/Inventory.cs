using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public Sprite emptyItemSlot;

    public static Dier dier;

    public List<Image> slots = new List<Image>();

    public void AddItem(InventoryItem item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                // sprite van empty slot = sprite item
                slots[i].sprite = item.eten;


                break;
            }
        }
    }

    public void Feed(int slot)
    {
        if (dier != null && items[slot] != null)
        {
            if (dier.FeedAnimal(slot))
            {
                items[slot] = null;
                slots[slot].sprite = emptyItemSlot;
            }

        }
    }

}
