using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    Start,
    PlayerTurn,
    OpponentTurn,
    Fight,
    Won,
    Lost,
    Draw,
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
    public int sacrifice;
    public List<Card> cards;
    public TextMeshProUGUI healthTextUGUI;
    private string healthText;
    public TextMeshProUGUI sacrificeTextUGUI;
    private string sacrificeText;

    //Flag values for game logic
    public bool isCardDrawn = false;

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

    // public void setSacrificeText(string sacrificeText)
    // {
    //     this.sacrificeText = sacrificeText;
    //     this.sacrificeTextUGUI.text = string.Format(this.sacrificeText, 0);
    // }

//     public void setSacrifice(int sacrifice)
//     {
//         this.sacrifice = sacrifice;
//         this.sacrificeTextUGUI.text = string.Format(this.sacrificeText, this.sacrifice);
//     }
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public CardManager cardManager;
    public List<GameObject> playerPlaceholders;
    public List<GameObject> opponentPlaceholders;
    //public GameObject playerSacrificePile;
    // define a variable to hold the text object
    public TextMeshProUGUI gameText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI opponentHealthText;
    public int playerHealth = 10;
    public int opponentHealth = 15;
    public TextMeshProUGUI playerSacrificeText;
    public TextMeshProUGUI opponentSacrificeText;
    //public int playerSacrifice = 0;
    //public int opponentSacrifice = 0;
    public Actor player;
    public Actor opponent;
    public GameObject cardDeck;
    public AudioSource bellSound;
    
    private bool hasAttackedThisTurn = false;
    private bool opponentCardsDistributed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = new Actor();
        player.actorType = ActorType.Player;
        player.healthTextUGUI = playerHealthText;
        player.setHealthText("Health: {0}");
        player.setHealth(playerHealth);
        // player.sacrificeTextUGUI = playerSacrificeText;
        // player.setSacrificeText("Player Sacrifice: {0}");
        // player.setSacrifice(playerSacrifice);

        opponent = new Actor();
        opponent.actorType = ActorType.Opponent;
        opponent.healthTextUGUI = opponentHealthText;
        opponent.setHealthText("Enemy: {0}");
        opponent.setHealth(opponentHealth);
        // opponent.sacrificeTextUGUI = opponentSacrificeText;
        // opponent.setSacrificeText("Opponent Sacrifice: {0}");
        // opponent.setSacrifice(opponentSacrifice);

        gameState = GameState.Start;

        // Find all player placeholders in the scene
        playerPlaceholders = new List<GameObject>();
        foreach (GameObject placeholder in GameObject.FindGameObjectsWithTag("Card-placeholder"))
        {
            playerPlaceholders.Add(placeholder);
        }
        // Debug.Log("Found " + playerPlaceholders.Count + " player placeholders");

        //playerSacrificePile = GameObject.FindGameObjectsWithTag("sacrifice-placeholder")[0];

        // Find all opponent placeholders in the scene
        opponentPlaceholders = new List<GameObject>();
        foreach (GameObject placeholder in GameObject.FindGameObjectsWithTag("opponent-placeholder"))
        {
            opponentPlaceholders.Add(placeholder);
        }
        // Debug.Log("Found " + opponentPlaceholders.Count + " opponent placeholders");
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
                hasAttackedThisTurn = false;
                opponentCardsDistributed = false;
                /*
                // logic for cards in the sacrifice pile
                if (playerSacrificePile.GetComponent<CardHolder>().hasCard == true)
                {
                    Card sacrificedCard = playerSacrificePile.GetComponent<CardHolder>().heldCard.GetComponent<Card>();
                    if (sacrificedCard.isSummoned)
                    {
                        if (!sacrificedCard.isSacrificed)
                        {
                            player.sacrifice = playerSacrifice + sacrificedCard.healthVal + 1;
                            player.setSacrifice(playerSacrifice);
                            sacrificedCard.isSacrificed = true;
                        }
                    }
                    else
                    {
                        CardBehaviour sacrificedCardBehaviour = sacrificedCard.GetComponent<CardBehaviour>();
                        sacrificedCardBehaviour.cardplayed = false;
                        sacrificedCardBehaviour.grabInteractable.enabled = true;
                        sacrificedCardBehaviour.transform.position = Vector3.MoveTowards(
                            sacrificedCardBehaviour.transform.position, 
                            sacrificedCardBehaviour.originalPosition, 
                            sacrificedCardBehaviour.moveSpeed * Time.deltaTime);
                    }
                }
                
                // logic for cards in the playing area
                foreach (GameObject placeholder in playerPlaceholders)
                {
                    CardHolder cardHolder = placeholder.GetComponent<CardHolder>();
                    if (cardHolder.hasCard == true)
                    {
                        Card heldCard = cardHolder.heldCard.GetComponent<Card>();
                        CardBehaviour cardBehaviour = cardHolder.heldCard.GetComponent<CardBehaviour>();
                        bool isSummoned = heldCard.isSummoned;
                        bool hasAttacked = heldCard.hasAttacked;

                        // Summoning logic
                        if (!isSummoned)
                        {
                            int summonCost = heldCard.healthVal;
                            if (summonCost <= player.sacrifice)
                            {
                                player.sacrifice = player.sacrifice - summonCost;
                                player.setSacrifice(player.sacrifice);
                                heldCard.isSummoned = true;
                            }
                            else if (summonCost < player.sacrifice + player.health)
                            {
                                summonCost = summonCost - player.sacrifice;
                                player.sacrifice = 0;
                                player.health = player.health - summonCost;
                                player.setHealth(player.health);
                                player.setSacrifice(player.sacrifice);
                                heldCard.isSummoned = true;
                            }
                            else
                            {
                                cardBehaviour.cardplayed = false;
                                cardBehaviour.grabInteractable.enabled = true;
                                cardBehaviour.transform.position = Vector3.MoveTowards(
                                    cardBehaviour.transform.position, 
                                    cardBehaviour.originalPosition, 
                                    cardBehaviour.moveSpeed * Time.deltaTime);
                            }
                        }
                    }
                }
                */
                break;
            case GameState.OpponentTurn:
                cardDeck.GetComponent<DrawCardOnValidate>().drawCount = 0;
                player.isCardDrawn = false;

                if (!opponentCardsDistributed)
                {
                    DistributeOpponentCards();
                    EndTurn();
                }
                break;
            case GameState.Fight:
                Fight();
                if (player.health <= 0 && opponent.health <= 0)
                {
                    player.setHealth(0);
                    opponent.setHealth(0);
                    gameState = GameState.Draw;
                }
                else if (player.health <= 0 && opponent.health > 0)
                {
                    player.setHealth(0);
                    gameState = GameState.Lost;
                }
                else if (player.health > 0 && opponent.health <= 0)
                {
                    opponent.setHealth(0);
                    gameState = GameState.Won;
                }
                else
                {
                    EndTurn();
                }
                break;
            case GameState.Won:
                WinGame();
                break;
            case GameState.Lost:
                LoseGame();
                break;
        }
    }

    public void StartGame()
    {
        gameState = GameState.PlayerTurn;
        // set the text to "Player's turn"
        gameText.text = "Player's turn";
        bellSound.Play();
        //gameText.rectTransform.anchoredPosition = new Vector2(gameText.rectTransform.anchoredPosition.x, gameText.rectTransform.anchoredPosition.y);
    }

    public void EndTurn()
    {
        if (gameState == GameState.OpponentTurn || gameState == GameState.PlayerTurn || gameState == GameState.Fight)
        {
            StartCoroutine(SwitchTurns());
        }
    }

    private IEnumerator SwitchTurns()
    {
        //Debug.Log("switching turns");
        if (gameState == GameState.PlayerTurn)
        {
            gameState = GameState.OpponentTurn;
            // set the text to "Oponent's turn"
            gameText.text = "Opponent's turn";
        }
        else if (gameState == GameState.OpponentTurn)
        {
            yield return new WaitForSeconds(2f);
            gameState = GameState.Fight;
            // set the text to "Fight!"
            gameText.text = "Fight!";
        }
        else if (gameState == GameState.Fight)
        {
            yield return new WaitForSeconds(2f);
            gameState = GameState.PlayerTurn;
            // set the text to "Player's turn"
            gameText.text = "Player's turn";
        }
    }

    public void LoseGame()
    {
        gameState = GameState.Lost;
        gameText.text = "Game over";
        //gameText.rectTransform.anchoredPosition = new Vector2(gameText.rectTransform.anchoredPosition.x, -231);
    }

    void WinGame()
    {
        gameState = GameState.Won;
        gameText.text = "You won!";
        //gameText.rectTransform.anchoredPosition = new Vector2(gameText.rectTransform.anchoredPosition.x, -231);
    }

    void DrawGame()
    {
        gameState = GameState.Draw;
        gameText.text = "Draw!";
        //gameText.rectTransform.anchoredPosition = new Vector2(gameText.rectTransform.anchoredPosition.x, -231);
    }

    private void DistributeOpponentCards()
    {
        foreach (GameObject placeholder in opponentPlaceholders)
        {
            OpponentCardHolder oppCardHolder = placeholder.GetComponent<OpponentCardHolder>();
            Debug.Log("Opponent cardHolder");
            if (!oppCardHolder.hasCard)
            {
                Debug.Log("No card on opponent placeholder");
                int instantiateCard = Random.Range(0, 2);
                if (instantiateCard == 1)
                {
                    // Create a card
                    GameObject card = Instantiate(cardManager.DrawCard());
                    // Place the card on the free placeholder
                    card.transform.SetParent(placeholder.transform);
                    card.transform.localPosition = Vector3.zero;
                }
            }
        }
        /*
        int numberOfCards = Random.Range(1, 4); // Distribute between 1 and 4 cards

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
            */
        opponentCardsDistributed = true;
        Debug.Log("Cards distributed");
    }

    
    private void Fight() {

        // Enumerate player cards
        List<GameObject> playerCards = new List<GameObject>();
        foreach (GameObject placeholder in playerPlaceholders)
        {
            CardHolder cardHolder = placeholder.GetComponent<CardHolder>();
            if (cardHolder.hasCard)
            {
                playerCards.Add(cardHolder.heldCard);
            }
            else
            {
                playerCards.Add(null);
            }
        }

        // Enumerate opponent cards
        List<GameObject> opponentCards = new List<GameObject>();
        foreach (GameObject placeholder in opponentPlaceholders)
        {
            OpponentCardHolder oppCardHolder = placeholder.GetComponent<OpponentCardHolder>();
            if (oppCardHolder.hasCard)
            {
                opponentCards.Add(oppCardHolder.heldCard);
            }
            else
            {
                opponentCards.Add(null);
            }
        }

        // Fight
        if (!hasAttackedThisTurn)
        {
            for (int i = 0; i < 4; i++)
            {
                if (playerCards[i] != null && opponentCards[i] != null)
                {
                    Card playerCard = playerCards[i].GetComponent<Card>();
                    Card opponentCard = opponentCards[i].GetComponent<Card>();
                    playerCard.AttackSound(); 
                    opponentCard.AttackSound();
                    playerCard.healthVal -= opponentCard.attackVal;
                    opponentCard.healthVal -= playerCard.attackVal;
                    if (playerCard.healthVal <= 0)
                    {
                        player.health += playerCard.healthVal;
                        player.setHealth(player.health);
                        playerCard.healthVal = 0;
                        playerCard.healthText.color = Color.red;
                        playerCards[i] = null;
                        playerCard.Delete();
                        //playerPlaceholders[i].GetComponent<CardHolder>().hasCard = false;
                        //playerPlaceholders[i].GetComponent<CardHolder>().heldCard = null;
                    }
                    if (opponentCard.healthVal <= 0)
                    {
                        opponent.health += opponentCard.healthVal;
                        opponent.setHealth(opponent.health);
                        opponentCard.healthVal = 0;
                        opponentCard.healthText.color = Color.red;
                        opponentCards[i] = null;
                        opponentCard.Delete(); 
                        //opponentPlaceholders[i].GetComponent<OpponentCardHolder>().hasCard = false;
                        //opponentPlaceholders[i].GetComponent<OpponentCardHolder>().heldCard = null;
                    }
                }
                else if (playerCards[i] != null && opponentCards[i] == null)
                {
                    Card playerCard = playerCards[i].GetComponent<Card>();
                    playerCard.AttackSound();
                    opponent.health -= playerCard.attackVal;
                    opponent.setHealth(opponent.health);
                }
                else if (playerCards[i] == null && opponentCards[i] != null)
                {
                    Card opponentCard = opponentCards[i].GetComponent<Card>();
                    opponentCard.AttackSound();
                    player.health -= opponentCard.attackVal;
                    player.setHealth(player.health);
                }
            }
        }
        hasAttackedThisTurn = true;
        return;

        /*
        // Calculate the total attack value of all opponent's cards
        int totalAttack = 0;
        foreach (GameObject placeholder in opponentPlaceholders)
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

        actor.setHealth(actor.health - attackVal);
        if (actor.health <= 0)
        {
            if (actor.actorType == ActorType.Player)
            {
                gameState = GameState.Lost;
            }
            else if (actor.actorType == ActorType.Opponent)
            {
                gameState = GameState.Won;
            }
        }
        */
    }


}
