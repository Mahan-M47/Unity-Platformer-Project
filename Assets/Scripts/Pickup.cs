using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float rotationSpeed = 5;
    public float verticalSpeed = 5;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * Time.deltaTime * Mathf.Sin(Time.time * verticalSpeed));
    }

}
