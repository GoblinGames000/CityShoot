using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPoints : MonoBehaviour
{
    public int ball_health;
    public int max_health;
    public int min_health;
    public float size_factor;
    public SpriteRenderer s_renderer;
    public Color32 new_color;
    int score_1;
    int health_1;

    // Start is called before the first frame update
    void Start()
    {
        s_renderer = gameObject.GetComponent<SpriteRenderer>();
        new_color = new Color(Random.value, Random.value, Random.value);
        s_renderer.material.color = new_color;
        size_factor = Random.Range(0.5f, 2f);
        gameObject.transform.localScale = new Vector3(1 * size_factor, 1 * size_factor, 1 * size_factor);
        ball_health = Random.Range(min_health, max_health);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager.Instance._GameState != GameState.Play)
        {
            Destroy(gameObject);

        }

        if(gameObject.transform.localScale.x <= 0.2f && gameObject.transform.localScale.y <= 0.2f)
        {
            Destroy(gameObject);
            
           // GameHandle.score += 100;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            ball_health -= 1;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y -0.1f, gameObject.transform.localScale.z -0.1f);
            ScoreManager.Instance.CurrentScore += 1;
        }
         if(collision.gameObject.tag == "City")
         {
             Destroy(gameObject);
             CanvasManager.Instance.playerHealth -= 1;
             //GameHandle.health -= 1;
         }
    }
}
