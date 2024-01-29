using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public float Speed => moveSpeed;

    private bool isCanMove = true;

    private void Update()
    {
        if (isCanMove)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
