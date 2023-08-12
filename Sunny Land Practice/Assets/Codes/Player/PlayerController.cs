using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody
    Rigidbody2D rb;
    //Move
    [SerializeField] float moveSpeed;
    bool moving = true;
    //Jump
    bool inTheGround;
    bool canJumpTwice;
    [SerializeField] float jumpFoce;
    [SerializeField] Transform raycastPoint;
    [SerializeField] LayerMask raycastMask;
    //Animator
    public Animator playerAnimator;
    //DamagePush
    public float pushTime, pushPower;
    float pushCounter;
    bool isItRight;
    //EnemyReflex
    public float enemyReflexForce;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        playerAnimator.SetBool("Jump", inTheGround);
        playerAnimator.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
       
        if (pushCounter <= 0)
        {
            Move();
            Jump();
        }
        else
        {
            pushCounter -= Time.deltaTime;
            if (isItRight)
            {
                rb.velocity = new Vector2(-pushPower, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(pushPower, rb.velocity.y);
            }
        }
        
    }
    void Move()
    {

        if (rb.velocity.x >= 0)
        {
            isItRight = true;
            transform.localScale = Vector3.one;
            float horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
        else
        {
            isItRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
            float horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
    }
    void Jump()
    {
        inTheGround = Physics2D.OverlapCircle(raycastPoint.position, .2f, raycastMask);

        if (inTheGround)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpFoce);
                SoundController.instance.SoundsEffect(3);
                canJumpTwice = true;
            }
        }
        else
        {
            if (canJumpTwice && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpFoce);
                SoundController.instance.SoundsEffect(3);
                canJumpTwice = false;
            }
        }


    }
    public void damagePush()
    {
        pushCounter = pushTime;
        rb.velocity = new Vector2(0, rb.velocity.y);
        playerAnimator.SetTrigger("Damage");
    }
    public void EnemyReflexForce()
    {
        rb.velocity = new Vector2(rb.velocity.x, enemyReflexForce);
    }
}