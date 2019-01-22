using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {
    public float moveSpeed = 2f;        
    public float HP = 3;
    public float power = 1f;
    public bool facingRight = true;

    // Use this for initialization
    void Start () {
       

    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update () {
        
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
	}
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
       
    }
    public void Hurt(float dmg)
    {
        HP=HP-dmg;

    }
    public void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
        if (facingRight) facingRight = false;
        else facingRight = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Flip();
        }
    }
    

}
