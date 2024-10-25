using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum EProblem { Addition , Subtraction , Multiplication , Divition }
public class MathProblemBTN : MonoBehaviour
{
    [SerializeField] EProblem problem;
    public static MathGameManager gameManager;

    private void Start()
    {
        gameManager = MathGameManager.GetInstance();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        if (!gameManager.gameStarted)
        {
            gameManager.eProblem = problem;
            gameManager.StartGame();
        }
    }
}
