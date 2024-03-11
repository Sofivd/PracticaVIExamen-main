using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Setita : MonoBehaviour
{
    private GameObject mario;
    
    void Start()
    {
        mario = GameObject.FindGameObjectWithTag("mario");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "mario")
        {
            MovimientoMario.powerUp = true;
        }
    }

   
}
