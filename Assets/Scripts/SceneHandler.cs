using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public void retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GameController.retry();

        Time.timeScale = 1;
    }

    public void continueGame()
    {
        GameController.continueGame();
    }

    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeSceneToStart()
    {
        Time.timeScale = 1;
        GameController.retry();
        SceneManager.LoadScene("StartScene");
    }
}
