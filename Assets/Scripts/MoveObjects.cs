using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public float forceMagnitude = 10;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.CompareTag("MoveableObj"))
        {
            Rigidbody colliderRB = hit.collider.attachedRigidbody;
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            colliderRB.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
