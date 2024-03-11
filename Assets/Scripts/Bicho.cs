using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicho : MonoBehaviour
{
    bool MoverseIzq;
    private GameObject mario;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoverseIzq == true)
        {
            transform.Translate(2 * Vector2.left * Time.deltaTime);
        }

        else
        {
            transform.Translate(2 * Vector2.right * Time.deltaTime);

        }

        if (transform.position.x > 12)
        {
            MoverseIzq = true;

        }

        else if (transform.position.x < -10)
        {
            MoverseIzq = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            MovimientoMario.hacersepequeño();
        }
    }
}
