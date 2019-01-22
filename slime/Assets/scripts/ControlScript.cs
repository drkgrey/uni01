using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public GameObject Bullet;
    public float BulletDamage = 1;
    public float jumpForce = 1000f;
    [HideInInspector]
    public bool jump = false;
    private bool ready = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        if (h > 0 && facingRight)
        {
            if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
                // ... add a force to the player.
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

            // If the player's horizontal velocity is greater than the maxSpeed...
            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
                // ... set the player's velocity to the maxSpeed in the x axis.
                GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (h < 0 && !facingRight)
        {
            if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
                // ... add a force to the player.
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

            // If the player's horizontal velocity is greater than the maxSpeed...
            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
                // ... set the player's velocity to the maxSpeed in the x axis.
                GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (h > 0 && !facingRight)
                        Flip();
       
        else if (h < 0 && facingRight)
                        Flip();

        if (Input.GetButtonDown("Jump") && ready) { jump = true; Invoke("JumpCD", 0.4f); }
            if (Input.GetButtonDown("Fire1") && facingRight )
            {
                Instantiate(Bullet, transform.position, transform.rotation);
            }
            if (Input.GetButtonDown("Fire1") && !facingRight )
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180f));
            }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate()
    {
       
        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            jump = false;
            ready = false;
        }

    }
    private void JumpCD()
    {
        ready = true;
    }
}

