using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject Player;
    public Rigidbody2D rb;

    private float playerx;

    // Update is called once per frame
    void Update()
    {
        // float distanceToPlayer = (transform.position - Player.transform.position).sqrMagnitude;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftWall"))
        {
            transform.position = Vector3.MoveTowards(transform.position, -Player.transform.position, speed * Time.deltaTime);        }

        if (other.gameObject.CompareTag("RightWall"))
        {
            transform.position = Vector3.MoveTowards(transform.position, -Player.transform.position, speed * Time.deltaTime);
        }
    }
}