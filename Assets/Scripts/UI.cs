using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI textMeshPro;

    // Array of random texts for the greeting
    public string[] greetingTexts = {
        "Hello!",
        "Greetings!",
        "Hi there!",
        "Welcome!",
        // Add more greeting texts as needed
    };

    // Array of random replies
    public string[] replyTexts = {
        "That sounds interesting.",
        "Tell me more!",
        "I agree!",
        "What a coincidence!",
        "I'm not sure what to say...",
        // Add more reply texts as needed
    };
    
    [Header("Response Windows")]
    public TextMeshProUGUI responseWindow1Text;
    public TextMeshProUGUI responseWindow2Text;
    public TextMeshProUGUI responseWindow3Text;

    [Header("Response Windows")]
    public Button button1;
    public Button button2;
    public Button button3;

    private void Start()
    {
        // Disable the canvas at the start
        canvas.enabled = false;

        // Set a random greeting text initially
        SetRandomGreeting();

        // Assign click functions to buttons
        button1.onClick.AddListener(OnClickButton1);
        button2.onClick.AddListener(OnClickButton2);
        button3.onClick.AddListener(OnClickButton3);
    }

    private void Update()
    {
        // Check for the 'm' key press
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle the canvas
            canvas.enabled = !canvas.enabled;

            // If the canvas is enabled, update the random text for Ant-Text
            if (canvas.enabled)
            {
                SetRandomGreeting();

                // Choose a random reply for each Response Window
                SetRandomReply(responseWindow1Text);
                SetRandomReply(responseWindow2Text);
                SetRandomReply(responseWindow3Text);
            }
        }
    }

    private void SetRandomGreeting()
    {
        // Choose a random index from the greeting array
        int randomIndex = Random.Range(0, greetingTexts.Length);

        // Set the randomly chosen greeting text
        textMeshPro.text = greetingTexts[randomIndex];
    }

    private void SetRandomReply(TextMeshProUGUI responseText)
    {
        // Choose a random index from the reply array
        int randomIndex = Random.Range(0, replyTexts.Length);

        // Set the randomly chosen reply text
        responseText.text = replyTexts[randomIndex];
    }

    private void OnClickButton1()
    {
        // Implement the functionality for button 1
        Debug.Log("Button 1 clicked!");
        canvas.enabled = !canvas.enabled;
    }

    private void OnClickButton2()
    {
        // Implement the functionality for button 2
        Debug.Log("Button 2 clicked!");
        canvas.enabled = !canvas.enabled;
    }

    private void OnClickButton3()
    {
        // Implement the functionality for button 3
        Debug.Log("Button 3 clicked!");
        canvas.enabled = !canvas.enabled;
    }
}
