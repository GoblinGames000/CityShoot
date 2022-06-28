using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
   public Image CityContainer;
   public List<Sprite> Cities;
   
   public SpriteRenderer BackGround;
   public SpriteRenderer Player;
   public TextMeshProUGUI Score;

   private void OnEnable()
   {
      CityContainer.sprite = Cities[Session.Instance.CurrentLevel];
      if (Session.Instance.CurrentLevel % 2 == 0)
      {
         BackGround.color = Color.white;
         Player.color = Color.black;
         Score.color = Color.black;
         CityContainer.color=Color.black;
      }
      else
      {
         BackGround.color = Color.black;
         Player.color = Color.white;
         Score.color = Color.white;

         CityContainer.color=Color.white;

      }
   }
}
