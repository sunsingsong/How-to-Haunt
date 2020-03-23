using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//Timer
//Increase Fear Value From GameManager method -> increaseFearValue(float)
public class CountdownTimer : MonoBehaviour {

	public Text timeLabel;
    public Slider fearGauge;
    public GameManager GameManager;
    public RectTransform gameOverPanel;
    public GameObject Player1;
    public GameObject Player2;

    float currentTime = 0f;
	float startingTime = 150f;
    bool isStart = false ;
	void Start() {
        timeLabel.gameObject.SetActive(false);
        fearGauge.gameObject.SetActive(false);
        GameManager = FindObjectOfType<GameManager>();
         if(GameManager != null){
            initTimer();
        }
	}

    void Update() {
        countdownTime();
        showPanel();
        Player1.SetActive(GameManager.getHumanState() != -1);
        Player2.SetActive(GameManager.getHumanState() != -1);
        if(currentTime <= 91f && !isStart){
            isStart = true;
            fearGauge.gameObject.SetActive(true);
            timeLabel.gameObject.SetActive(true);
            GameManager.setHumanState(0);
        }
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
             GameManager.timeLeft = currentTime;
			 timeLabel.text = "Time "+currentTime.ToString("0");
			 if(currentTime <= 0) {
			 	currentTime = 0;
			 }
		}
    }

    private void showPanel(){
        if(currentTime == 0 || GameManager.isWon()){
          gameOverPanel.gameObject.SetActive (true);
        }
    }
	
}
