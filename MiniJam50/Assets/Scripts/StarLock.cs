using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLock : MonoBehaviour
{
    private GameObject GOstar;
    private Rigidbody2D rgbPlayer;
    void Start()
    {
        GOstar = GameObject.FindGameObjectWithTag("StarEnemy3");
        rgbPlayer = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StarEnemy3")
        {
            rgbPlayer.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(Waiting(2f, collision));
        }
    }
    private IEnumerator Waiting(float time, Collider2D col)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("lock");
        rgbPlayer.constraints = RigidbodyConstraints2D.None;
        Destroy(col.gameObject);
    }
}
