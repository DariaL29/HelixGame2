using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        Debug.Log(collision.transform.GetComponent<MeshRenderer>().material);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "M_Safe (Instance)")
        {
            //safe area
        }
        else if(materialName == "M_Unsafe (Instance)")
        {

            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            //  GameManager.gameOver = true;
        }
        else if (materialName == "M_Finish (Instance)")
        {

            GameObject.Find("GameManager").GetComponent<GameManager>().levelCompleted = true;
            //GameManager.levelComplited = true;
        }

    }
}
