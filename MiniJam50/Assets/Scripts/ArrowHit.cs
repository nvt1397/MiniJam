using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GOArrow;
    void Start()
    {
        GOArrow = GameObject.FindGameObjectWithTag("ArrowEnemy2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ArrowEnemy2")
        {
            Debug.Log("hit player");
            Destroy(collision.gameObject);
        }
    }
}
