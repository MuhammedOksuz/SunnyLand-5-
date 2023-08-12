using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public enum tankStates {hit, damage, move};
    public tankStates currentStatus; 
    //Script
    PlayerHealt playerHealt;
    //Rigidbody
    [SerializeField] Transform tankObje;
    public float tankSpeed;
    public bool right;
    //Targets
    [SerializeField] Transform rightTarget, leftTarget;
    //Bullet
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletOut;
    [SerializeField] float bulletTime;
    float bulletCounter;
    //Animation
    public Animator animator;
    //Damage
    public float damageTime;
    float damageCounter;
    [SerializeField] GameObject tankUpDamage;
    //Mine
    [SerializeField] GameObject mine;
    [SerializeField] Transform mineOut;
    public float mineTime;
    float mineCounter;
    [SerializeField] GameObject deadthEffect;
    //TankHearth
    public int tankHearth;
    int tankHearthCounter;
    

    private void Awake()
    {
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
        tankHearthCounter = tankHearth;
    }
    private void Start()
    {
        currentStatus = tankStates.hit;
    }
    private void Update()
    {
        switch(currentStatus)
        {
            case tankStates.hit:
                bulletCounter -= Time.deltaTime;
                if (bulletCounter <= 0)
                {
                    bulletCounter = bulletTime;
                    Instantiate(bullet, bulletOut.position, bulletOut.rotation);
                }
                break;
            case tankStates.damage:
                if (damageCounter > 0 )
                {
                    damageCounter -= Time.deltaTime;
                }
                else
                {
                    currentStatus = tankStates.move;
                    mineCounter = 0;
                }
                break;
            case tankStates.move:
                if(right)
                {
                    tankObje.position += new Vector3(tankSpeed * Time.deltaTime, 0, 0);
                    if (tankObje.position.x >= rightTarget.position.x)
                    {
                        tankObje.transform.localScale = Vector3.one;
                        right = false;
                        currentStatus = tankStates.hit;
                        bulletCounter = bulletTime;
                        animator.SetTrigger("Open");
                        tankUpDamage.SetActive(true);
                    }
                }
                else
                {
                    tankObje.position += new Vector3(-tankSpeed * Time.deltaTime, 0, 0);
                    if (tankObje.position.x <= leftTarget.position.x)
                    {
                        tankObje.transform.localScale = new Vector3(-1, 1, 1);
                        currentStatus = tankStates.hit;
                        right = true;
                        bulletCounter = bulletTime;
                        animator.SetTrigger("Open");
                        tankUpDamage.SetActive(true);
                    }
                }
                mineCounter -= Time.deltaTime;
                if (mineCounter <= 0)
                {
                    mineCounter = mineTime;
                    Instantiate(mine, mineOut.transform.position, mineOut.transform.rotation);
                }
                break;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Damage();
        }
    }
    public void Damage()
    {
        currentStatus = tankStates.damage;
        damageCounter = damageTime;
        animator.SetTrigger("Hit");

        tankHearthCounter--;
        SoundController.instance.SoundsEffect(9);
        if (tankHearthCounter <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadthEffect, transform.position,transform.rotation);
        }

        Tank_Mine[] mines = Object.FindObjectsOfType<Tank_Mine>();
        if (mines.Length > 0)
        {
            foreach (Tank_Mine mineDestroy in mines)
            {
                Destroy(mineDestroy.gameObject);
                Instantiate(deadthEffect, mineDestroy.transform.position, mineDestroy.transform.rotation);
            }
        }
    }
}
