using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_move2 : MonoBehaviour
{
    public GameObject Player2;
    public int speed;
    public bool ghost2Intersect;

    void Start()
    {
        ghost2Intersect=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player2)
        {
            //Processing Player2 inputs
            if (Input.GetKey(KeyCode.LeftArrow))
            {
            Player2.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player2.transform.position, Player2.transform.position + new Vector3(-1.0f, 0.0f, 0.0f), speed*Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
            Player2.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player2.transform.position, Player2.transform.position + new Vector3(1.0f, 0.0f, 0.0f), speed*Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
            Player2.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player2.transform.position, Player2.transform.position + new Vector3(0.0f, 0.0f, 1.0f), speed*Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
            Player2.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player2.transform.position, Player2.transform.position + new Vector3(0.0f, 0.0f, -1.0f), speed*Time.deltaTime));
            }
        }

    }
}

