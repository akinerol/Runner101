using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StarAnimations : MonoBehaviour
{

    public GameObject Star;

    // Start is called before the first frame update
    void Start()
    {

        Star.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayStarAnimation()
    {
        Star.transform.localScale = new Vector3(2, 2, 2);
        Star.transform.DOScale(1, .5f);

        Star.GetComponent<Image>().DOFade(1, .5f);
    }
}
