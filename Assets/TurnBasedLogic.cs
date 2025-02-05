using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnBasedLogic : MonoBehaviour
{
    public enum PlayerTurn { Player1, Player2 }

    public PlayerTurn currentTurn = PlayerTurn.Player1;

    public TextMeshProUGUI turnText;
    public TMP_InputField wordInputField;
    public Button submitButton;

    public float turnDuration = 10f; 
    private float timer;
    public TextMeshProUGUI timerText;

    void Start()
    {
        timer = turnDuration; 
        UpdateUI();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime; 
            if (timerText != null)
            {
                timerText.text = "Time Left: " + Mathf.Ceil(timer) + "s";
            }
        }
        else
        {
            Debug.Log("Time Up! Switching turn...");
            EndTurn(); 
        }
    }



    void EndTurn()
    {
        if (currentTurn == PlayerTurn.Player1)
        {
            currentTurn = PlayerTurn.Player2;
            turnText.text = "Player 2s Turn";
        }
        else
        {
            currentTurn = PlayerTurn.Player1;
            turnText.text = "Player 1s Turn";
        }

        wordInputField.text = ""; 
        timer = turnDuration;

        Debug.Log($"Turn switched! {currentTurn}'s turn starts with {timer} seconds.");
    }


    public void SetTimerDuration(int duration)
    {
        turnDuration = duration;
        timer = duration;
    }

    public void OnSubmitWord()
    {
        if (string.IsNullOrWhiteSpace(wordInputField.text))
        {
            Debug.Log("Word cannot be empty!");
            return;
        }

        Debug.Log($"{currentTurn} Entered: {wordInputField.text}");


        wordInputField.text = "";

  
        EndTurn();
    }

    void UpdateUI()
    {
        if (currentTurn == PlayerTurn.Player1)
        {
            turnText.text = "Player 1s Turn";
            wordInputField.interactable = true; 
        }
        else
        {
            turnText.text = "Player 2s Turn";
            wordInputField.interactable = true;  
        }
    }
}
