using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Play,Over,Win
}
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public GameState _gameState;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject OverPanel;
    public GameObject WinPanel;
    public GameState _GameState
    {
        get
        {
            return _gameState;
        }
        set
        {
            _gameState = value;
            switch (_gameState)
            {
                case GameState.Play:
                    break;
                case GameState.Over:
                    OverPanel.SetActive(true);
                    break;
                case GameState.Win:
                    WinPanel.SetActive(true);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public int _playerHealth;

    public int playerHealth
    {
        get
        {
             return _playerHealth;
        }
        set
        {
            _playerHealth = value;
            if (Session.Instance._GameType!=GameType.Mission) return;
            
                
            
            if (_playerHealth <= 0&& Session.Instance._GameType!=GameType.Endless)
            {
                CanvasManager.Instance._GameState = GameState.Over;
            }
        }
    }
    public void onClickNext()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        Session.Instance.CurrentLevel += 1;
        Fade.Instance.LoadScene("Game");
    }
    public void onClickHome()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        Fade.Instance.LoadScene("Level");
    }
    public void onClickReload()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        Fade.Instance.LoadScene("Game");
    }
}
