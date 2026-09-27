using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{

    public Canvas Menu;

    public void StartBoton()
    {
        Debug.Log("Cargando Juego...");
        SceneManager.LoadScene("GameScene");
    }

    public void HighScores()
    {
        Debug.Log("Highscores...");
    }

    public void Quit()
    {
        Debug.Log("Cerraría Apliación");
        Application.Quit();
    }

}
