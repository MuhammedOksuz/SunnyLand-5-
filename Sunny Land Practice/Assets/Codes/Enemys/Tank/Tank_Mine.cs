using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Mine : MonoBehaviour
{
    PlayerHealt playerHealt;
    [SerializeField] GameObject deadthEffect;
    private void Awake()
    {
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
            playerHealt.Damage();
            Instantiate(deadthEffect, transform.position, transform.rotation);
        }
    }
}
