using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Camera cam;
    

    float minCamSize = 5f;

    float maxCamSize = 20f;
    Vector2 velocity;
    float smoothTimeX;
    float smoothTimeY;
    void Start()
    {
        target = GameObject.Find("Ship").GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }
    void Follow()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    public void ZoomOut()
    {
        cam.orthographicSize += 10 * Time.deltaTime;
        if (cam.orthographicSize > maxCamSize)
        {
            cam.orthographicSize = maxCamSize; // Min size 
        }
    }
    public void ZoomIn()
    {
        cam.orthographicSize -= 10 * Time.deltaTime;
        if (cam.orthographicSize < maxCamSize)
        {
            cam.orthographicSize = minCamSize; // Min size 
        }
    }

    void LateUpdate()
    {
        Follow();

    }
}
