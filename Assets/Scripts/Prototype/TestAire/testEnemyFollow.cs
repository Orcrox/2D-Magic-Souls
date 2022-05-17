using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class testEnemyFollow : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceAllowedTarget;
    private Vector2 directionTarget;
    private float distanceTarget;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        calcDirection();
        calcDistance();
        moveTarget();
    }

    private void calcDirection() {
        directionTarget = (Vector2)(target.position - transform.position).normalized;
    }
    private void calcDistance() {
        distanceTarget = (target.position - transform.position).magnitude;
    }

    private void moveTarget() {
        if (distanceAllowedTarget < distanceTarget) {
            rb.velocity = directionTarget * moveSpeed;
        } else {
            rb.velocity = Vector2.zero;
        }
    }
}
