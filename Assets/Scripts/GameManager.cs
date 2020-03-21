using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Game manager singleton
// Store any game state needed here
// Find this object in nay script using `FindObjectOfType<GameManager>()`

public class GameManager : MonoBehaviour {
	
	public float time = 50f;
	public bool isWon = false;
	public string ghost1ObjectName = "";
	public string ghost2ObjectName = "";
	public Dictionary<string,bool> sawFurnitures;

	void Start() {
		sawFurnitures = new Dictionary<string, bool>();
		for (int i = 1; i <= 12; i++) {
			sawFurnitures.Add("Furniture"+i,false);
		}
	}

	private float fearValue = 0f;

	public void increaseFearValue(float value){
		fearValue += value;
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
		if (furniture && furniture.isActivatable()) {
			furniture.activate();
		}
		if (success) {
			increaseFearValue(15);
			// TODO: Stun?
		}
		return success;
	}
}
