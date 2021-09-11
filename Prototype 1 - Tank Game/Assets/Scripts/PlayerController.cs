using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.5f;
    public float turnSpeed;

    public float hInput;
    public float vInput;


    void Start()
    {

    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Moves the tank left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
        // Moves the tank forward and back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
