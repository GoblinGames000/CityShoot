using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameType
{
    Mission,Endless
}
public class LevelManager : MonoBehaviour
{
   public List<Image> Levels;

   public void OnClickHome()
   {
       Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
       Fade.Instance.LoadScene("Main");
   }
   private void Start()
   {
      for (int i = 0; i < Session.Instance.LevelStatus._LevelDatas.Count; i++)
      {
          if (Session.Instance.LevelStatus._LevelDatas[i].Unlocked)
          {
            Levels[i].gameObject.SetActive(false);
          }
          else
          {
              Levels[i].gameObject.SetActive(true);

          }
      }
   }
   public void OnClickLevel(int level)
   {
       if(!Session.Instance.LevelStatus._LevelDatas[level].Unlocked) return;
       Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
       Session.Instance.CurrentLevel = level;
       Fade.Instance.LoadScene("Game");
   }
}
