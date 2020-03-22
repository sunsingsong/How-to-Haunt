using UnityEngine;

public class Furniture : MonoBehaviour {
	public Color idleColor = new Color(0.98f, 0.48f, 1.0f); // FB7CFF
	public Color activeColor = new Color(0.47f, 0.1f, 0.61f); // 781A9C
	public Color cooldownColor = new Color(0f, 0f, 0f);

	public GameObject ghost1;
	public GameObject ghost2;
	public GameObject Sight;
	public GameObject human;
	private Renderer sight;

	private bool isCollision1;
	private bool isCollision2;

	private float cooldown = 0;

	void Start(){
		sight = Sight.GetComponent<Renderer>();
		isCollision1 = false;
		isCollision2 = false;
	}

	void Update() {
		GameManager gameManager = FindObjectOfType<GameManager>();
		findSawFurniture();

		bool ghost1Intersect = ghost1.GetComponent<Renderer>().bounds.Intersects(GetComponent<Renderer>().bounds);
		if (ghost1Intersect) {
			ghost1.GetComponent<Ghost_move1>().ghost1Intersect = ghost1Intersect;
			isCollision1 = true;
		} else {
			if (isCollision1 && !ghost1Intersect) {
				ghost1.GetComponent<Ghost_move1>().ghost1Intersect = false;
				isCollision1 = false;
			}
		}
		bool ghost2Intersect = ghost2.GetComponent<Renderer>().bounds.Intersects(GetComponent<Renderer>().bounds);
		if (ghost2Intersect) {
			ghost2.GetComponent<Ghost_move2>().ghost2Intersect = ghost2Intersect;
			isCollision2 = true;
		} else {
			if (isCollision2) {
				ghost2.GetComponent<Ghost_move2>().ghost2Intersect = false;
				isCollision2 = false;
			}
		}

		if (cooldown > 0) {
			GetComponent<Renderer>().material.SetColor("_Color", cooldownColor);
		} else {
			GetComponent<Renderer>().material.SetColor("_Color", (ghost1Intersect || ghost2Intersect) && !(ghost1Intersect && ghost2Intersect) ? activeColor : idleColor);
		}

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

		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}
	}

	public bool isActivatable() {
		return cooldown <= 0;
	}

	public void activate() {
		if (cooldown > 0) return;
		cooldown = 12;
	}

	private void findSawFurniture() {
		GameManager gameManager = FindObjectOfType<GameManager>();

		if(sight != null){
			if(GetComponent<Renderer>().bounds.Intersects(sight.bounds)){
				 gameManager.sawFurnitures[name] = true;
			}
			else {
				gameManager.sawFurnitures[name] = false;
			}
		}
	}
}
