using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//Timer
//Increase Fear Value From GameManager method -> increaseFearValue(float)
public class CountdownTimer : MonoBehaviour {

	public Text timeLabel;
    public GameManager GameManager;
    public RectTransform gameOverPanel;

    float currentTime = 0f;
	float startingTime = 150f;

	void Start() {
        GameManager = FindObjectOfType<GameManager>();
         if(GameManager != null){
            initTimer();
        }
	}

    void Update() {
        countdownTime();
    }

    private void initTimer() {
		if(timeLabel != null){
            startingTime = GameManager.getTime();
			currentTime = startingTime;
		}
	}

    private void countdownTime() {
        if(timeLabel != null){
			 currentTime -=  1 * Time.deltaTime;
			 timeLabel.text = "Time "+currentTime.ToString("0");
			 if(currentTime <= 0) {
			 	currentTime = 0;
                showPanel();
			 }
		}
    }

    private void showPanel(){
        gameOverPanel.gameObject.SetActive (true);
        SceneManager.LoadScene(0);
    }
	
}
