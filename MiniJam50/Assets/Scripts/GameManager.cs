using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cannonBall;
    static GameObject _player;
    public static GameObject player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.Find("Ship");
            }
            return _player;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        PoolManager.instance.CreatePool(cannonBall, 10);
    }

}
