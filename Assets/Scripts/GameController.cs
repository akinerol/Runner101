using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController Player;
    public MeteorCreator Meteor;
    public CameraController Camera;



    private void Start()
    {
        Player.StartRunning();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        Player.MovementCompletedLocal += OnMovementCompleted;               
        PlayerController.MovementCompleted += OnMovementCompleted;          //class tan erisim saglaniyor

        Player.MidpointReachedLocal += OnMidpointReached;
      
    }

    private void UnregisterEvents()
    {
        Player.MovementCompletedLocal -= OnMovementCompleted;
        PlayerController.MovementCompleted -= OnMovementCompleted;

        Player.MidpointReachedLocal -= OnMidpointReached;
    }

    private void OnMovementCompleted()
    {
        Debug.Log("movement completed gamecontroller");
    }

    private void OnMidpointReached()
    {
        
        Meteor.CreateMeteors();
        Camera.SwitchCamera();

        Debug.Log("midpoint reached gamecontroller");

    }
}
