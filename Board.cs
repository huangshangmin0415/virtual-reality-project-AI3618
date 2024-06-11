using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("boxes"))
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
        }
    }
    
    void FixedUpdate()
    {

    }
}
