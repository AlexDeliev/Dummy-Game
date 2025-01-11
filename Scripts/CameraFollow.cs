using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public float moveSpeed = 2f;

    void Update()
    {
        // Движи камерата нагоре с постоянна скорост
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
    public void IncreaseSpeed(float amount)
    {
        moveSpeed += amount;
    }


}
