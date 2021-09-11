using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tank;
    private Vector3 offset = new Vector3(0,50,-100);

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = tank.transform.position + offset;
    }
}
