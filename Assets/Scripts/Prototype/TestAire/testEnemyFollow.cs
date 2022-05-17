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

    [SerializeField] private bool pushed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        if (!pushed) {
            calcDirection();
            calcDistance();
            moveTarget();
        }
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

    public void setPushed() {
        StartCoroutine(onPush());
    }
    IEnumerator onPush() {
        pushed = true;
        Vector2 pushdir = (Vector2)(transform.position - target.position).normalized * 10;
        rb.drag = 5f;
        rb.velocity = Vector2.zero;
        rb.AddForce(pushdir, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        rb.drag = 0;
        pushed = false;
    }
}
