using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_move : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    // Update is called once per frame
    void Update()
    {
        if(Player1 && Player2)
         {
             //Processing Player1 inputs
             if (Input.GetKey(KeyCode.A))
             {
                Player1.transform.position = new Vector3(Player1.transform.position.x - 0.5f, Player1.transform.position.y, Player1.transform.position.z);
             }
             if (Input.GetKey(KeyCode.D))
             {
                Player1.transform.position = new Vector3(Player1.transform.position.x + 0.5f, Player1.transform.position.y, Player1.transform.position.z);
             }
             if (Input.GetKey(KeyCode.W))
             {
                Player1.transform.position = new Vector3(Player1.transform.position.x , Player1.transform.position.y , Player1.transform.position.z + 0.5f);
             }
             if (Input.GetKey(KeyCode.S))
             {
                Player1.transform.position = new Vector3(Player1.transform.position.x , Player1.transform.position.y , Player1.transform.position.z - 0.5f);
             }
 
             //Processing Player2 inputs
             if (Input.GetKey(KeyCode.LeftArrow))
             {
                Player2.transform.position = new Vector3(Player2.transform.position.x - 0.5f, Player2.transform.position.y, Player2.transform.position.z);
             }
             if (Input.GetKey(KeyCode.RightArrow))
             {
                Player2.transform.position = new Vector3(Player2.transform.position.x + 0.5f, Player2.transform.position.y, Player2.transform.position.z);
             }
             if (Input.GetKey(KeyCode.UpArrow))
             {
                Player2.transform.position = new Vector3(Player2.transform.position.x , Player2.transform.position.y, Player2.transform.position.z + 0.5f);
             }
             if (Input.GetKey(KeyCode.DownArrow))
             {
                Player2.transform.position = new Vector3(Player2.transform.position.x , Player2.transform.position.y, Player2.transform.position.z - 0.5f);
             }
        }    
    }
}
