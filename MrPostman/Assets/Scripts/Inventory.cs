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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            Feed(0);
        }
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Feed(1);
        }
        if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            Feed(2);
        }

    }

    public void Feed(int slot)
    {
        // ga alle dieren in de list af
        foreach(Dier dier in dieren)
        {
            //als er een dier is, en een item in het slot, en het dier wil het item, wordt het slot weer leeg gemaakt
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
