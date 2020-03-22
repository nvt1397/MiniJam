using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutHit : MonoBehaviour
{
    private GameObject GOCut;
    void Start()
    {
        GOCut = GameObject.FindGameObjectWithTag("CutEnemy1");
    }
    
    void Update()
    {

    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CutEnemy1")
        {
            StartCoroutine(Waiting(0.5f, collision));
        }
    }
    private IEnumerator Waiting(float time, Collider2D col)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("cut hit");
        Destroy(col.gameObject);
    }
}
