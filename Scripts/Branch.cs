using UnityEngine;

public class Branch : MonoBehaviour
{
    public bool isDry;     public AudioClip dryBranchSound; 
    public AudioClip healthyBranchSound; 
    private AudioSource audioSource; 

    void Start()
    {
        // Adding AudioSource 
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

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
                PlaySound(dryBranchSound); // Audio for drybranch
                pointSystem.AddPoints(1);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Healthy branch touched. Triggering Game Over.");
                PlaySound(healthyBranchSound); // Audio for healthybrach
                pointSystem.TriggerGameOver();
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip); 
        }
    }
}
