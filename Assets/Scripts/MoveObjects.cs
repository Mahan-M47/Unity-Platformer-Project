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
            Vector3 forceDirection = hit.transform.position - transform.position;

            forceDirection.Normalize();
            forceDirection.y = 0;

            if (transform.position.y < hit.transform.position.y)
            {
                colliderRB.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
