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
    public TextMeshProUGUI healthText;
    public int playerHealth = 10;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        gameText = GameObject.Find("GameText").GetComponent<TextMeshProUGUI>();
        healthText.text = string.Format("Health: {0}", playerHealth);
    }

    void Update()
    {
        if (gameState == GameState.Start && Input.anyKeyDown)
        {
            StartGame();
        }

        if (gameState == GameState.OponentTurn && Input.anyKeyDown)
        {
            if (playerHealth > 0)
            {
                playerHealth = playerHealth - 1;
            }
            healthText.text = string.Format("Health: {0}", playerHealth);
        }

        if (playerHealth <= 0)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        gameState = GameState.PlayerTurn;
        // set the text to "Player's turn"
        gameText.text = "Player's turn";
        gameText.rectTransform.position = new Vector3(gameText.rectTransform.position.x, 395, gameText.rectTransform.position.z);
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

    public void EndGame()
    {
        gameState = GameState.Lost;
        gameText.text = "Game over";
        gameText.rectTransform.position = new Vector3(gameText.rectTransform.position.x, 215, gameText.rectTransform.position.z);
    }

    
}
