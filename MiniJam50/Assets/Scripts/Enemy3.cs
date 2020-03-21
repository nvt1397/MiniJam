using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private Transform playerPos;
    public GameObject GOstar;
    private bool isAttacking;
    private bool isFollowing = false;
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
            StartCoroutine(Attack(10f));
        }
    }
    private IEnumerator Attack(float waitTime)
    {
        isAttacking = true;
        GameObject rgbClone;
        rgbClone = Instantiate(GOstar, playerPos.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        isAttacking = false;
        //Debug.Log("Attack");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            isFollowing = true;
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
