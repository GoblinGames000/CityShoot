using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager Instance;
   public TextMeshProUGUI ScoreText;
   public int _CurrentScore;
   public Image Bar;

   private void Awake()
   {
      Instance = this;
   }

   public int CurrentScore
   {
      get
      {
         return _CurrentScore;
      }
      set
      {
         _CurrentScore = value;
         Bar.fillAmount = _CurrentScore /
                          Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].ScoreToAchieve;
         if (_CurrentScore >= Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].TopScore)
         {
            Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].TopScore = _CurrentScore;
         } 
         if (_CurrentScore >= Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].ScoreToAchieve)
         {
            CanvasManager.Instance._GameState = GameState.Win;
         }
         ScoreText.text = _CurrentScore.ToString();
      }
   }
}
