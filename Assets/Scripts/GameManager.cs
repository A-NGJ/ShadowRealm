using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    Start,
    PlayerTurn,
    OponentTurn,
    Won,
    Lost,
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    // define a variable to hold the text object
    public TextMeshProUGUI gameText;
    

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        gameText = GameObject.Find("GameText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (gameState == GameState.Start && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameState = GameState.PlayerTurn;
        // set the text to "Player's turn"
        gameText.text = "Player's turn";
    }

    public void EndTurn()
    {
        StartCoroutine(SwitchTurns());
    }

    private IEnumerator SwitchTurns()
    {
        yield return new WaitForSeconds(1f);
        if (gameState == GameState.PlayerTurn)
        {
            gameState = GameState.OponentTurn;
            // set the text to "Oponent's turn"
            gameText.text = "Oponent's turn";
        }
        else if (gameState == GameState.OponentTurn)
        {
            gameState = GameState.PlayerTurn;
            // set the text to "Player's turn"
            gameText.text = "Player's turn";
        }
    }

    
}
