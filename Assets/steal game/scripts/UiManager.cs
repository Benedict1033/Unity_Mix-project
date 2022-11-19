using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameLoseUI;
    public GameObject gameWinUI;

    bool gameIsOver;

    private void Start ( )
    {
        Guard. OnGuardasSpottedPlayer+=ShowGameLoseUI;
        FindObjectOfType<PlayerController> ( ). OnReachedEndOfLevel+=ShowGameWinUI;
    }

    private void Update ( )
    {
        if ( gameIsOver )
        {
            if ( Input. GetKeyDown ( KeyCode. Space ) )
            {
                SceneManager. LoadScene ( 0);
            }
        }
    }

    void ShowGameWinUI ( )
    {
        OnGameOver ( gameWinUI );
    } 
    
    void ShowGameLoseUI ( )
    {
        OnGameOver ( gameLoseUI );
    }

    void OnGameOver(GameObject gameOverUI )
    {
        gameOverUI. SetActive ( true );
        gameIsOver=true;
        Guard. OnGuardasSpottedPlayer-=ShowGameLoseUI;
    }
}
