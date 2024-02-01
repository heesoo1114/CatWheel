using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private string goalLineString = "GoalLine";
    private string obstacleString = "Obstacle";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(goalLineString))
        {
            // GameState => Clear
            GameManager.Instance.GameDone(true);
        }
        else if (collision.CompareTag(obstacleString))
        {
            // GameState => Over
            GameManager.Instance.GameDone(false);
        }
    }
}
