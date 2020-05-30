﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x - Time.deltaTime * speed;
        rigidbody2D.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BunnyController player = other.GetComponent<BunnyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
