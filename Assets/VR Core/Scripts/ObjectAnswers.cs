using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectAnswers : MonoBehaviour
{
    public static MathGameManager gameManager;

    void Start()
    {
        Button btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(OnButtonClicked);
        gameManager = MathGameManager.GetInstance();
    }
    void OnButtonClicked()
    {
        bool isCorrect = this.gameObject.CompareTag("CorrectAnswer");

        Renderer boxRenderer = this.gameObject.GetComponent<Renderer>();
        if (boxRenderer != null)
        {
            boxRenderer.material.color = isCorrect ? Color.green : Color.red;
        }

        if (isCorrect)
        {
            gameManager.PlayCorrectAnswerSound();

            StartCoroutine(CorrectAsnwer());

        }
        else if (this.gameObject.CompareTag("WrongAnswer"))
        {
            gameManager.PlayWrongAnswerSound();
        }

        StartCoroutine(DestroyAfterDelay(this.gameObject));
        //Destroy(gameObject);
    }
    IEnumerator DestroyAfterDelay(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(objectToDestroy);
    }
    IEnumerator CorrectAsnwer()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameManager.eProblem == EProblem.Addition)
            gameManager.GenerateAdditionMathProblem(1);
        else if (gameManager.eProblem == EProblem.Subtraction)
            gameManager.GenerateSubtractionMathProblem(1);
        else if (gameManager.eProblem == EProblem.Multiplication)
            gameManager.GenerateMultiplicationMathProblem(1);
        else if (gameManager.eProblem == EProblem.Divition)
            gameManager.GenerateDivitionMathProblem(1);
    }
}
