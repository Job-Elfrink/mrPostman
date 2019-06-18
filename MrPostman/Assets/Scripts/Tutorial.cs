using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject volgendeTekst;

    public void Next()
    {
        volgendeTekst.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
