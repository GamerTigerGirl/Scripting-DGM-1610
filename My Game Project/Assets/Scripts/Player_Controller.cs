using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //Added player movement
    public float speed;
    public float hInput;
    public float vInput;
    

    public GameObject projectile;
    public Transform launcher;
    public Vector3 offset = new Vector3(0,1,0);


    // Update is called once per frame
    void Update()
    {
    
    }
}
