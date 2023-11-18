using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    float lifetime = 60;
	bool useDeath = true;

    float deathTime;

    // Start is called before the first frame update
    void Start()
    {
        deathTime = Time.time + lifetime + Random.Range(0, lifetime / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > deathTime && useDeath)
		{
			Destroy(gameObject);
		}
    }
}
