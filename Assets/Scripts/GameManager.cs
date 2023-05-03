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

public enum ActorType
{
    Player,
    Opponent,
}

public class Actor
{
    public ActorType actorType;
    public int health;
    public List<Card> cards;
    public TextMeshProUGUI healthTextUGUI;
    private string healthText;

    public void setHealthText(string healthText)
    {
        this.healthText = healthText;
        this.healthTextUGUI.text = string.Format(this.healthText, 0);
    }

    public void setHealth(int health)
    {
        this.health = health;
        this.healthTextUGUI.text = string.Format(this.healthText, this.health);
    }
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public List<Transform> opponentPlaceholders;
    public CardManager cardManager;
    // define a variable to hold the text object
    public TextMeshProUGUI gameText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI opponentHealthText;
    public int playerHealth = 10;
    public int opponentHealth = 10;
    public Actor player;
    public Actor opponent;

    private bool opponentCardsDistributed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = new Actor();
        player.actorType = ActorType.Player;
        player.healthTextUGUI = playerHealthText;
        player.setHealthText("Player Health: {0}");
        player.setHealth(playerHealth);

        opponent = new Actor();
        opponent.actorType = ActorType.Opponent;
        opponent.healthTextUGUI = opponentHealthText;
        opponent.setHealthText("Opponent Health: {0}");
        opponent.setHealth(opponentHealth);

        gameState = GameState.Start;

        // Find all opponent placeholders in the scene
        opponentPlaceholders = new List<Transform>();
        foreach (GameObject placeholder in GameObject.FindGameObjectsWithTag("opponent-placeholder"))
        {
            opponentPlaceholders.Add(placeholder.transform);
        }
        Debug.Log("Found " + opponentPlaceholders.Count + " opponent placeholders");
    }

    void Update()
    {
        switch (gameState) {
            case GameState.Start:
                if (Input.anyKeyDown)
                {
                    StartGame();
                }
                break;
            case GameState.PlayerTurn:
                opponentCardsDistributed = false;
                break;
            case GameState.OponentTurn:
                if (!opponentCardsDistributed)
                {
                    int attackVal = DistributeOponentCards();
                    Attack(player, attackVal);
                    EndTurn();
                }
                break;
            case GameState.Won:
                break;
            case GameState.Lost:
                break;
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
        if (gameState == GameState.OponentTurn || gameState == GameState.PlayerTurn)
        {
            StartCoroutine(SwitchTurns());
        }
    }

    private IEnumerator SwitchTurns()
    {
        Debug.Log("switching turns");
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

    public void LoseGame()
    {
        gameState = GameState.Lost;
        gameText.text = "Game over";
        gameText.rectTransform.position = new Vector3(
            gameText.rectTransform.position.x,
            215,
            gameText.rectTransform.position.z
        );
    }

    void WinGame()
    {
        gameState = GameState.Won;
        gameText.text = "You won!";
        gameText.rectTransform.position = new Vector3(
            gameText.rectTransform.position.x,
            215,
            gameText.rectTransform.position.z
        );
    }

    private int DistributeOponentCards()
    {
        int numberOfCards = Random.Range(1, 5); // Distribute between 1 and 4 cards

        for (int i = 0; i < numberOfCards; i++) {
            // Find a random free placeholder
            Transform freePlaceholder = null;
            int attempts = 4;
            int randomIndex;

            while (freePlaceholder == null && attempts > 0)
            {
                randomIndex = Random.Range(0, opponentPlaceholders.Count);
                if (opponentPlaceholders[randomIndex].childCount == 0)
                {
                    freePlaceholder = opponentPlaceholders[randomIndex];
                    break;
                }
                attempts--;
            }            
            if (freePlaceholder != null)
            {
                // Create a card
                GameObject card = Instantiate(cardManager.DrawCard());
               // Place the card on the free placeholder
                card.transform.SetParent(freePlaceholder);
                card.transform.localPosition = Vector3.zero;
                // card.transform.localRotation = Quaternion.identity;
            }
        }

        opponentCardsDistributed = true;

        Debug.Log("Cards distributed");
        // Calculate the total attack value of all opponent's cards
        int totalAttack = 0;
        foreach (Transform placeholder in opponentPlaceholders)
        {
            if (placeholder.childCount > 0)
            {
                Card card = placeholder.GetChild(0).GetComponent<Card>();
                totalAttack += card.attackVal;
            }
        }

        Debug.Log("attack");
        // return cumulated attack value
        return totalAttack;
    }

    private void Attack(Actor actor, int attackVal) {
        actor.setHealth(actor.health - attackVal);
        if (actor.health <= 0)
        {
            if (actor.actorType == ActorType.Player)
            {
                LoseGame();
            }
            else if (actor.actorType == ActorType.Opponent)
            {
                WinGame();
            }
        }
    }

}
