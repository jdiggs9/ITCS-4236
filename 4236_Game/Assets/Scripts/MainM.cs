using UnityEngine;
using UnityEngine.SceneManagement;

public class MainM : MonoBehaviour
{
    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainM");
    }

    public void Victory() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }
}
