using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEnemy1 : MonoBehaviour
{
    private Transform playerPos;
    public GameObject GOCut;
    private bool isAttacking;
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
        float r = Mathf.Sqrt(Mathf.Pow((playerPos.position.x - transform.position.x), 2f) + Mathf.Pow((playerPos.position.y - transform.position.y), 2f));
        if (r <= 0.1f && !isAttacking)
        {
            StartCoroutine(Attack(0.5f));
        }
    }
    private IEnumerator Attack(float waitTime)
    {
        isAttacking = true;
        GameObject rgbClone;
        rgbClone = Instantiate(GOCut, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        isAttacking = false;
        Debug.Log("Attack");
    }
}
