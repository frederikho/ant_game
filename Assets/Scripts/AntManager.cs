using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntManager : MonoBehaviour
{
    //private List<Ant> ants = new List<Ant>();
    [SerializeField] Ant[] ants;
    [SerializeField] List<Ant> queenSupporters = new List<Ant>();
    [SerializeField] List<Ant> playerSupporters = new List<Ant>();
    [SerializeField] List<Ant> anarchists = new List<Ant>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitAndSearchForAnts");
    }

    IEnumerator WaitAndSearchForAnts()
    {
        print("look for ants");
        yield return new WaitForSeconds(1);
        FindAnts();
    }

    void FindAnts()
    {
        print("finding ants");
        ants = FindObjectsOfType<Ant>();
        foreach (Ant ant in ants)
        {
            ant.politicalAffiliationChange += AssignAntToList;
            if(ant.politicalAffiliation < 0)
            {
                queenSupporters.Add(ant);
            }
            else if(ant.politicalAffiliation > 0)
            {
                playerSupporters.Add(ant);
            }
            else 
            {
                anarchists.Add(ant);
            }

        }
    }

    public void AssignAntToList(Ant ant)
    {
        if(ant.politicalAffiliation < 0)
        {
            queenSupporters.Add(ant);
        }
        else if(ant.politicalAffiliation > 0)
        {
            playerSupporters.Add(ant);
        }
        else 
        {
            anarchists.Add(ant);
        }
    }
}
