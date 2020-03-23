using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_move_1 : MonoBehaviour
{
    public Color idleColor;
	public Color activeColor;

    public Transform[] target;
    public GameObject Sight;
    public GameObject ghost1;
	public GameObject ghost2;

    public float walkSpeed = 6f;
    public float runSpeed = 9f;

    private float speed;

    private GameManager GameManager;

    private int current;
    private float angle;
    private Renderer sight;
    private Vector3 direction;
    private bool haunted=false;
    private string[] room = {"target 16", "target 17", "target 18", "target 19"};

    float currentLockdownTime = 0f;
	float lockdownTime = 5f;

    void Start()
    {
        speed = walkSpeed*3;
        currentLockdownTime = lockdownTime;
        GameManager = FindObjectOfType<GameManager>();
        sight = Sight.GetComponent<Renderer>();
        direction = target[current].position - transform.position;
        angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
        transform.eulerAngles = Vector3.up * angle;
    }

    // Update is called once per frame
    void Update()
    {
        bool ghost1Seen = ghost1.GetComponent<Renderer>().bounds.Intersects(sight.bounds);
		bool ghost2Seen = ghost2.GetComponent<Renderer>().bounds.Intersects(sight.bounds);
        if(GameManager.getHumanState()!= -1){
            if ((ghost1Seen && !ghost1.GetComponent<Ghost_move1>().ghost1Intersect) || (ghost2Seen && !ghost2.GetComponent<Ghost_move2>().ghost2Intersect)){
                GameManager.setHumanState(2);
            }
        }

        sight.material.SetColor("_Color", (GameManager.getHumanState() == 2 || GameManager.getHumanState() == 3) ? activeColor : idleColor );

        if (GameManager.getHumanState() == 0) {
            speed = walkSpeed;
            if((direction.x == 0.0f && ((direction.z > 0 && target[current].position.z > transform.position.z)||(direction.z < 0 && target[current].position.z < transform.position.z)))||(direction.z==0.0f && ((direction.x > 0 && target[current].position.x > transform.position.x)||(direction.x < 0 && target[current].position.x < transform.position.x))))
            {
                if (direction.x == 0.0f){
                    if (direction.z > 0){
                        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.World);
                    }else{
                        transform.Translate(Vector3.back * speed * Time.deltaTime,Space.World);
                    }
                }else{
                    if (direction.x > 0){
                        transform.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
                    }else{
                        transform.Translate(Vector3.left * speed * Time.deltaTime,Space.World);
                    }
                }
            }
            else {
                current = (current+1)%target.Length;
                direction = target[current].position - target[current-1].position;
                angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
                transform.eulerAngles = Vector3.up * angle;
            }
        } else if (GameManager.getHumanState() == 1) {
            //Stun + Add FearGauge
            speed = 0;
            countdown();
        } else if (GameManager.getHumanState() == 2) {
            speed = runSpeed;
            //Run + Add FearGauge
            if (!haunted){
                current = (current+target.Length-1)%target.Length;
                direction = target[current].position - target[current+1].position;
                angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
                transform.eulerAngles = Vector3.up * angle;
                haunted = true;
            }
            if((direction.x == 0.0f && ((direction.z > 0 && target[current].position.z > transform.position.z) ||
                (direction.z < 0 && target[current].position.z < transform.position.z))) ||
                (direction.z == 0.0f && ((direction.x > 0 && target[current].position.x > transform.position.x) ||
                (direction.x < 0 && target[current].position.x < transform.position.x)))) {
                if (direction.x == 0.0f) {
                    if (direction.z > 0) {
                        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.World);
                    } else {
                        transform.Translate(Vector3.back * speed * Time.deltaTime,Space.World);
                    }
                } else {
                    if (direction.x > 0) {
                        transform.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
                    } else {
                        transform.Translate(Vector3.left * speed * Time.deltaTime,Space.World);
                    }
                }
            } else {
                foreach (string x in room) {
                    print(x + " " + target[current].name);
                    if (x.Equals(target[current].name)) {
                        speed = 0;
                        print("Max Kak Mai");
                        GameManager.setHumanState(3);
                        break;
                    }
                }
                if (GameManager.getHumanState() == 2) {
                    current = (current + target.Length - 1) % target.Length;
                    direction = target[current].position - target[current + 1].position;
                    angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
                    transform.eulerAngles = Vector3.up * angle;
                }
            }
        } else if(GameManager.getHumanState() == 3){
            currentLockdownTime -=  1 * Time.deltaTime;
			if(currentLockdownTime <= 0) {
				GameManager.setHumanState(0);
                currentLockdownTime = lockdownTime;
                haunted = false;
            }
        } else {
            if((direction.x == 0.0f && ((direction.z > 0 && target[current].position.z > transform.position.z)||(direction.z < 0 && target[current].position.z < transform.position.z)))||(direction.z==0.0f && ((direction.x > 0 && target[current].position.x > transform.position.x)||(direction.x < 0 && target[current].position.x < transform.position.x))))
            {
                if (direction.x == 0.0f){
                    if (direction.z > 0){
                        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.World);
                    }else{
                        transform.Translate(Vector3.back * speed * Time.deltaTime,Space.World);
                    }
                }else{
                    if (direction.x > 0){
                        transform.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
                    }else{
                        transform.Translate(Vector3.left * speed * Time.deltaTime,Space.World);
                    }
                }
            }
            else {
                current = (current+1)%target.Length;
                direction = target[current].position - target[current-1].position;
                angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
                transform.eulerAngles = Vector3.up * angle;
            }
        }

        
    }

    public Renderer getSight() {
        return sight;
    }

    public void countdown(){
 		currentLockdownTime -=  1 * Time.deltaTime;
		if(currentLockdownTime <= 0) {
			currentLockdownTime = 0;
            speed = walkSpeed;
			GameManager.setHumanState(0);
            currentLockdownTime = lockdownTime;
		}
	}
}
