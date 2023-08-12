using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Bullet : MonoBehaviour
{
    Tank tank;
    PlayerHealt playerHealt;
    public float bulletSpeed;
    [SerializeField] GameObject effect;
    private void Awake()
    {
        tank = Object.FindObjectOfType<Tank>();
        playerHealt = Object.FindObjectOfType<PlayerHealt>();
    }
    private void Update()
    {
        if(tank.right)
        {
            transform.position += new Vector3(bulletSpeed * Time.deltaTime, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.position += new Vector3(-bulletSpeed * Time.deltaTime, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") ) 
        {
            playerHealt.Damage();
        }
        Destroy(gameObject);
        Instantiate(effect, transform.position, transform.rotation);
    }
}
