using BigRookGames.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] Text scoreText;

    Animator animatorController;

    int score = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        animatorController = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootTarget();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.GetInstance().CloseAndOpenMenu();
        }
    }

    public void ShootTarget()
    {
        animatorController.SetTrigger("CanShoot");
        GunfireController.GetInstance().FireWeapon();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Target"))
            {
                GameManager.GetInstance().UpdateValue();
                score++;
                scoreText.text = "Score: " + score.ToString();
                hit.transform.position = GameManager.GetInstance().position;
                hit.transform.rotation = Quaternion.identity;
            }
        }


    }
}
