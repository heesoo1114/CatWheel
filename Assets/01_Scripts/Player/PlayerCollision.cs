using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 장애물이냐
        // 골라인이냐
        // 위아래 라인

        Debug.Log(collision.tag);
    }
}
