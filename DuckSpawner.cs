using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    //Holds popups and radius to check for overlap
    private GameObject[] popups;
    public float popupOverlapCheckRadius;

    //Spawn locations
    public GameObject scrollSpawn;
    public GameObject reverseScrollSpawn;

    //Target prefabs
    public GameObject duckScroll;
    public GameObject duckReverseScroll;
    public GameObject popupTarget;

    public bool stopSpawn = false; //All spawns will stop if this is true

    //Spawn time from Start() and delays between spawns
    public float spawnScrollTime;
    public float spawnScrollDelay;

    public float spawnReverseTime;
    public float spawnReverseDelay;

    public float popupTime;
    public float popupDelay;

    // Start is called before the first frame update
    void Start()
    {
        //Repeatedly invokes method after x seconds with a delay of y seconds
        /**
        InvokeRepeating("SpawnScroller", spawnScrollTime, spawnScrollDelay);
        InvokeRepeating("SpawnReverseScroller", spawnReverseTime, spawnReverseDelay);
    **/

        popups = GameObject.FindGameObjectsWithTag("Popup");
        if (popups != null) //Make sure it isn't empty
        {
            InvokeRepeating("Popup", popupTime, popupDelay);
        }
    }

    public void SpawnScroller()
    {
        Instantiate(duckScroll, scrollSpawn.transform.position, scrollSpawn.transform.rotation);
        if(stopSpawn)
        {
            CancelInvoke("SpawnScroller");
        }
    }

    public void SpawnReverseScroller()
    {
        Instantiate(duckReverseScroll, reverseScrollSpawn.transform.position, reverseScrollSpawn.transform.rotation);
        if (stopSpawn)
        {
            CancelInvoke("SpawnReverseScroller");
        }
    }

    public void Popup()
    {
        bool noOverlap = true;

        GameObject currentObject = popups[Random.Range(0, popups.Length)]; //Pick random object with tag
        Collider[] colliders = Physics.OverlapSphere(currentObject.transform.position, popupOverlapCheckRadius);
        foreach(Collider col in colliders)
        {
            if(col.tag == "Popup")
            {
                print("Prevented popup target collision");
                noOverlap = false;
            }
        }

        if(noOverlap)
        {
            Instantiate(popupTarget, currentObject.transform.position, currentObject.transform.rotation);
        }
        if (stopSpawn)
        {
            CancelInvoke("Popup");
        }
    }



    public void restartSpawner()
    {
        InvokeRepeating("SpawnScroller", spawnScrollTime, spawnScrollDelay);
        InvokeRepeating("SpawnReverseScroller", spawnReverseTime, spawnReverseDelay);

        popups = GameObject.FindGameObjectsWithTag("Popup");
        if (popups != null) //Make sure it isn't empty
        {
            InvokeRepeating("Popup", popupTime, popupDelay);
        }
    }
}
