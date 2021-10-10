using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public void StartNewGame()
    {
        // todo: load the first level;
        SceneManager.LoadScene("name of the first level's scene");

        Time.timeScale = 1f;
    }
}
