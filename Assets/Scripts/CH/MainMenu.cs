using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clickSound;

    public void PlayGame()
    {
        source.clip = clickSound;
        source.Play();
        Invoke("LoadMain", clickSound.length);
    }

    public void QuitGame()
    {
        source.clip = clickSound;
        source.Play();
        Invoke("Quit", clickSound.length);
    }

    private void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    private void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}