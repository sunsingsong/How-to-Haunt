using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_move_1 : MonoBehaviour
{
    public Transform[] target;
    public float speed;

    private int current;
    private float angle;
    private Vector3 direction;

    void Start()
    {
        direction = target[current].position - transform.position;
        angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
        //transform.Rotate(direction * 10.0f, Space.World);
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
        else{
            current = (current+1)%target.Length;
            direction = target[current].position - target[current-1].position;
            angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg -90;
            transform.eulerAngles = Vector3.up * angle;
            //transform.Rotate(Vector3.up * 10.0f, Space.World);
        }
    }
}
