using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMusicTrigger : MonoBehaviour
{
    //Name corresponding to the song we want to play, check MusicManager for what names are looked for
    public string songName;

    //Parent script
    private MusicManager parent;

    void Start()
    {
        //Set parent script
        parent = transform.parent.GetComponent<MusicManager>();
    }

    /**
     * Call SongUpdate on parent script if a player has entered the trigger area
     **/
    void OnTriggerEnter(Collider other)
    {
        print("Entered music trigger for " + songName);
        if (other.tag == "Player")
        {
            parent.SongUpdate(songName);
        }
    }
}
