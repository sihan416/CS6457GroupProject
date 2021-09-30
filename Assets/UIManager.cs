using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Text lifeText;
    private PlayerController playerScript;
    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
        lifeText = this.GetComponent<Text>();
        lifeText.text = "Life: " + playerScript.life;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Life: " + playerScript.life;
    }
}
