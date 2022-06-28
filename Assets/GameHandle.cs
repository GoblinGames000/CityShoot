// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement; 
//
//
// public class GameHandle : MonoBehaviour
// {
//     public static int score;
//     public TextMeshProUGUI score_text;
//     public static int health;
//     public Text health_text;
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         health = 100;
//         score = 0;
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if(health <= 0)
//         {
//             SceneManager.LoadScene("Game", LoadSceneMode.Single);
//         }
//         score_text.text = "Score: " + score;
//        // health_text.text = "City Health: " + health;
//     }
// }
