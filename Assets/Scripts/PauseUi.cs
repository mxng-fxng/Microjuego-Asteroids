using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject Menu;
    public GameObject ResumeBoton;
    static bool flagGameOver = false;
    public GameObject GameOver;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");
            if (Paused && !flagGameOver)
            {
                Despausa();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Despausa()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pausa()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void RestartBoton()
    {
        Debug.Log("Cargando Juego...");
        Time.timeScale = 1f;
        flagGameOver = false;
        SceneManager.LoadScene("GameScene");
    }
    public void MenuBoton()
    {
        Debug.Log("Cargando Juego...");
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitPause()
    {
        Debug.Log("Cerraría Apliación");
        Application.Quit();
    }

    public void GameOverFunc()
    {
        flagGameOver = true;
        Pausa();
        ResumeBoton.SetActive(false);
        GameOver.SetActive(true);
    }

}
