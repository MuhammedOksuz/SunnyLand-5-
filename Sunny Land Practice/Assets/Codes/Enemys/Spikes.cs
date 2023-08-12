using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    PlayerHealt playerhealth;
    private void Awake()
    {
        playerhealth = Object.FindObjectOfType<PlayerHealt>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerhealth.Damage();
        }
    }
}
