using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContrroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlayGame() {
        SceneManager.LoadScene("Stage_01");
    }

    public void ExitGame() {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
