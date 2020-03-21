using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_move1 : MonoBehaviour
{
    public GameObject Player1;
    public int speed;
    public bool ghost1Intersect;

    void Start()
    {
        ghost1Intersect=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(-1.0f, 0.0f, 0.0f), speed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D)) {
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(1.0f, 0.0f, 0.0f), speed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.W)) {
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(0.0f, 0.0f, 1.0f), speed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S)) {
            Player1.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(Player1.transform.position, Player1.transform.position + new Vector3(0.0f, 0.0f, -1.0f), speed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.E)) {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.activateFurniture(1);
        }
    }
}
