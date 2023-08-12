using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    //scripts
    UýController uýController;
    PlayerController playerController;
    //heart
    public int maxHeart, validHeart;
    //invinciblity
    [SerializeField] float invinciblityTime;
    float invinciblityCounter;
    //spriteAlpha
    SpriteRenderer renderer;
    //Effect
    [SerializeField] GameObject deadthfect;
    private void Awake()
    {
        validHeart = maxHeart;
        uýController = Object.FindObjectOfType<UýController>();
        playerController = Object.FindObjectOfType<PlayerController>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (invinciblityCounter > 0)
        { 
            invinciblityCounter -= Time.deltaTime;
        }
        else
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
        }
    }
    public void Damage()
    {
        if (invinciblityCounter <= 0)
        {
            validHeart--;
            SoundController.instance.SoundsEffect(1);
            uýController.UpdateHealt();
            if (validHeart <= 0)
            {
                validHeart = 0;
                gameObject.SetActive(false);
                Instantiate(deadthfect, transform.position, transform.rotation);
            }
            else
            {
                invinciblityCounter = invinciblityTime;
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.5f);
                playerController.damagePush();


            }
        }
            
        
    }
}
