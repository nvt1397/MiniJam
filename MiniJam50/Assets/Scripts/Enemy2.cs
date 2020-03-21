using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPos;
    public GameObject GOArrow;
    private bool isAttacking;
    private bool isFollowing = false;
    private GameObject player;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        createArrow();
    }
    void createArrow()
    {
        if (isFollowing && !isAttacking)
        {
            StartCoroutine(Attack(1.5f));
        }
    }
    private IEnumerator Attack(float waitTime)
    {
        isAttacking = true;
        GameObject rgbClone;
        rgbClone = Instantiate(GOArrow, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        isAttacking = false;
        //Debug.Log("Attack");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            isFollowing = true;
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            isFollowing = false;
        }
    }
}
