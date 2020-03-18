using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game manager singleton
// Store any game state needed here
// Find this object in nay script using `FindObjectOfType<GameManager>()`

public class GameManager : MonoBehaviour {
	public int time = 347;

	public string ghost1ObjectName = "";
	public string ghost2ObjectName = "";
}
