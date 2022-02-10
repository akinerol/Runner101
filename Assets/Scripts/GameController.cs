using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController Player;


    private void Start()
    {
        Player.StartRunning();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        Player.MovementCompletedLocal += OnMovementCompleted;               
        PlayerController.MovementCompleted += OnMovementCompleted;          //class tan erisim saglaniyor
    }

    private void UnregisterEvents()
    {
        Player.MovementCompletedLocal -= OnMovementCompleted;
        PlayerController.MovementCompleted -= OnMovementCompleted;

    }
    private void OnMovementCompleted()
    {
        Debug.Log("movement completed gamecontroller");
    }


}
