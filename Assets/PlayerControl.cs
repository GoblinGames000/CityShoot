using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;
    //Ultimate Shooting
    public GameObject shoot_point;
    public GameObject shoot_object;
    public GameObject shoot_object_effect;
    public float cooldown_time;
    public float time_start;
    public float wait_time;
    public float loop_count;
    public float top_angle;
    public float bottom_angle;
    public bool aim_at_mouse;
    private Vector2 look_direction;
    private float look_angle;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanvasManager.Instance._GameState!=GameState.Play) return;
        cooldown_time -= Time.deltaTime;
        
            if(cooldown_time < time_start)
            {
                Instantiate(shoot_object, shoot_point.transform.position, shoot_point.transform.rotation);
                cooldown_time = 0.08f;
            }
        

        if(aim_at_mouse == true)
        {
            look_direction = Camera.main.WorldToScreenPoint(Input.mousePosition);
            look_angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg;

            gameObject.transform.rotation =  Quaternion.Euler(0,0,look_angle);
        }
    }
}
