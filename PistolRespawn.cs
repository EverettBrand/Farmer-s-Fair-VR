using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRespawn : MonoBehaviour
{
    public GameObject PistolToRespawn;
    Vector3 OriginalPistolPos;

    // Start is called before the first frame update
    void Start()
    {
        //Pistol starting position
        OriginalPistolPos = new Vector3(PistolToRespawn.transform.position.x, PistolToRespawn.transform.position.y, PistolToRespawn.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Respawns gun at it's original position
    public void respawnPistol()
    {
        PistolToRespawn.transform.position = OriginalPistolPos;
    }
}
