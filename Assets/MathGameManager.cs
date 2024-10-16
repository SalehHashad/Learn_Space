using UnityEngine;
using TMPro; // Make sure to include this namespace for TextMeshPro

public class MathGameManager : MonoBehaviour
{

    public BoxSpawner boxSpawner;
    public TextMeshProUGUI questionTextUI;
    public TextMeshProUGUI timerTextUI;
    public TextMeshProUGUI gameOverTextUI; // UI element for the game over message

    private float gameDuration = 20f;
    private float timer;
    private bool gameStarted = false;

    public AudioClip correctAnswerClip;
    public AudioClip wrongAnswerClip;
    private AudioSource audioSource;

    private static MathGameManager instance;

    public static MathGameManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private int answer;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !gameStarted)
        {
            StartGame();
        }

        if (gameStarted && timer > 0)
        {
            timer -= Time.deltaTime;
            timerTextUI.text = "Time Left: " + Mathf.CeilToInt(timer).ToString();
        }
        else if (gameStarted && timer <= 0)
        {
            EndGame();
        }
    }

    void StartGame()
    {

        timer = gameDuration;
        gameStarted = true;
        GenerateMathProblem(); // Start the first math problem
        gameOverTextUI.text = ""; // Clear the game over text
    }

    public void GenerateMathProblem()
    {
        Debug.Log("hello");
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a + b;

        questionTextUI.text = $"{a} + {b}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }

    void EndGame()
    {
        gameStarted = false;
        gameOverTextUI.text = "Game Over!";
        // Additional end-of-game logic can be added here
    }

    public void PlayCorrectAnswerSound()
    {
        audioSource.PlayOneShot(correctAnswerClip);
    }

    public void PlayWrongAnswerSound()
    {
        audioSource.PlayOneShot(wrongAnswerClip);
    }
}