using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTossRotate : MonoBehaviour
{
    //public bool stopRotate = false;
    private float rotateTime;
    private float rotateTimeDelay;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<BallTossRotate>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<BallTossRotate>().enabled == true)
            InvokeRepeating("rotate", rotateTime, rotateTimeDelay);

        if (this.gameObject.GetComponent<BallTossRotate>().enabled == false)
            CancelInvoke("rotate");
    }



    //rotate() - makes base plate rotate
    void rotate()
    {
        
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        
        
    }
}
