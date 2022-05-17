using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector2 input;
    [SerializeField] private float moveSpeed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        getInput();
        move();
    }

    private void getInput() {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void move() {
        rb.velocity = input.normalized * moveSpeed;
    }
}
