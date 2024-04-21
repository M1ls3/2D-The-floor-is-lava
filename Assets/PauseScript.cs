using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseText;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            pauseText.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        else
        {
            pauseText.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

}
