using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cannonBall;


    // Start is called before the first frame update
    void Awake()
    {
        PoolManager.instance.CreatePool(cannonBall, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
