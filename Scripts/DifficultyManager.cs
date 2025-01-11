using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public CameraFollow cameraFollow; // Референция към скрипта за движение на камерата
    private float difficultyTimer = 0f; // Таймер за прогресия
    private float difficultyInterval = 10f; // Интервал за увеличаване на трудността (в секунди)
    private float speedIncreaseAmount = 0.5f; // Увеличение на скоростта на камерата

    void Update()
    {
        // Увеличаване на трудността на всеки интервал
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= difficultyInterval)
        {
            IncreaseDifficulty();
            difficultyTimer = 0f; // Нулиране на таймера
        }
    }

    void IncreaseDifficulty()
    {
        // Увеличаване на скоростта на камерата
        if (cameraFollow != null)
        {
            cameraFollow.IncreaseSpeed(speedIncreaseAmount);
        }
        
    }
}
