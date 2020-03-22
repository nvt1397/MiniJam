using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    List<Transform> points = new List<Transform>();
    Transform nearest;
    public GameObject monsterPrefab;
    GameObject monster;
    void Start()
    {

        spawnPoint = this.gameObject.transform;
        for(int i = 0; i < spawnPoint.childCount; i++)
        {
            points.Add(spawnPoint.GetChild(i));
        }
        monster = Instantiate(monsterPrefab) as GameObject;
        CalculateNearestPoint();

    }

    Transform CalculateNearestPoint()
    {   
        float min = Vector2.Distance(points[0].position, GameManager.player.transform.position);
        foreach (Transform p in points)
        {
            float distance = Vector2.Distance(p.position, GameManager.player.transform.position);
            if (distance < min)
            {
                nearest = p;
                min = distance;
            }
        }
        monster.transform.position = nearest.position;
        return nearest;
    }


    void Update()
    {
        
    }
}
