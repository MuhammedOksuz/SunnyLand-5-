using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectibles : MonoBehaviour
{
    //Scripts
    LevelController levelController;
    UýController uýController;
    PlayerHealt playerHealt;

    [SerializeField] bool ýsItGem;
    bool ýsItCollect;

    [SerializeField] GameObject collectEffect;
    private void Awake()
    {
        levelController = Object.FindObjectOfType<LevelController>();
        uýController = Object.FindObjectOfType<UýController>();
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& !ýsItCollect)
        {
            if (ýsItGem)
            {
                levelController.collectNumber++;
                ýsItCollect = true;
                Destroy(gameObject);
                Instantiate(collectEffect, transform.position, transform.rotation);
                uýController.updateGemNumber();
                SoundController.instance.SoundsEffect(7);
            }
            else
            {
                if (playerHealt.validHeart != playerHealt.maxHeart)
                {
                    ýsItCollect = true;
                    Destroy(gameObject);
                    Instantiate(collectEffect, transform.position, transform.rotation);
                    playerHealt.validHeart++;
                    uýController.UpdateHealt();
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
