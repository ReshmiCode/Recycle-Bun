﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        speed = Random.Range(2, 5);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x - Time.deltaTime * speed;
        rigidbody2D.MovePosition(position);
    }

    private void LateUpdate()
    {
        if (rigidbody2D.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController player = other.GetComponent<CharacterController>();
        if (player != null)
        {
            player.ChangeScore(gameObject.name);
            Destroy(gameObject);
        }
    }
}
