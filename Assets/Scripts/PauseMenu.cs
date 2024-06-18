using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] CannonController player;
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        player.enabled = false;

    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;


    }
}
