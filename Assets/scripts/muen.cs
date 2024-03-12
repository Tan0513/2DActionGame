using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void UIEnable()
    {
        GameObject.Find("Canvas/MainMuen/UI").SetActive(true);
    }

    public void gamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void setVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }

}
