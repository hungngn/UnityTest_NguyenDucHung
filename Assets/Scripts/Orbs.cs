using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    private 
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-10f,10f), 1, Random.Range(-1f,14f));
    }

   
    void Update()
    {
    
    }

    //Orb change position when touched by player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.transform.position = new Vector3(Random.Range(-10f,10f), 1, Random.Range(-1f,14f));
        }
    }   
}  
