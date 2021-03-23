﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvrirCoffre : MonoBehaviour
{
    private Animation anim;

    private void Start()
    {
        anim = transform.GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //on déclenche l'animation d'ouverture du coffre lorsqu'il y a collision avec la clef
        if(other.tag == "key")
        {
            anim.Play();
            Destroy(other.gameObject);
        }
    }
}
