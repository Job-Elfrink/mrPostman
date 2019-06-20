using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Audio;

public class Dier : MonoBehaviour
{

    public InventoryItem item;
    public Inventory inventory;

    public Animator anim;

    public GameObject warning;
    public GameObject feed;

    public GameManager gameManager;

    public bool isHungry = true;

    private void Start()
    {
        anim = GetComponent<Animator>();

        warning = Instantiate(warning, transform);
        warning.transform.localPosition = new Vector3(0,0,0);

        gameManager.dierenHonger += 1;

    }



    private void Update()
    {

        if (isHungry == false)
        {
            anim.enabled = false;
            warning.SetActive(false);
     
            Debug.Log("GEEN HONGER MEER");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            
        }

    }

    private void PlaySound()
    {
        AudioSource feed = GetComponent<AudioSource>();
        feed.Play();
    }

    private void StartParticles()
    {
        
        feed = Instantiate(feed, transform);
        feed.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.dieren.Add(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.dieren.Remove(this);
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
        //Als dier honger heeft en dier wil het eten, eet hij het, en heeft hij geen honger meer.
        if (inventory.items[slot] == item && isHungry == true)
        {
            isHungry = false;
            gameManager.dierenHonger -= 1;
            StartParticles();
            PlaySound();
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

