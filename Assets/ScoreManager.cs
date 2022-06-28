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

   private void OnEnable()
   {
      if (Session.Instance._GameType == GameType.Endless)
      {
         Bar.transform.parent.gameObject.SetActive(false);
      }
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
         if (Session.Instance._GameType == GameType.Mission)
         {
            Bar.fillAmount = (float) _CurrentScore /
                             (float) Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel]
                                .ScoreToAchieve;
            if (_CurrentScore >= Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].TopScore)
            {
               Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].TopScore = _CurrentScore;
            }

            if (_CurrentScore >= Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel].ScoreToAchieve)
            {
               Session.Instance.LevelStatus._LevelDatas[Session.Instance.CurrentLevel + 1].Unlocked = true;
               CanvasManager.Instance._GameState = GameState.Win;
            }
         }
         else
         {
            if (_CurrentScore >= Session.Instance.EndlessScore)
            {
               Session.Instance.EndlessScore = _CurrentScore;
            }
         }

         ScoreText.text = _CurrentScore.ToString();
         
         
      }
   }
}
