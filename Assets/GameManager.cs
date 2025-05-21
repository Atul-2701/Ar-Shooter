using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnPoint = new Vector3(Random.Range(10f, -10f), Random.Range(10f, -10f), 10f);

        Instantiate(target, SpawnPoint, Quaternion.identity);
    }
}