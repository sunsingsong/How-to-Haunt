﻿using UnityEngine;

public class FurnitureScript : MonoBehaviour {
	public Color idleColor = new Color(0.98f, 0.48f, 1.0f); // FB7CFF
	public Color activeColor = new Color(0.47f, 0.1f, 0.61f); // 781A9C

	public GameObject ghost1;
	public GameObject ghost2;

	void Update() {
		Renderer renderer = GetComponent<Renderer>();

		bool ghost1Intersect = ghost1.GetComponent<Renderer>().bounds.Intersects(renderer.bounds);
		bool ghost2Intersect = ghost2.GetComponent<Renderer>().bounds.Intersects(renderer.bounds);

		renderer.material.SetColor("_Color", (ghost1Intersect || ghost2Intersect) && !(ghost1Intersect && ghost2Intersect) ? activeColor : idleColor);

		GameManager gameManager = FindObjectOfType<GameManager>();
    	if (ghost1Intersect && ghost2Intersect) {
    		if (gameManager.ghost1ObjectName == name) gameManager.ghost1ObjectName = "";
    		if (gameManager.ghost2ObjectName == name) gameManager.ghost2ObjectName = "";
    	} else {
    		if (ghost1Intersect) {
    			gameManager.ghost1ObjectName = name;
			} else if (gameManager.ghost1ObjectName == name) {
				gameManager.ghost1ObjectName = "";
			}
			if (ghost2Intersect) {
    			gameManager.ghost2ObjectName = name;
			} else if (gameManager.ghost2ObjectName == name) {
				gameManager.ghost2ObjectName = "";
			}
    	}
	}
}