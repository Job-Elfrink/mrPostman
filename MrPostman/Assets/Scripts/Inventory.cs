using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public Sprite emptyItemSlot;

    public static HashSet<Dier> dieren = new HashSet<Dier>();

    public List<Image> slots = new List<Image>();

    public bool AddItem(InventoryItem item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                // sprite van empty slot = sprite item
                slots[i].sprite = item.eten;


                return true;
            }
        }

        return false;
    }

    public void Feed(int slot)
    {
        foreach(Dier dier in dieren)
        {
            if (dier != null && items[slot] != null && dier.item == items[slot] )
            {
                if (dier.FeedAnimal(slot))
                {
                    items[slot] = null;
                    slots[slot].sprite = emptyItemSlot;
                }

            }
        }

    }

}
