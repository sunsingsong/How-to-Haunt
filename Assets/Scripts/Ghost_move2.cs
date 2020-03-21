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
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightShift)) {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.activateFurniture(2);
        }
    }
}

