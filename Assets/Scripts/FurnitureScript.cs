using UnityEngine;

public class FurnitureScript : MonoBehaviour {
	public Color idleColor = new Color(0.98f, 0.48f, 1.0f); // FB7CFF
	public Color activeColor = new Color(0.47f, 0.1f, 0.61f); // 781A9C

	public GameObject ghost1;
	public GameObject ghost2;
	public GameObject Sight;
	public GameObject human;
	private Renderer sight;
    public GameManager gameManager;
	private Renderer renderer;

	private bool isCollision1;
	private bool isCollision2;

	private int cooldown = 0;
	private bool lastFrameCollide1;
	private bool lastFrameCollide2;
	//Checks if ghost is in object last frame or not.

	void Start(){
		sight = Sight.GetComponent<Renderer>();
		isCollision1 = false;
		isCollision2 = false;
		lastFrameCollide1 = false;
		lastFrameCollide2 = false;
	}

	void Update() {
		gameManager = FindObjectOfType<GameManager>();
		renderer = GetComponent<Renderer>();
		findSawFurniture();

		bool ghost1Intersect = ghost1.GetComponent<Renderer>().bounds.Intersects(renderer.bounds) && cooldown == 0;
		if (ghost1Intersect) {
			ghost1.GetComponent<Ghost_move1>().ghost1Intersect = ghost1Intersect;
			isCollision1 = true;
		} else {
			if (isCollision1 && !ghost1Intersect) {
				ghost1.GetComponent<Ghost_move1>().ghost1Intersect = false;
				isCollision1 = false;
			}
		}
		bool ghost2Intersect = ghost2.GetComponent<Renderer>().bounds.Intersects(renderer.bounds) && cooldown == 0;
		if (ghost2Intersect) {
			ghost2.GetComponent<Ghost_move2>().ghost2Intersect = ghost2Intersect;
			isCollision2 = true;
		} else {
			if (isCollision2) {
				ghost2.GetComponent<Ghost_move2>().ghost2Intersect = false;
				isCollision2 = false;
			}
		}

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

		if (ghost1Intersect) {
			lastFrameCollide1 = true;
		} else if (lastFrameCollide1) {
			lastFrameCollide1 = false;
			cooldown = 1000;
		}

		if (ghost2Intersect) {
			lastFrameCollide2 = true;
		} else if (lastFrameCollide2) {
			lastFrameCollide2 = false;
			cooldown = 1000;
		}
		
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}
	}

	bool isActivatable() {
		return cooldown <= 0;
	}

	private void findSawFurniture(){
		if(sight != null){
			if(renderer.bounds.Intersects(sight.bounds)){
				 gameManager.sawFurnitures[name] = true;
				 Debug.Log(name+" TRUE");
			}
			else {
				gameManager.sawFurnitures[name] = false;
				Debug.Log(name+" FALSE");
			}
		}
	}
}
