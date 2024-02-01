using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    List<Vector2> edgeList = new List<Vector2>();

    private bool isCanCollision;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void FixedUpdate()
    {
        if (isCanCollision)
        {
            SetCollider();
        }
    }

    private void SetCollider()
    {
        if (edgeList.Count != 0)
        {
            edgeList.Clear();
        }

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 point = lineRenderer.GetPosition(i);
            edgeList.Add(point);
        }

        edgeCollider.SetPoints(edgeList);
    }

    public void OnCollider()
    {
        isCanCollision = true;
        edgeCollider.enabled = true;
    }

    public void OffCollider()
    {
        isCanCollision = false;
        edgeCollider.enabled = false;
    }
}
