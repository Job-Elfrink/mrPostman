using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Dier : MonoBehaviour
{

    public InventoryItem item;
    public Inventory inventory;

    public Animator anim;

    public bool isHungry = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }



    private void Update()
    {
        
        if (isHungry == false)
        {
            anim.enabled = false;
            Debug.Log("GEEN HONGER MEER");
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.dier = this;
            //FeedAnimal();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.dier = null;
        }
    }

    public enum Voedseltype
    {
        Sla,
        Wortels,
        Wormen,
        Eikels,
        Muis
    }




    public bool FeedAnimal(int slot)
    {
        if (inventory.items[slot] == item && isHungry == true)
        {
            isHungry = false;

            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnValidate()
    {
        isHungry = true;
    }
}

