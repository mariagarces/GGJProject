using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag.Equals("Pome"))
        {
            Debug.Log("si");
        }
    }
}
