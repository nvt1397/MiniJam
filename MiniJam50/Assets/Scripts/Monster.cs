using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int hit = 3;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cannonball")
        {
            hit -= 1;
        }
    }
    // Start is called before the first frame update
    public void Spawn()
    {
        hit = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(hit == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
