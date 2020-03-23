using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//FearGauge
//Increase Fear Value From GameManager method -> increaseFearValue(float)
public class GameOverPanel : MonoBehaviour {

	public Button button;
    public Text text;
    public Text score;
    public GameManager GameManager;
	void Start() {
        GameManager = FindObjectOfType<GameManager>();
	}

    void Update() {
        Time.timeScale = 0;
        if(!GameManager.isWon()){
            score.gameObject.SetActive(false);
        }

        else {
            text.text = "Congratulation You Won!!";
            score.gameObject.SetActive(true);
            score.text = "Score :"; //setScore -> getScore from GameManager
        }
    }

    public void newGame(){
        SceneManager.LoadScene(0);
    }
}
