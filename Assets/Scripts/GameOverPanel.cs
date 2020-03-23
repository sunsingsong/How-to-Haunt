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
    public RectTransform gameOverPanel;

	void Start() {
        GameManager = FindObjectOfType<GameManager>();
	}

    void Update() {
        Time.timeScale = 0;
        text.text = (GameManager.isWon()) ? "You Won!!" : "Game Over";
        score.text = "Score : " + GameManager.calculateScore().ToString(); //setScore -> getScore from GameManager
    }

    public void newGame(){
        gameOverPanel.gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
