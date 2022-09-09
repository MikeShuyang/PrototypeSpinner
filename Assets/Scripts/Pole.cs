using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public GameObject target;
    public float spinSpeed;

    private void FixedUpdate()
    {
        transform.RotateAround(target.transform.position, Vector3.up, -spinSpeed * Time.fixedDeltaTime);
    }
}
