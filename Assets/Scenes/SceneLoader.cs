using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This method is called when the button is clicked
    public void LoadScene()
    {
        SceneManager.LoadScene("The Ant");
    }
}