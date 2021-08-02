using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class MovableCube : MonoBehaviour
{
    [SerializeField] public KeyCode FirstKey;
    [SerializeField] public KeyCode SecondKey;
    [SerializeField] public Vector3 Direction;

    void FixedUpdate()
    {
        if(Input.GetKey(FirstKey))
        {
            GetComponent<Rigidbody>().velocity -= Direction;
        }

        if (Input.GetKey(SecondKey))
        {
            GetComponent<Rigidbody>().velocity += Direction;
        }
    }

}
