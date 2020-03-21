using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Transform playerPos;
    public GameObject GOCut;
    private bool isAttacking;
    private bool isFollowing = false;
    private GameObject player;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
    }
    
    void Update()
    {
        createArrow();
    }
    void createArrow()
    {
        if (isFollowing && !isAttacking)
        {
            StartCoroutine(Attack(1f));
        }
    }
    private IEnumerator Attack(float waitTime)
    {
        isAttacking = true;
        GameObject rgbClone;
        rgbClone = Instantiate(GOCut, transform.position, Quaternion.identity);
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
