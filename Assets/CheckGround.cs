using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private DogController dog;

    // Start is called before the first frame update
    void Start()
    {
        dog = GetComponentInParent<DogController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.CompareTag("Ground"))
        {
            dog.ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
            dog.ground = false;
        //}
    }
}
