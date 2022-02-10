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
        StartCoroutine(StartMovement());
    }

    private IEnumerator StartMovement()
    {
        yield return new WaitForSeconds(5);
        _scoreController.gameObject.SetActive(true);
    }
}
