using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void backTo()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
   
}
