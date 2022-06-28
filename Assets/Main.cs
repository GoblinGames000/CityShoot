using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
  public GameObject EndlessComplete;
  public TextMeshProUGUI EndlessScore;
  public void OnClickMission()
  {
    Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
    Session.Instance._GameType = GameType.Mission;
    Fade.Instance.LoadScene("Level");
  }
  public void OnClickEndless()
  {
    if (Session.Instance.LevelStatus._LevelDatas.Any(x => x.Unlocked == false))
    {
      EndlessComplete.SetActive(true);
      return;
      
    }
    Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
    Session.Instance._GameType = GameType.Endless;
    Fade.Instance.LoadScene("Game");
  }

  private void Start()
  {
    EndlessScore.text = string.Format("Top Score : {0}", Session.Instance.EndlessScore);
  }
}
