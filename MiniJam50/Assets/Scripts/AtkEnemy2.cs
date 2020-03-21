﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEnemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPos;
    public GameObject GOArrow;
    private bool isAttacking;
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
        float r = Mathf.Sqrt(Mathf.Pow((playerPos.position.x - transform.position.x), 2f) + Mathf.Pow((playerPos.position.y - transform.position.y), 2f));
        if (r <= 1.5f && !isAttacking)
        {
            StartCoroutine(Attack(1.75f));
        }
    }
    private IEnumerator Attack(float waitTime)
    {
        isAttacking = true;
        GameObject rgbClone;
        rgbClone = Instantiate(GOArrow, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        isAttacking = false;
        Debug.Log("Attack");
    }
}
