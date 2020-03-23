using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Game manager singleton
// Store any game state needed here
// Find this object in nay script using `FindObjectOfType<GameManager>()`

public class GameManager : MonoBehaviour {
	
	public float time = 50f;
	public string ghost1ObjectName = "";
	public string ghost2ObjectName = "";
	public float timeLeft = 0f;
	public Dictionary<string,bool> sawFurnitures;

	private int humanState = 0; // 0 = Normal, 1 = Stun, 2 = Run, 3 = Lockdown 
	float currentGaugeDecreaseCountdownTime = 0f;
	float gaugeDecreaseCountdownTime = 10f;
	bool shouldCountdown = false;

	private float fearValue = 0f;

	void Start() {
		sawFurnitures = new Dictionary<string, bool>();
		for (int i = 1; i <= 12; i++) {
			sawFurnitures.Add("Furniture"+i,false);
		}
	}

	void Update() {
		if (shouldCountdown) {
			countdown();
		} else {
			currentGaugeDecreaseCountdownTime = gaugeDecreaseCountdownTime;
		}


	}

	public void increaseFearValue(float value){
		shouldCountdown = true;
		fearValue += value;
	}

	public void decreaseFearValue(float value){
		fearValue -= value;
	}

	public float getFearValue(){
		return fearValue;
	}

	public float getTime(){
		return time;
	}

	public bool activateFurniture(int ghostNumber){
		bool success = (ghostNumber == 1) ? sawFurnitures[ghost1ObjectName] : sawFurnitures[ghost2ObjectName];
		string furnitureName = (ghostNumber == 1) ? ghost1ObjectName : ghost2ObjectName;
		Furniture furniture = GameObject.Find(furnitureName).GetComponent<Furniture>();
		if (success && furniture.isActivatable()) {
			increaseFearValue(20);
			setHumanState(1);
			currentGaugeDecreaseCountdownTime = 10f;
		}
		furniture.activate();
		return success;
	}

	public int getHumanState(){
		return humanState;
	}

	public void setHumanState(int x){
		humanState = x;
	}

	public void countdown(){
		currentGaugeDecreaseCountdownTime -=  1 * Time.deltaTime;
		if(currentGaugeDecreaseCountdownTime <= 0) {
			currentGaugeDecreaseCountdownTime = 3f;
			decreaseFearValue(3);
		}
	}

	public int calculateScore() {
		return (int)fearValue * 10 + (int)timeLeft * 10;
	}

	public bool isWon(){
		print(fearValue);
		return fearValue >= 100f;
	}
}
