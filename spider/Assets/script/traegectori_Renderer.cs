using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traegectori_Renderer : MonoBehaviour
{
    public GameObject bulletPrefab;
    private LineRenderer lineRendererComponent;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>(); 
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[100];

        lineRendererComponent.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.01f;

            points[i] = origin + speed * 5 * time + Physics.gravity * time * time / 2f;
        }

        lineRendererComponent.SetPositions(points);
    }
}
