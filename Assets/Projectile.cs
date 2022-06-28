using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private void OnEnable()
    {
        if (Session.Instance.CurrentLevel % 2 == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.black;

        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            PlayerControl.Instance.Particle.transform.position = transform.position;
            PlayerControl.Instance.Particle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "City")
        {
            PlayerControl.Instance.Particle.transform.position = transform.position;
            PlayerControl.Instance.Particle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        } 
        if(other.gameObject.tag == "Border")
        {
            PlayerControl.Instance.Particle.transform.position = transform.position;
            PlayerControl.Instance.Particle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }

   
}
