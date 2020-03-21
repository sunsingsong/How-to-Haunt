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
        angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
        transform.eulerAngles = Vector3.up * angle;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed*Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
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
