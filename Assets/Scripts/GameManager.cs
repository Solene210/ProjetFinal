using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Expose
    [SerializeField] private GameObject _playerWindow;
    #endregion

    #region Unity Life Cycle
    void Update()
    {
        Pause();
    }
    #endregion

    #region methods
    private void Pause()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            _playerWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        _playerWindow.SetActive(false);
    }

    public void LaunchGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenue()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
