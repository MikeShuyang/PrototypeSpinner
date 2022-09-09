using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public GameObject target;

    private void FixedUpdate()
    {
        transform.RotateAround(target.transform.position, Vector3.up, -40 * Time.fixedDeltaTime);
    }
}
