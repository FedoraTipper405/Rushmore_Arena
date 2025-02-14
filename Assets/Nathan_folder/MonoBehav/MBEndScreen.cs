using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MBEndScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BackToMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BackToMenu()
    {
        AudioManager.PlaySound(7);
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("RushmoreMainMenu");
    }
}
