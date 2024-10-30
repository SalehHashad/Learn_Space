using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionImages
{
    public int ObjectsCount = 0;
    public Sprite Image;
}

public class QuestionImagesHandler : MonoBehaviour
{
    public static QuestionImagesHandler instance;
    public List<QuestionImages> questionsImages;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
