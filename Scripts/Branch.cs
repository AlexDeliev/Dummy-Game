using UnityEngine;

public class Branch : MonoBehaviour
{
    public bool isDry; // Определя дали клонът е сух

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Branch {name} triggered by {other.name} with tag {other.tag}.");

        PointSystem pointSystem = FindObjectOfType<PointSystem>();
        if (pointSystem == null)
        {
            Debug.LogError("PointSystem is not found in the scene!");
            return;
        }

        if (other.CompareTag("Saw"))
        {
            Debug.Log("Saw collided with branch.");
            if (isDry)
            {
                Debug.Log("Adding points for dry branch.");
                pointSystem.AddPoints(1);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Healthy branch touched. Triggering Game Over.");
                pointSystem.TriggerGameOver();
            }
        }
    }
}
