using BigRookGames.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] Text scoreText;
    Vector3 postion;

    int score = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootTarget();
        }
    }

    public void ShootTarget()
    {
        GunfireController.GetInstance().FireWeapon();
        Vector3 SpawnPoint = new Vector3(Random.Range(5f, -5f), Random.Range(5f, -5f), 15f);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Target"))
            {
                GameManager.instance.UpdateValue(postion);
                score++;
                scoreText.text = "Score: " + score.ToString();
                hit.transform.position = postion;
                hit.transform.rotation = Quaternion.identity;
            }
        }
          
    }
}
