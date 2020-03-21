using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public GameObject enemy;
    private bool isFollowing = false;
    private GameObject player;
    private Animator animator;
    void Start()
    {
        animator = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            //Debug.Log("enemy follow player");
            if (Vector2.Distance(enemy.transform.position, player.transform.position) > stoppingDistance)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            Vector2 direction = new Vector2(player.transform.position.x - enemy.transform.position.x, player.transform.position.y - enemy.transform.position.y);
            enemy.transform.up = direction;
            animator.SetBool("isFollowing", true);
        }
        else
        {
            animator.SetBool("isFollowing", false);
        }
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
