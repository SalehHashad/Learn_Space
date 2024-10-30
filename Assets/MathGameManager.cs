using UnityEngine;
using TMPro;
using UnityEngine.UI; // Make sure to include this namespace for TextMeshPro

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
        }else if (eProblem == EProblem.Images)
        {
            if (ScoreIndexTMP != null)
                GenerateImagesMathProblem(-int.Parse(ScoreIndexTMP.text));
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
        Image questionImage = questionTextUI.GetComponentInChildren<Image>();
        questionImage.sprite = null; Debug.Log("hello - Addition");
        SetImageTransparency(0,questionImage);

        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a + b;

        questionTextUI.text = $"{a} + {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateSubtractionMathProblem(int score)
    {
        Image questionImage = questionTextUI.GetComponentInChildren<Image>();
        questionImage.sprite = null; Debug.Log("hello - Subtraction");
        SetImageTransparency(0,questionImage);

        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a - b;

        questionTextUI.text = $"{a} - {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateMultiplicationMathProblem(int score)
    {
        Image questionImage = questionTextUI.GetComponentInChildren<Image>();
        questionImage.sprite = null; Debug.Log("hello - Multiplication");
        SetImageTransparency(0,questionImage);

        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a * b;

        questionTextUI.text = $"{a} * {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateDivitionMathProblem(int score)
    {
        Image questionImage = questionTextUI.GetComponentInChildren<Image>();
        questionImage.sprite = null;
        SetImageTransparency(0, questionImage);

        Debug.Log("hello - Divition");
        float a = Random.Range(1, 10);
        float b = Random.Range(1, 10);
        answer = a / b;

        questionTextUI.text = $"{a} / {b}";
        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer); // Updated to SpawnBoxes
    }
    public void GenerateImagesMathProblem(int score)
    {
        questionTextUI.text = "";

        Debug.Log("hello - questionsImages");

        // Check if the QuestionImagesHandler or its questionsImages list is valid
        if (QuestionImagesHandler.instance == null || QuestionImagesHandler.instance.questionsImages == null)
        {
            Debug.LogError("QuestionImagesHandler or questionsImages list is missing!");
            return;
        }

        int index = Random.Range(0, QuestionImagesHandler.instance.questionsImages.Count);
        QuestionImages questionImages = QuestionImagesHandler.instance.questionsImages[index];

        // Ensure that the Image (Sprite) is not null before accessing it
        if (questionImages.Image != null)
        {
            answer = questionImages.ObjectsCount;

            Image questionImage = questionTextUI.GetComponentInChildren<Image>();
            if (questionImage != null)
            {
                print(questionImage.name);
                print(questionImages.Image.name);
                questionImage.sprite = questionImages.Image;
                SetImageTransparency(1.0f, questionImage);
            }
            else
            {
                Debug.LogWarning("QuestionImage component on questionTextUI is null.");
            }
        }
        else
        {
            Debug.LogWarning("The selected questionImages Image (Sprite) is null or has been destroyed.");
        }

        ScoreIndexTMP.text = $"{int.Parse(ScoreIndexTMP.text) + score}";
        boxSpawner.SpawnBoxes(answer);
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

    public void SetImageTransparency(float alpha,Image targetImage)
    {
        Color color = targetImage.color;
        color.a = Mathf.Clamp01(alpha); // Clamp between 0 and 1
        targetImage.color = color;
    }
}