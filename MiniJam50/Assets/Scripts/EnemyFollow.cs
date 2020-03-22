using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public ParameterEnemy prmEnemy;
    private float speed;
    private float stoppingDistance;
    public GameObject enemy;
    private bool isFollowing = false;
    private GameObject player;
    private Animator animator;
    private bool isMoving = false;
    void Start()
    {
        animator = enemy.GetComponent<Animator>();
        prmEnemy = prmEnemy.GetComponent<ParameterEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = prmEnemy.speed;
        stoppingDistance = prmEnemy.stoppingDistance;
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
            if (!isMoving)
            {
                StartCoroutine(RandomMove());
            }
            else
            {
                StopCoroutine(RandomMove());
            }
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
    private IEnumerator RandomMove()
    {
        isMoving = true;
        Vector3 dir = Random.insideUnitCircle * 1.5f;
        yield return new WaitForSeconds(2f);
        Vector2 direction = new Vector2(dir.x - enemy.transform.position.x, dir.y - enemy.transform.position.y);
        enemy.transform.up = direction;
        //Debug.Log(dir);
        float i = 0.0f;
        float rate = 1f * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            enemy.transform.position = Vector2.Lerp(enemy.transform.position, dir, speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }
}
