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
    public float speed;

    private int current;
    private float angle;
    private Renderer sight;
    private Vector3 direction;

    void Start()
    {
        sight = Sight.GetComponent<Renderer>();
        direction = target[current].position - transform.position;
        print(target[current].position);
        print(transform.position);
        angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
        transform.eulerAngles = Vector3.up * angle;
    }

    // Update is called once per frame
    void Update()
    {
        print(target[current].position.x);
        print(transform.position.x);
        print("direction.................................................");
        print(direction.x);
        if((direction.x==0.0f && ((direction.z > 0 && target[current].position.z > transform.position.z)||(direction.z < 0 && target[current].position.z < transform.position.z)))||(direction.z==0.0f && ((direction.x > 0 && target[current].position.x > transform.position.x)||(direction.x < 0 && target[current].position.x < transform.position.x))))
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

        bool ghost1Seen = ghost1.GetComponent<Renderer>().bounds.Intersects(sight.bounds);
		bool ghost2Seen = ghost2.GetComponent<Renderer>().bounds.Intersects(sight.bounds);

        sight.material.SetColor("_Color", (ghost1Seen && !ghost1.GetComponent<Ghost_move1>().ghost1Intersect) || (ghost2Seen && !ghost2.GetComponent<Ghost_move2>().ghost2Intersect) ? activeColor : idleColor);
    }

    public Renderer getSight() {
        return sight;
    }
}
