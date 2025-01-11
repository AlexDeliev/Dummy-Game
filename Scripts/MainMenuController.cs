using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(LoadGameSceneWithDelay());
    }

    private IEnumerator LoadGameSceneWithDelay()
    {
        // wait for 3sec
        yield return new WaitForSeconds(2f);

        // Load scene after the pause
        SceneManager.LoadScene("GameScene");
    }
}
