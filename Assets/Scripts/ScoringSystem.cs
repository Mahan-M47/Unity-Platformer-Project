using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public GameObject gameManager;
    private Manager manager;

    void Start()
    {
        manager = gameManager.GetComponent<Manager>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Pickup"))
        {
            manager.Score();
            Destroy(hit.collider.gameObject);
        }

    }
}
