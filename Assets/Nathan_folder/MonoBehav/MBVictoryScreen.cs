using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MBVictoryScreen : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(BacktoMenu());
    }

    IEnumerator BacktoMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("RushmoreMainMenu");
    }
}
