using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRefresher : MonoBehaviour {

    Text scoreText; 

    void Awake () {
        scoreText = GetComponent<Text>();
        StartCoroutine("ScoreCounter");		
	}
	
    IEnumerator ScoreCounter()
    {
        while (true)
        {
            scoreText.text = "Score: " + GameManager.instance.GetScore();
            yield return null;
        }
    }
}
