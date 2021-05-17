using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject[] rings;
    public float ySpawn = 0;
    public float ringsDistance = 0.4f;
    public int numberRings;
    public GameObject lastRing;
    // Start is called before the first frame update
    void Start()
    {


        numberRings = GameObject.Find("GameManager").GetComponent<GameManager>().currentLevelIndex + 5;

        // numberRings = gameManager.currentLevelIndex + 5;
        for (int i =0; i < numberRings; i++)
        {
            if (i == 0)
            {
                SpawnRing(1);
            }
            else
            SpawnRing(Random.Range(0, rings.Length - 1));
        }
        SpawnRing(rings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(rings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringsDistance;
    }
}
