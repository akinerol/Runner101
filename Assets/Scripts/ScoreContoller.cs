using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScoreContoller : MonoBehaviour
{

    public int maxScore = 2500;
    public float totalAnimationTime = 5;
    private float _firstThreshold = 1500;
    private float _secondThreshold = 1700;
    private float _thirdThreshold = 2000;
    public int target = 1500;

    private float _animationTime;
    public float displayScore;
    public Text scoreText;
    public GameObject Next, Win;

    public Slider scoreBar;

    public StarAnimations Star1, Star2, Star3;
    private bool _star1Reached, _star2Reached, _star3Reached;


    private Coroutine scoreCoroutine;

    void Start()
    {
        displayScore = 0;
        _animationTime = ((float)target / maxScore) * totalAnimationTime;

        _star1Reached = false;
        _star2Reached = false;
        _star3Reached = false;
        Win.SetActive(false);
        Next.SetActive(false);
    
        scoreCoroutine = StartCoroutine(ScoreCounter());

        PlayerController.MovementCompleted += OnMovementCompleted;
}

    private void OnMovementCompleted()
    {
        Debug.Log("movement completed");
    }

    void Update()
    {
        /* if (Input.GetKeyUp(KeyCode.KeypadMinus))          //stops the coroutine by minus key; this is additional feature;
         {
             StopCoroutine(scoreCoroutine);
         }
        */
    }


    IEnumerator ScoreCounter()
    {
        while (true)
        {
            if (displayScore < target)
            {
                displayScore += target * Time.deltaTime / _animationTime;
                scoreText.text = "Score: " + ((int)displayScore).ToString();
                scoreBar.value += target * Time.deltaTime / _animationTime;
            }

            if (displayScore >= _firstThreshold && _star1Reached == false)
            {
                _star1Reached = true;
                Star1.PlayStarAnimation();
                Win.SetActive(true);
                Next.SetActive(true);
            }
            if (displayScore >= _secondThreshold && _star2Reached == false)
            {
                _star2Reached = true;
                Star2.PlayStarAnimation();

            }
            if (displayScore >= _thirdThreshold && _star3Reached == false)
            {
                _star3Reached = true;
                Star3.PlayStarAnimation();

                yield break;            // this breaks the coroutine, and finishes the code;
            }

            // yield return new WaitForSeconds(0.0016f);           //this works with 60fps;
            yield return null;                                //or, null works for 1 empty frame;
        }


    }

}
