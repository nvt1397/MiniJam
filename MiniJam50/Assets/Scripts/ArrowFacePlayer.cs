using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFacePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPos;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer1();
    }

    public void facePlayer1()
    {
        Vector2 direction = new Vector2(playerPos.position.x - transform.position.x, playerPos.position.y - transform.position.y);
        transform.up = direction;
    }
}
