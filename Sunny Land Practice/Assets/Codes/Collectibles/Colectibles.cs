using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectibles : MonoBehaviour
{
    //Scripts
    LevelController levelController;
    U�Controller u�Controller;
    PlayerHealt playerHealt;

    [SerializeField] bool �sItGem;
    bool �sItCollect;

    [SerializeField] GameObject collectEffect;
    private void Awake()
    {
        levelController = Object.FindObjectOfType<LevelController>();
        u�Controller = Object.FindObjectOfType<U�Controller>();
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& !�sItCollect)
        {
            if (�sItGem)
            {
                levelController.collectNumber++;
                �sItCollect = true;
                Destroy(gameObject);
                Instantiate(collectEffect, transform.position, transform.rotation);
                u�Controller.updateGemNumber();
                SoundController.instance.SoundsEffect(7);
            }
            else
            {
                if (playerHealt.validHeart != playerHealt.maxHeart)
                {
                    �sItCollect = true;
                    Destroy(gameObject);
                    Instantiate(collectEffect, transform.position, transform.rotation);
                    playerHealt.validHeart++;
                    u�Controller.UpdateHealt();
                    SoundController.instance.FixSoundEffect(4);
                    if (playerHealt.validHeart >= playerHealt.maxHeart)
                    {
                        playerHealt.validHeart = playerHealt.maxHeart;
                    }
                }
                
            }
           
        }
    }
}
