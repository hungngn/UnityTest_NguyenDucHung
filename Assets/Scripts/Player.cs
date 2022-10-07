using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 800;
    private int point = 0;

    public GameObject redOrb;
    public GameObject greenOrb;
    public GameObject blueOrb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomColor();
    }

    void Update()
    {
        //Movement
        if(Input.GetKey("up"))
        {
            rb.AddForce(0, 0, moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey("left"))
        {
            rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey("right"))
        {
            rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
        }

        //10 point - win
        if(point==10)
        {
            SceneManager.LoadScene(3,LoadSceneMode.Single);
        }
        if(point==-1)
        {
            SceneManager.LoadScene(2,LoadSceneMode.Single);
        }
    }
        
    //GUI
    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.cyan;
        GUI.Label(new Rect(10, 10, 100, 20), "Point : "+point, myStyle);
    }

    //Random color for player
    private void RandomColor()
    {
        int index = Random.Range(0,2);
        if(index==0)
        {
            GetComponent<Renderer>().material.color = redOrb.GetComponent<Renderer>().material.color;
        }
        if(index==1)
        {
            GetComponent<Renderer>().material.color = greenOrb.GetComponent<Renderer>().material.color;
        }
        if(index==2)
        {
            GetComponent<Renderer>().material.color = blueOrb.GetComponent<Renderer>().material.color;
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Orb")
        {
            if(GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color)
            {
                ++point;
                RandomColor();
            }
            else point = -1;
        }
    }

}
