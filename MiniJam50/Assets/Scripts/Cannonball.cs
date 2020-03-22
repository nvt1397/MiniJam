using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    Vector2 firePos;
    Vector2 target;
    Vector2 direction;
    [SerializeField]
    float speed = 10;
    float range;
    // Start is called before the first frame update

    public void setTarget(Vector2 firePos, Vector2 target, Vector2 direction, float range)
    {
        this.firePos = firePos;
        this.target = target;
        this.direction = direction;
        this.range = range;
    }

    void MoveAt()
    {
        float step = speed * Time.deltaTime;
        float remainDistance = Vector2.Distance(transform.position, target);
        
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        float scaleFactor = Mathf.Clamp(remainDistance / range, 0.001f, 1f);
        if (scaleFactor >= 0.5)
        {
            transform.localScale = new Vector3(1 + 1 - scaleFactor, 1 + 1 - scaleFactor, transform.localScale.z);
        }
        else if (scaleFactor < 0.5 && scaleFactor >= 0)
        {
            transform.localScale = new Vector3(1 +  scaleFactor, 1 +   scaleFactor, transform.localScale.z);
        }
        if (remainDistance < 0.0015f)
        {
            //play animation
            Invoke("Hide", 0.1f);
        }   
    }

    void Hide()
    {
        transform.localScale = new Vector3(1,1,1);
        gameObject.SetActive(false);
    }

    void Update()
    {
        MoveAt();
    }
}
