using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{   
    public GameObject ball;
    public float time;
    public float start_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanvasManager.Instance._GameState!=GameState.Play) return;

        time -= Time.deltaTime;

        if(time <= 0.0f)
        {
            Instantiate(ball, new Vector3(Random.Range(-2.5f,2.5f),6f,-1.5f), Quaternion.identity);
            time = start_time;
        }
    }
}
