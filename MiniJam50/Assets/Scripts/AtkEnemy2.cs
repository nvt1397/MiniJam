using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEnemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPos;
    public GameObject GOArrow;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        float r = Mathf.Sqrt(Mathf.Pow((playerPos.position.x - transform.position.x), 2f) + Mathf.Pow((playerPos.position.y - transform.position.y), 2f));
        if (r <= 1.5f && isChecking())
        {
            GameObject rgbClone;
            rgbClone = Instantiate(GOArrow, transform.position, Quaternion.identity);
        }
    }
    bool isChecking()
    {
        if (GameObject.FindGameObjectWithTag("ArrowEnemy2") != null)
        {
            return false;
        }
        return true;
    }
}
