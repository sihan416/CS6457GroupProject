using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // https://answers.unity.com/questions/1264278/unity-5-directional-light-problem-please-help.html
    // The scene is dark after reloading the scene in editor. This will not happen in the build game. 
    public void ReloadActiveScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);

        Time.timeScale = 1f;
    }
}
