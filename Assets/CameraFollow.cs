using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow1;
    public GameObject follow2;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX1 = Mathf.SmoothDamp(transform.position.x, follow1.transform.position.x, ref velocity.x, smoothTime);
        float posY1 = Mathf.SmoothDamp(transform.position.y, follow1.transform.position.y, ref velocity.y, smoothTime);
        float posX2 = Mathf.SmoothDamp(transform.position.x, follow2.transform.position.x, ref velocity.x, smoothTime);
        float posY2 = Mathf.SmoothDamp(transform.position.y, follow2.transform.position.y, ref velocity.y, smoothTime);

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
