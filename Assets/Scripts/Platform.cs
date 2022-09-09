using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, spinSpeed * Time.fixedDeltaTime, 0);
    }
}
