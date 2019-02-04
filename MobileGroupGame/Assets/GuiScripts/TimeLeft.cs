using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour {
    public int timeLeft = 5;
    public Text countdownText;
	

    void Start()
    {
        StartCoroutine("LoseTime");
    }

    void Update()
    {
        countdownText.text = ("Time Left = " + timeLeft);

        if (timeLeft <=0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            SceneManager.LoadScene("LoseScreen");

        }
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
