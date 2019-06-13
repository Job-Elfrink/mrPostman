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

    private void Update()
    {
      //  if (dier.isHungry == false)
        {
         //   Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.AddItem(item);
            if(inventory.items.Contains(item))
            Destroy(this.gameObject);
        }
    }


    // sprite verandert bij het inslepen van een item
    private void OnValidate()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = item.eten;
    }
}
