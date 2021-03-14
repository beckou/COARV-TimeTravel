﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Walkman : MonoBehaviour
{
    private New_ZoneManager zoneManager;
    private ourZone zoneActuelle;


    private GameObject currentTape;
    private AudioSource asource;
  

    // Start is called before the first frame update
    void Start()
    {
        zoneManager = GetComponent<New_ZoneManager>();
        zoneActuelle = New_ZoneManager.zoneActuelle;

    }

  void OnCollisionEnter(Collision collision)
    {
        // 2 - Si il n'y a pas de cassette dans le walkman, alors on met celle avec laquelle on est en collision.
        if (currentTape == null/* && collision.gameObject != lastTape*/)
        {
            /*foreach (GameObject tape in tapes)
            {
                //3.check if collision is a cassete 
                if (collision.gameObject.name == tape.name)
                {
                    // 2 - On définit la nouvelle cassette et on récupère certaines informations.
                    currentTape = collision.gameObject;

                    currentTape.GetComponent<Rigidbody>().isKinematic = true;
                    currentTape.transform.parent =  this.transform;


                    currentTape.transform.localPosition = Vector3.zero;// this.transform.position;
                    currentTape.transform.rotation = this.transform.rotation;

                    //  On lance la fonction (Coroutine) lié à l'action de la cassette dans le Walkman
                    Debug.Log(currentTape.name);
                    StartCoroutine("PlaySongCoroutine");
                }
            }*/
            if(collision.gameObject.tag == "K7future" || collision.gameObject.tag == "K7farWest" || collision.gameObject.tag == "K7rock1989queen_2050")
            {
                currentTape = collision.gameObject;

                currentTape.GetComponent<Rigidbody>().isKinematic = true;
                currentTape.transform.parent = this.transform;

                currentTape.transform.localPosition = Vector3.zero;// this.transform.position;
                currentTape.transform.rotation = this.transform.rotation;

                //  On lance la fonction (Coroutine) lié à l'action de la cassette dans le Walkman
                Debug.Log(currentTape.name);
                StartCoroutine("PlaySongCoroutine");
            }
        }
    }
    


    IEnumerator PlaySongCoroutine()
    {
        Debug.Log("Song started !");
        switch (currentTape.name) // 2 - Cassette Actuelle  
        {

            case "K7rock1989queen_2050":
     
                var musique = (AudioClip)Resources.Load<AudioClip>("Audio/Queen TheMiracle");
                 asource = currentTape.GetComponent<AudioSource>();
                 asource.clip = musique;
                
                break;

            case "K7future":
                AudioClip musiquefutur = (AudioClip)Resources.Load<AudioClip>("Audio/the-back-to-the-future");
                asource = currentTape.GetComponent<AudioSource>();
                asource.clip = musiquefutur;
                break;

            case "K7farWest":
                AudioClip musiquewestern = (AudioClip)Resources.Load<AudioClip>("Audio/the-back-to-the-future");
                asource = currentTape.GetComponent<AudioSource>();
                asource.clip = musiquewestern;
                break;
      

        }
        asource.Play();
        
        yield return new WaitForSeconds(5); 

        asource.Stop();
        Debug.Log("Song ended !");

        switch (currentTape.name)
        {
            case "K7rock1989queen_2050":
                zoneManager.GoToA();
                break;
            case "K7future":
                zoneManager.GoToB();
                break;
            case "K7farWest":
                zoneManager.GoToC();
                break;
        

        }
        // On éjecte la cassette du walkman
        Destroy(currentTape);
        if (zoneManager.Used80)
        {
            Instantiate((GameObject)Instantiate((GameObject)Resources.Load("Prefabs/K7rock1989queen_2050"), new Vector3(2f, 2f, 2f), Quaternion.identity));
        }
        if (zoneManager.Usedfutur)
        {
            Instantiate((GameObject)Instantiate((GameObject)Resources.Load("Prefabs/K7future"), new Vector3(2f, 2f, 2f), Quaternion.identity));
        }
        if (zoneManager.Usedwest)
        {
            Instantiate((GameObject)Instantiate((GameObject)Resources.Load("Prefabs/K7farWest"), new Vector3(2f, 2f, 2f), Quaternion.identity));
        }
        //currentTape.transform.parent = null;
        //currentTape.GetComponent<Rigidbody>().isKinematic = false;

        //currentTape = null;

        
       

    }

 
}
