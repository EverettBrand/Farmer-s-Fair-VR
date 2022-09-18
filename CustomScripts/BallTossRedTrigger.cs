using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTossRedTrigger : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RedTomato")
        {
            gm.IncrementTTScore();
            Destroy(other.gameObject);
        }
        else
        {
            //play "wrong" audio sound
        }
    }
}
