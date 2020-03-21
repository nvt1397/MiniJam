using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowExist : MonoBehaviour
{
    private bool isWaiting = true;
    public GameObject GOArrow;
    void Start()
    {
        //GOArrow = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //GOArrow = gameObject.GetComponent<GameObject>();
        deleteArrow();
    }
    private void deleteArrow()
    {
        if (!isWaiting)
        {
            //Debug.Log(GOArrow);
            Destroy(GOArrow);
        }
        StartCoroutine(Waiting(3f));
    }

    private IEnumerator Waiting(float waitTime)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        //Debug.Log(isWaiting);
    }

}
