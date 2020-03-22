using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private LineRenderer lineRend;
    public Vector2 startPos;
    public Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    public void DrawLine()
    {
        lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, -1));
        lineRend.SetPosition(1, new Vector3(endPos.x, endPos.y, -1));
    }
    private void FixedUpdate()
    {
        DrawLine();
    }
}
