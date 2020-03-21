using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpin : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 anglesToRotate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }
    void Spin()
    {
        
        transform.Rotate(anglesToRotate * Time.deltaTime);
    }
    void Color()
    {
        
    }
}
