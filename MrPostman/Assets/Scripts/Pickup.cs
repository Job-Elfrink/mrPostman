using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;

    public InventoryItem item;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory.AddItem(item))
            {
            Destroy(this.gameObject);
            }

        }
    }


    // sprite verandert bij het inslepen van een item
    private void OnValidate()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = item.eten;
    }
}
