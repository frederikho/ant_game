using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class SceneLoader : MonoBehaviour
{
    [Header("Buttons")]
    public Button button1;
    
    // This method is called when the button is clicked
    public void Start ()
    {
        button1.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("The Ant");
    }
}