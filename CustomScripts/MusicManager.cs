using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //The songs to be played
    public AudioClip mainMusic;
    public AudioClip DuckHunt;
    public AudioClip BallToss;
    public AudioClip Climb;

    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        //Setting the audio source and initial music
        audioSrc = gameObject.GetComponent<AudioSource>();
        changeSong(mainMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Child objects with triggers call this, passing in their corresponding names
     **/
    public void SongUpdate(string songName)
    {
        //Changes song depending on which trigger activated the function
        switch (songName)
        {
            case "DuckHunt":
                print("Changing to DuckHunt Music");
                changeSong(DuckHunt);
                break;
            case "BallToss":
                print("Changing to BallToss Music");
                changeSong(BallToss);
                break;
            case "Climb":
                print("Changing to Climb Music");
                changeSong(Climb);
                break;
        }
    }

    /**
     * Called when Player exits any child object triggers, goes back to the main music
     **/
    void OnTriggerExit(Collider other)
    {
        print("Exit music trigger");
        if (other.tag == "Player")
        {
            changeSong(mainMusic);
        }
    }

    /**
     * Stops current song, sets song to loop, then switches to passed in audio clip
     **/
    public void changeSong(AudioClip src)
    {
        audioSrc.Stop();
        audioSrc.loop = true;
        audioSrc.PlayOneShot(src);
    }
}
