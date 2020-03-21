using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    private Transform enemyPos;
    private Vector3 oldEnemyPos;
    public string enemyName;
    public float speed;
    public float stoppingDistance;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
        enemyPos = GameObject.FindGameObjectWithTag(enemyName).transform;
        oldEnemyPos = enemyPos.transform.position;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, playerPos.transform.position) > stoppingDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        }
        facePlayer1();
        float rFollow = Mathf.Sqrt(Mathf.Pow((playerPos.position.x - enemyPos.position.x), 2f) + Mathf.Pow((playerPos.position.y - enemyPos.position.y), 2f));
        if (rFollow > 2f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, oldEnemyPos, speed * Time.deltaTime);
            animator.SetBool("isFollowing", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public void facePlayer1()
    {
        Vector2 direction = new Vector2(playerPos.position.x - enemyPos.position.x, playerPos.position.y - enemyPos.position.y);
        enemyPos.transform.up = direction;
    }
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
