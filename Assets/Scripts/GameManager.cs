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
}
