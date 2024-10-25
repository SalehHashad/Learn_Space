using UnityEngine;
using TMPro; // Make sure to include this namespace for TextMeshPro

public class MathGameManager : MonoBehaviour
{
    public Canvas MathProblemButtons;
    public Canvas GameManageButtons;
    public EProblem eProblem;

    public MathProblemBTN problemBTN;
    public BoxSpawner boxSpawner;
    public TextMeshProUGUI questionTextUI;
    public TextMeshProUGUI timerTextUI;
    public TextMeshProUGUI ScoreIndexTMP ;
    public TextMeshProUGUI gameOverTextUI; // UI element for the game over message

    public float gameDuration = 20f;
    private float timer;
    public bool gameStarted = false;

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

    private float answer;


    void Update()
    {

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

    public void StartGame()
    {
        timer = gameDuration;
        gameStarted = true;

        if (MathProblemButtons != null)
            MathProblemButtons.gameObject.SetActive(false);
        else
            Debug.LogError("MathProblemButtons is not assigned!");

        if (eProblem == EProblem.Addition)
        {
            if (ScoreIndexTMP != null)
                GenerateAdditionMathProblem(-int.Parse(ScoreIndexTMP.text));
            else
                Debug.LogError("ScoreIndexTMP is not assigned!");
        }
        else if (eProblem == EProblem.Subtraction)
        {
            if (ScoreIndexTMP != null)
                GenerateSubtractionMathProblem(-int.Parse(ScoreIndexTMP.text));
            else
                Debug.LogError("ScoreIndexTMP is not assigned!");
        }
        else if (eProblem == EProblem.Multiplication)
        {
            if (ScoreIndexTMP != null)
                GenerateMultiplicationMathProblem(-int.Parse(ScoreIndexTMP.text));
            else
                Debug.LogError("ScoreIndexTMP is not assigned!");
        }else if (eProblem == EProblem.Divition)
        {
            if (ScoreIndexTMP != null)
                GenerateDivitionMathProblem(-int.Parse(ScoreIndexTMP.text));
            else
                Debug.LogError("ScoreIndexTMP is not assigned!");
        }

        if (GameManageButtons != null)
            GameManageButtons.gameObject.SetActive(true);
        else
            Debug.LogError("GameManageButtons is not assigned!");

        if (gameOverTextUI != null)
            gameOverTextUI.text = "";
        else
            Debug.LogError("gameOverTextUI is not assigned!");
    }


    public void GenerateAdditionMathProblem(int score)
    {
        Debug.Log("hello - Addition");
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a + b;

        questionTextUI.text = $"{a} + {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateSubtractionMathProblem(int score)
    {
        Debug.Log("hello - Subtraction");
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a - b;

        questionTextUI.text = $"{a} - {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateMultiplicationMathProblem(int score)
    {
        Debug.Log("hello - Multiplication");
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a * b;

        questionTextUI.text = $"{a} * {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateDivitionMathProblem(int score)
    {
        Debug.Log("hello - Divition");
        float a = Random.Range(1, 10);
        float b = Random.Range(1, 10);
        answer = a / b;

        questionTextUI.text = $"{a} / {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }

    void EndGame()
    {
        gameStarted = false;
        gameOverTextUI.text = "Game Over!";
        MathProblemButtons.gameObject.SetActive(true);
        foreach(ObjectAnswers objectAnswers in FindObjectsOfType<ObjectAnswers>())
        {
            Destroy(objectAnswers.gameObject);
        }
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