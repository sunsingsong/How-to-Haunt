using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_move : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        if(Player1 && Player2)
         {
            //Processing Player1 inputs
            if (Input.GetKey(KeyCode.A))
            {
            //Player1.transform.position = new Vector3(Player1.transform.position.x - 0.05f, Player1.transform.position.y, Player1.transform.position.z);
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(-1.0f, 0.0f, 0.0f), speed*Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
            //Player1.transform.position = new Vector3(Player1.transform.position.x + 0.05f, Player1.transform.position.y, Player1.transform.position.z);
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(1.0f, 0.0f, 0.0f), speed*Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.W))
            {
            //Player1.transform.position = new Vector3(Player1.transform.position.x , Player1.transform.position.y , Player1.transform.position.z + 0.05f);
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(0.0f, 0.0f, 1.0f), speed*Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S))
            {
            //Player1.transform.position = new Vector3(Player1.transform.position.x , Player1.transform.position.y , Player1.transform.position.z - 0.05f);
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(0.0f, 0.0f, -1.0f), speed*Time.deltaTime));
            }
 
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
