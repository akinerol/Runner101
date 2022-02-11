using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController Player;
    public MeteorCreator Meteor;
    public CameraController Camera;
    public Target Target;



    private void Start()
    {
        Player.StartRunning();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        PlayerController.MovementCompleted += OnMovementCompleted;          //class tan erisim saglaniyor

        Player.MovementCompletedLocal += OnMovementCompleted;
        Player.MidpointReachedLocal += OnMidpointReached;
        Meteor.AllMeteorsExploded += OnAllMeteorsExploded;


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

    private void OnAllMeteorsExploded()
    {
        Debug.Log("start collecting meteorites");
        Player.DidFinishMiniGame = true;
        Player.StartRunning();
    }


}
