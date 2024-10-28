using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public Vector3 spawnPosition;
    public int numberOfBoxes = 5;
    public float minDistanceBetweenBoxes = 2.0f; // Minimum allowed distance between boxes

    private List<GameObject> spawnedBoxes = new List<GameObject>();

    public void SpawnBoxes(int correctAnswer)
    {
        ClearBoxes();

        int correctBoxIndex = Random.Range(0, numberOfBoxes);

        for (int i = 0; i < numberOfBoxes; i++)
        {
            Vector3 position;
            bool isCorrectAnswer = (i == correctBoxIndex);
            int answer = isCorrectAnswer ? correctAnswer : GetRandomWrongAnswer(correctAnswer);

            do
            {
                position = GetRandomPositionNear(spawnPosition);
            }
            while (IsPositionTooClose(position));

            SpawnBoxAtPosition(answer, position, isCorrectAnswer);
        }
    }
    public void SpawnBoxes(float correctAnswer)
    {
        ClearBoxes();

        float correctBoxIndex = Random.Range(0, numberOfBoxes);

        for (int i = 0; i < numberOfBoxes; i++)
        {
            Vector3 position;
            bool isCorrectAnswer = (i == correctBoxIndex);
            float answer = isCorrectAnswer ? correctAnswer : GetRandomWrongAnswer(correctAnswer);

            do
            {
                position = GetRandomPositionNear(spawnPosition);
            }
            while (IsPositionTooClose(position));

            SpawnBoxAtPosition(answer, position, isCorrectAnswer);
        }
    }

    private bool IsPositionTooClose(Vector3 position)
    {
        foreach (GameObject box in spawnedBoxes)
        {
            if (Vector3.Distance(position, box.transform.position) < minDistanceBetweenBoxes)
            {
                return true; // Position is too close to an existing box
            }
        }
        return false; // Position is fine
    }

    private Vector3 GetRandomPositionNear(Vector3 center)
    {
        return center + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
    }

    private int GetRandomWrongAnswer(int correctAnswer)
    {
        int wrongAnswer;
        do
        {
            wrongAnswer = Random.Range(1, 20); // Adjust range as needed
        }
        while (wrongAnswer == correctAnswer);
        return wrongAnswer;
    }
    private float GetRandomWrongAnswer(float correctAnswer)
    {
        float wrongAnswer;
        do
        {
            wrongAnswer = Random.Range(1, 20); // Adjust range as needed
        }
        while (wrongAnswer == correctAnswer);
        return wrongAnswer;
    }

    void SpawnBoxAtPosition(int number, Vector3 position, bool isCorrectAnswer)
    {
        GameObject box = Instantiate(boxPrefab, position, Quaternion.identity);
        spawnedBoxes.Add(box);

        TextMeshProUGUI tmp = box.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = number.ToString();
        }

        // Assign the appropriate tag
        box.tag = isCorrectAnswer ? "CorrectAnswer" : "WrongAnswer";
    }
    void SpawnBoxAtPosition(float number, Vector3 position, bool isCorrectAnswer)
    {
        GameObject box = Instantiate(boxPrefab, position, Quaternion.identity);
        spawnedBoxes.Add(box);

        TextMeshProUGUI tmp = box.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = number.ToString();
        }

        // Assign the appropriate tag
        box.tag = isCorrectAnswer ? "CorrectAnswer" : "WrongAnswer";
    }


    private void ClearBoxes()
    {
        foreach (GameObject box in spawnedBoxes)
        {
            Destroy(box);
        }
        spawnedBoxes.Clear();
    }
}