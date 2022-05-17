using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDirectionAttack : MonoBehaviour {
    private Vector2 mousePos;
    [SerializeField] private float coolDown;
    [SerializeField] private bool ableAttack;
    [SerializeField] private GameObject area;

    private void Start() {
        ableAttack = true;
        area.SetActive(false);
    }

    private void Update() {
        calcMousePosition();
        lookAt();
        checkAttack();
    }

    private void calcMousePosition() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void lookAt() {
        transform.right = (mousePos - (Vector2)transform.position);
    }

    private void checkAttack() {
        if (!ableAttack) {
            return;
        }
        if (Input.GetMouseButtonDown(1)) {
            StartCoroutine(attack());
        }
    }

    IEnumerator attack() {
        ableAttack = false;
        area.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        area.SetActive(false);
        yield return new WaitForSeconds(coolDown);
        ableAttack = true;
        yield return null;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(mousePos, 0.2f);
    }
}
