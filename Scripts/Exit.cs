using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
