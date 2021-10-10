using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    public void ResumeGame()
    {
        CanvasGroup canvasGroup = this.GetComponentInParent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;

        Time.timeScale = 1f;
    }
}
