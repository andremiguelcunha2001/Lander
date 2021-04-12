using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI fueltxt;

    [SerializeField]
    float fuel = 100f;

    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 5f;

    

    void Update()
    {
        //Movimento
        if (fuel > 0) //Fuel
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Time.deltaTime);
                fuel -= 10f * Time.deltaTime;

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                fuel -= 5f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                fuel -= 5f * Time.deltaTime;
            }
            Debug.Log(fuel);
        }

        fueltxt.text = "fuel = " + System.Convert.ToInt32(fuel).ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Aterrei");
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs( transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("...mas explodi");
            }
        }else
        {
            Debug.Log("Explodi");
        }
    }

    
}
