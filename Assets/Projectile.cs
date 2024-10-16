using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public static MathGameManager gameManager;

    void Start()
    {
        gameManager = MathGameManager.GetInstance();
    }

    void OnCollisionEnter(Collision collision)
    {
        bool isCorrect = collision.gameObject.CompareTag("CorrectAnswer");

        Renderer boxRenderer = collision.gameObject.GetComponent<Renderer>();
        if (boxRenderer != null)
        {
            boxRenderer.material.color = isCorrect ? Color.green : Color.red;
        }

        if (isCorrect)
        {
            gameManager.PlayCorrectAnswerSound();
            gameManager.GenerateMathProblem();
        }
        else if (collision.gameObject.CompareTag("WrongAnswer"))
        {
            gameManager.PlayWrongAnswerSound();
        }

        StartCoroutine(DestroyAfterDelay(collision.gameObject));
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(objectToDestroy);
    }
}