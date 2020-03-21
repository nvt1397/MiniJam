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
    //public float speed;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
        enemyPos = GameObject.FindGameObjectWithTag("Enemy2").transform;
        arrowPos = GameObject.FindGameObjectWithTag("ArrowEnemy2").transform;
        GOArrow = GameObject.FindGameObjectWithTag("ArrowEnemy2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,  playerPos.transform.position, 1f * Time.deltaTime);
        
    }

}
