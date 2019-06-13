using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Food")]
public class InventoryItem : ScriptableObject
{
    public Sprite eten;

    public Dier.Voedseltype voedseltype;

}
