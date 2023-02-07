using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You have entered the healing area.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You are healing!");

            Color lerpedColor = Color.Lerp(new Color(0,1,0,0.2f), new Color(1,0,0,0.5f), Mathf.PingPong(Time.time, 1));
            GetComponent<Renderer>().material.color = lerpedColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You have exited the healing area!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You have collided with the box.");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You are healing!");

            Color lerpedColor = Color.Lerp(new Color(0, 1, 0, 0.2f), new Color(1, 0, 0, 0.5f), Mathf.PingPong(Time.time, 1));
            GetComponent<Renderer>().material.color = lerpedColor;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }*/
}
