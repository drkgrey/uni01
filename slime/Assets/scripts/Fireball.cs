using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    private float damage;
    public float lifetime = 3;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlScript>().BulletDamage;
            col.gameObject.GetComponent<Enemy1>().Hurt(damage);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }

}