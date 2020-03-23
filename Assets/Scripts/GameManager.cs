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
	public Dictionary<string,bool> sawFurnitures;
	private int humanState; // 0=Normal, 1=Stun, 2=Run
	float currentTime = 0f;
	float startingTime = 10f;
	bool shouldCountdown = false;

	void Start() {
		humanState = 0;
		sawFurnitures = new Dictionary<string, bool>();
		for (int i = 1; i <= 12; i++) {
			sawFurnitures.Add("Furniture"+i,false);
		}
	}

	void Update(){
		if(shouldCountdown){
			countdown();
		}
		else {
			currentTime = startingTime;
		}
	}

	private float fearValue = 100f;

	public void increaseFearValue(float value){
		shouldCountdown = true;
		fearValue += value;
	}

	public void decreaseFearValue(float value){
		fearValue -= value;
		//shouldCountdown = false;
	}

	public float getFearValue(){
		return fearValue;
	}

	public float getTime(){
		return time;
	}

	public bool activateFurniture(int ghostNumber){
		bool success = (ghostNumber == 1) ? sawFurnitures[ghost1ObjectName] : sawFurnitures[ghost2ObjectName];
		string name = (ghostNumber == 1) ? ghost1ObjectName : ghost2ObjectName;
		Furniture furniture = GameObject.Find(name).GetComponent<Furniture>();
		if (success && furniture.isActivatable()) {
			increaseFearValue(15);
			setHumanState(1);
			currentTime = 10f;
		}
		if (furniture.isActivatable()) {
			furniture.activate();
		}
		return success;
	}

	public int getHumanState(){
		return humanState;
	}

	public void setHumanState(int x){
		humanState=x;
	}

	public void countdown(){
 			 currentTime -=  1 * Time.deltaTime;
			 if(currentTime <= 0) {
				 currentTime = 3f;
				 decreaseFearValue(2);
			 }
	}

	public bool isWon(){
		return fearValue >= 99f;
	}
}
