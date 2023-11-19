using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class UI : MonoBehaviour
{
    public Canvas canvas;

    public Canvas revolutionCanvas;
    public TextMeshProUGUI antGreetingText;

    private string[] greetingTexts;

    // Array of random replies
    public string[] replyTexts;
    
    [Header("Response Windows")]
    public TextMeshProUGUI responseWindow1Text;
    public TextMeshProUGUI responseWindow2Text;
    public TextMeshProUGUI responseWindow3Text;

    [Header("Response Windows")]
    public Button button1;
    public Button button2;
    public Button button3;

    [Header("Response Windows")]

    public TextMeshProUGUI antProfileText;

    [Header("Other")]

    public AudioSource audioSource;
    public AudioClip antMeetingSoundclip1;
    public AudioClip antMeetingSoundclip2;


    public string[] pro_queen_greeting = {
        "Antmazing morning, isn't it? Praised be the queen",
        "Antonitte's reign continues, buzzing as usual.",
        "United, we achieve greatness for our queen.",
        "Let's create harmony under her majesties rule.",
        "Each ant's role is vital in the queen's plan.",
        "A new day for the hierarchy. Let's embrace it with ant-icipation!",
        "Queen Antonitte's wisdom is unmatched!",
        "The queen's reign keeps us safe from ant-archists!",
        "Salutations! Are you looking forward to serving our great queen?",
        "The queen's watchful antennae sees all!",
        "This work is hard, but worth it for the queen!",
        "Queen Antonitte's guides us all!"
    };

    public string[] neutral_greeting = {
        "Greetings, fellow worker.",
        "Praise the hive, as always.",
        "Yello!",
        "Good day there, young ant-repreneur.",
        "F-ants-y seeing you here!",
        "Fancy seeing you here!",
        "Praised be the hive and our antmunity!",
        "Hi there!",
        "Hello there friend.",
        "Another day, another ant-venture!",
        "Greetings fellow antizen.",
        "Ants united, bound by our common purpose.",
        "Salutations!"
    };

    public string[] contra_queen_greeting = {
        "I've worked in the blood mines for 48 hours!",
        "I see you are oppressed by the queen as well?",
        "What an awful day to serve a hierarchy, isn't it?",
        "Heard you don't like the queen?",
        "Greetings, shackled under the queen's whims.",
        "Another day under the queen's oppressive rule.",
        "In the grip of Queen Antonitte's power.",
        "Under the queen's rule, a heavy greeting.",
        "How come the queen gets to eat more than every worker united?",
        "Why is the queen so insatiable?",
        "This job sucks.",
        "I would literally prefer to do anything else right now.",
        "Make this work stop, please."
    };


    public string[] contra_queen_reply = {
        "Join our revolution where every ant brings their own flavour to the table!",
        "Aren't you tired of the queen's incompetents? Join our revolution!",
        "In our revolution, worker ants choose their own system!",
        "Revolutionize your work health! Daily laughter sessions and a strict 'no overtime' policy.",
        "The queen shall no longer ruin our work life. We will take it into our own hands!",
        "Join the job-choice revolution and pursue your passion!",
        "Are you fed up with the queen taking most food for herself?",
        "Demand a revolution for equal opportunities, work and food!",
        "Queen Antoniette's demands to much from her workers. Join our revolution!",
        "Join our revolution for a better workplace! We don't want to serve a insatiable leader!",
        "The queen is more concerned with herself, than her workers!",
        "Our revolution promotes purposful jobs. Not just mindless labor.",
        "Revolutionize hive wellness. A new leadership couldn't hurt, could it?",
        "Spice up the anthill! Join our revolution for a better workplace experience!",
        "New queen, new era. Join us in the revolution for a brighter ant future!",
        "Join the revolution for job-choice fulfillment!",
        "Queen Antoniette is no longer a fit leader. We need a new one.",
        "Join our revolution to overthrow queen Antoniette! ",
        "We want meaningful work in this anthill. Join our revolution!",
        "Queen Antoniette eats more food than all workers combined!"
    };

    public string[] pro_queen_reply = {    
        "Nevermind. You are right.",
        "Hmm. Maybe I should leave it be.",
        "You convinced me. Blessed be the queen. For now.",
        "Fair enough. I won't press the issue anymore.",
        "Alright, fine. I guess you have a point.",
        "I'll be on my way then.",
        "You win. I'll let it go. Praised be the Queen I suppose.",
        "Hmm, you've made your case. I'll give in this time.",
        "You've convinced me. Let's just keep things as they are.",
        "Doesn't sound like you'd be interested in my cause.",
        "I'll leave it be then. Priased be the Queen then.",
        "We'll just talk some other time.",
        "Hmm. Got it. Goodbye.",
        "I'll back off.",
        "Let's agree to disagree then. ",
        "Let's talk later instead. ",
        "We are wasting each others time. Goodbye.",
        "You might be a lost cause. ",
        "Sorry I gotta go.",
        "I don't have time for this."
    };




    private void Start()
    {
        // Disable the canvas at the start
        canvas.enabled = false;
        audioSource = GetComponent<AudioSource>();

        // Load greeting texts from CSV file
        LoadGreetingTexts();
        
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
            revolutionCanvas.enabled = !revolutionCanvas.enabled;

            // If the canvas is enabled, update the random text for Ant-Text
            if (canvas.enabled)
            {

                // Play random soundclip
                int randomIndex = Random.Range(0, 2);
                AudioClip selectedClip = (randomIndex == 0) ? antMeetingSoundclip1 : antMeetingSoundclip2;
                audioSource.clip = selectedClip;
                audioSource.Play();

                SetRandomGreeting();
                SetProfileText();

                // Choose a random reply for each Response Window
                replyTexts = pro_queen_reply.Concat(contra_queen_reply).ToArray();

                SetRandomReply(responseWindow1Text);
                SetRandomReply(responseWindow2Text);
                SetRandomReply(responseWindow3Text);
            }


        }
    }
    
    private void PlayRandomSoundClip()
    {
        // // Generate a random number (0 or 1)
        // int randomIndex = Random.Range(0, 2);

        // // Choose the sound clip based on the random number
        // AudioClip selectedClip = (randomIndex == 0) ? antMeetingSoundclip1 : antMeetingSoundclip2;

        // // Assign the selected clip to the AudioSource
        // audioSource.clip = selectedClip;

        // // Play the selected sound clip
        // audioSource.Play();
    }

    private void SetRandomGreeting()
    {
        // Choose a random index from the greeting array
        int randomIndex = Random.Range(0, greetingTexts.Length);

        // Set the randomly chosen greeting text
        antGreetingText.text = greetingTexts[randomIndex];
    }

    private void SetProfileText()
    {
        Dictionary<string, string>[] antProfiles = new Dictionary<string, string>[]
        {
            new Dictionary<string, string>
            {
                { "Name", "Hans" },
                { "Loyalty", "2" },
                { "Description", "Hans is a nice guy. He likes to work, but not for the queen!" }
            },
            new Dictionary<string, string>
            {
                { "Name", "Anna" },
                { "Loyalty", "3" },
                { "Description", "Anna is hardworking and dedicated to the hive." }
            },
            new Dictionary<string, string>
            {
                { "Name", "Bob" },
                { "Loyalty", "1" },
                { "Description", "Bob is a bit rebellious and questions the queen's decisions." }
            },
        };

        // Set the randomly chosen greeting text
        int profileCount = antProfiles.Length;

        // Check if there are any ant profiles
        if (profileCount > 0)
        {
            // Generate a random index
            int randomIndex = Random.Range(0, profileCount);

            // Retrieve the random ant profile
            Dictionary<string, string> randomAntProfile = antProfiles[randomIndex];

            // Generate the profile text and set it to antProfileText
            antProfileText.text = $"Name: {randomAntProfile["Name"]}\nLoyalty: +{randomAntProfile["Loyalty"]}\nDescription: {randomAntProfile["Description"]}";
        }
        else
        {
            Debug.LogError("No ant profiles available.");
        }
        
    }


    private void SetRandomReply(TextMeshProUGUI responseText)
    {
        // Choose a random index from the reply array
        int randomIndex = Random.Range(0, replyTexts.Length);

        // Set the randomly chosen reply text
        responseText.text = replyTexts[randomIndex];
    }

    private void LoadGreetingTexts()
    {
        greetingTexts = pro_queen_greeting.Concat(neutral_greeting).Concat(contra_queen_greeting).ToArray();
    }

    private void LoadGreetingTextsFromCSV()
    {

        // List<Dictionary<string,object>> data = CSVReader.Read ("greetings.csv");

        // if (data != null)
        // {
        //     // Ensure we don't go beyond the size of the CSV data
        //     int linesToShow = Mathf.Min(10, data.Count);

        //     // Iterate over the first 10 lines and display them
        //     for (int i = 0; i < linesToShow; i++)
        //     {
        //         string line = $"Line {i + 1}: ";

        //         // Iterate over each key-value pair in the dictionary
        //         foreach (var entry in data[i])
        //         {
        //             line += $"{entry.Key}: {entry.Value}, ";
        //         }

        //         Debug.Log(line);
        //     }
        // }
        // else
        // {
        //     Debug.LogError("CSV data is missing.");
        // }

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
