﻿/*
 * https://github.com/GuyQuad/Custom-2D-Colliders
 */
#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Physics 2D/Arc Collider 2D")]

[RequireComponent(typeof(PolygonCollider2D))]
public class ArcCollider2D : MonoBehaviour {

    [Range(1, 25), HideInInspector]
    public float radius = 3;
    [Range(1, 25), HideInInspector]
    public float Thickness = 0.4f;
    [Range(10,90)]
    public int smoothness = 24;

    [Range(10, 360)]
    public int totalAngle = 360;

    [Range(0, 360)]
    public int offsetRotation = 0;

    [Header("Let there be Pizza")]
    public bool pizzaSlice;

    [HideInInspector]
    public bool advanced = false;
    
    Vector2 origin, center;
    
    public Vector2[] getPoints(Vector2 off)
    {
        List<Vector2> points = new List<Vector2>();

        origin = transform.localPosition;
        center = origin + off;
        
        float ang = offsetRotation;

        if (pizzaSlice && totalAngle % 360 != 0)
        {
            points.Add(center);
        }

        for (int i = 0; i <= smoothness; i++)
        {
            float x = radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            float y = radius * Mathf.Sin(ang * Mathf.Deg2Rad);

            points.Add(new Vector2(x, y));
            ang += (float)totalAngle/smoothness;
        }

        if (!pizzaSlice)
        {
            for (int i = 0; i <= smoothness; i++)
            {
                ang -= (float)totalAngle / smoothness;
                float x = (radius - Thickness) * Mathf.Cos(ang * Mathf.Deg2Rad);
                float y = (radius - Thickness) * Mathf.Sin(ang * Mathf.Deg2Rad);

                points.Add(new Vector2(x, y));
            }
        }

        if (pizzaSlice && totalAngle % 360 != 0) points.Add(center);

        return points.ToArray();
    }
}
#endif