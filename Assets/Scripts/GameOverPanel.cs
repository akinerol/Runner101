using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private ScoreContoller _scoreController;

    private void Start()
    {
        PlayerController.MovementCompleted += OnMovementCompleted;
    }

    private void OnMovementCompleted(int score)
    {
        StartCoroutine(StartGameOver(score));
    }

    private IEnumerator StartGameOver(int score)
    {
        yield return new WaitForSeconds(5);
        _scoreController.target = score;
        _scoreController.gameObject.SetActive(true);
    }
}
