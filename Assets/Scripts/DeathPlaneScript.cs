using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("death");
        collider.gameObject.SetActive(false);
    }

}
