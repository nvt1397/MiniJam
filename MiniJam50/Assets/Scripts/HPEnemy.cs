using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HPEnemy : MonoBehaviour
{
    private float TotalHP, CurHP;
    private Vector3 localScale;
    public TextMeshPro tmpHP;
    public ParameterEnemy prmEnemy;
    void Start()
    {
        //Debug.Log(transform.position.x);
        //transform.localScale = new Vector3(transform.localScale.x - 0.2f, 1f, 1f);
        //transform.position = new Vector3(transform.position.x - 0.2f, 0, 0);
        prmEnemy = prmEnemy.GetComponent<ParameterEnemy>();
    }
    
    void Update()
    {
        TotalHP = prmEnemy.totalHP;
        CurHP = prmEnemy.curHP;
        localScale.x = CurHP * 0.3f / TotalHP;
        localScale.y = transform.localScale.y;
        localScale.z = transform.localScale.z;
        transform.localScale = localScale;
        tmpHP.SetText(CurHP + "/" + TotalHP);
            //new Vector3(transform.localScale.x - localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
