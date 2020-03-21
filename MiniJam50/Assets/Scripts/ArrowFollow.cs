using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPos;
    private Transform arrowPos;
    private Transform enemyPos;
    private GameObject GOArrow;
    private Vector3 dir;
    //public float speed;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
        enemyPos = GameObject.FindGameObjectWithTag("Enemy2").transform;
        arrowPos = GameObject.FindGameObjectWithTag("ArrowEnemy2").transform;
        GOArrow = GameObject.FindGameObjectWithTag("ArrowEnemy2");
        dir = (playerPos.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position,  dir, 3f * Time.deltaTime);
        transform.position += dir * Time.deltaTime * 3f;
        //transform.Translate(dir * 3f * Time.deltaTime);
    }

}
