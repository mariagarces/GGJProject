using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow1;
    public GameObject follow2;
    public Vector2 minCamPos, maxCamPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX1 = follow1.transform.position.x;
        float posY1 = follow1.transform.position.y;
        float posX2 = follow2.transform.position.x;
        float posY2 = follow2.transform.position.y;

        if (posX1 < posX2)
        {
            transform.position = new Vector3(
            Mathf.Clamp(posX2, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY2, minCamPos.y, maxCamPos.y),
            transform.position.z);
        }
        else
        {
            transform.position = new Vector3(
            Mathf.Clamp(posX1, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY1, minCamPos.y, maxCamPos.y),
            transform.position.z);
        }       
    }
}
