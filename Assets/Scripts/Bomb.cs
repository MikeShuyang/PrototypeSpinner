using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{

    [SerializeField] private float fallSpeed;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(player);
        }
        Vector3 newPosition = RandomPointOnXZCircle(new Vector3(0, 10, 0), 3);
        Instantiate(gameObject, newPosition, Quaternion.identity);
        Destroy(gameObject);
    }
    
    Vector3 RandomPointOnXZCircle(Vector3 center, float radius) {
        float angle = Random.Range(0, 2f * Mathf.PI);
        return center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y -= fallSpeed * Time.fixedDeltaTime;
        transform.position = position;
    }
}
