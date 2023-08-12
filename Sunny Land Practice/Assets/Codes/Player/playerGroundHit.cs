using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundHit : MonoBehaviour
{
    //Scripts
    PlayerController playerController;
    Tank tank;
    //Effect
    [SerializeField] GameObject deadthEffect;
    //Cherry
    [SerializeField] GameObject cherry;
    public float cherryChance; 
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        tank = Object.FindObjectOfType<Tank>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (transform.position.y > other.transform.position.y)
            {
                Destroy(other.gameObject);
                SoundController.instance.SoundsEffect(0);
                Instantiate(deadthEffect,other.transform.position,other.transform.rotation);
                playerController.EnemyReflexForce();
                float cherryRandom = Random.Range(1, 101);
                if (cherryRandom <= cherryChance)
                {
                    Instantiate(cherry, other.transform.position, other.transform.rotation);
                }
            }
        }
    }

}
