using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))] 
public class MenuInGame : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        // Todo: Note that Input.GetKeyUp() should eventually be replaced with Input.GetButtonUp() with a 
        // virtual button created in the InputManager settings. This will allow multiple game controllers 
        // to map to common input events (e.g. simultaneous keyboard, and handheld game controller 
        // support).
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;

                Time.timeScale = 1f;
            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;

                Time.timeScale = 0f;
            }
        }
    }
}
