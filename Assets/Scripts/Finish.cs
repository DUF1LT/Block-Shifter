using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action PlayerFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
            PlayerFinish?.Invoke();
    }
}
