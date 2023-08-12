using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    //Script
    PlayerHealt playerHealt;
    //Rigidbody
    Rigidbody2D rb;
    //Move
    [SerializeField] SpriteRenderer frogSprite;
    [SerializeField] float frogMoveSpeed;
    bool right;
    public float moveTime, waitTime;
    float moveCounter, waitCounter;
    //Targets
    public Transform rightTarget, leftTarget;
    //Animation
    Animator animator;
    //Effect
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
    }
    private void Start()
    {
        rightTarget.parent = null;
        leftTarget.parent = null;
        right = true;
        moveCounter = moveTime;
    }
    private void Update()
    {
        animator.SetFloat("Moveing", Mathf.Abs(rb.velocity.x));
        if (moveCounter > 0)
        {
            moveCounter -= Time.deltaTime;
            if (right)
            {
                frogSprite.flipX = true;
                rb.velocity = new Vector2(frogMoveSpeed, rb.velocity.y);
                if (transform.position.x >= rightTarget.position.x)
                {
                    right = false;
                }
            }
            else
            {
                frogSprite.flipX = false;
                rb.velocity = new Vector2(-frogMoveSpeed, rb.velocity.y);
                if (transform.position.x <= leftTarget.position.x)
                {
                    right = true;
                }
            }
            if (moveCounter <= 0)
            {
                waitCounter = waitTime;
            }
        }
        else if (waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            moveCounter = moveTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (transform.position.y < other.transform.position.y)
            {
                playerHealt.Damage();
            }
        }
    }

}
