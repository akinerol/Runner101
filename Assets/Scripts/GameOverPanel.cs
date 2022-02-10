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

    private void OnMovementCompleted()
    {
        StartCoroutine(StartGameOver());
    }

    private IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(5);
        _scoreController.gameObject.SetActive(true);
    }
}
