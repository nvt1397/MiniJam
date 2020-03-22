/*
 * https://github.com/GuyQuad/Custom-2D-Colliders
 */
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(ArcCollider2D))]
public class ArcCollider_Editor : Editor {
    
    ArcCollider2D ac;
    PolygonCollider2D polyCollider;
    Vector2 off;

    void OnEnable()
    {
        ac = (ArcCollider2D)target;

        polyCollider = ac.GetComponent<PolygonCollider2D>();
        if (polyCollider == null) {
            ac.gameObject.AddComponent<PolygonCollider2D>();
            polyCollider = ac.GetComponent<PolygonCollider2D>();
        }
        polyCollider.points = ac.getPoints(polyCollider.offset);
    }

    public override void OnInspectorGUI()
    {
        GUI.changed = false;
        DrawDefaultInspector();

        ac.advanced = EditorGUILayout.Toggle("Advanced", ac.advanced);
        if (ac.advanced)
        {
            ac.radius = EditorGUILayout.FloatField("Radius", ac.radius);
        }
        else
        {
            ac.radius = EditorGUILayout.Slider("Radius", ac.radius, 1, 25);
        }
        if (!ac.pizzaSlice)
        {
            if (ac.advanced)
            {
                ac.Thickness = EditorGUILayout.FloatField("Thickness", ac.Thickness);
            }
            else
            {
                ac.Thickness = EditorGUILayout.Slider("Thickness", ac.Thickness, 1, 25);
            }
        }

        if (GUI.changed || !off.Equals(polyCollider.offset))
        {
            polyCollider.points = ac.getPoints(polyCollider.offset);
        }
        off = polyCollider.offset;
    }
    
}