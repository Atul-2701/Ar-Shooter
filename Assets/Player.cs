using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void ShootTarget()
    {
        Vector3 SpawnPoint = new Vector3(Random.Range(5f, -5f), Random.Range(5f, -5f), 15f);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Target"))
            {
                hit.transform.position = SpawnPoint;
                hit.transform.rotation = Quaternion.identity;
            }
        }

    }
}
