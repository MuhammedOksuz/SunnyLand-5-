
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Up_Damage : MonoBehaviour
{
    PlayerController playerController;
    Tank tank;

    [SerializeField] GameObject deadthEffect;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        tank = Object.FindObjectOfType<Tank>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.transform.position.y > transform.position.y)
        {
            playerController.EnemyReflexForce();
            gameObject.SetActive(false);
            Instantiate(deadthEffect, other.transform.position, other.transform.rotation);
            tank.Damage();
        }
    }
}
