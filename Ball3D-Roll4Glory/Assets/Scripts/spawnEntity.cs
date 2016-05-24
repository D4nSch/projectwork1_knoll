using UnityEngine;
using System.Collections;

public class spawnEntity : MonoBehaviour {

    GameObject[] spawning;
    GameObject[] deSpawning;
    // Use this for initialization
    void Start () {

        spawning = new GameObject[8];
        deSpawning = new GameObject[4];
        for (int i = 1; i < 9; i++)
        {
            spawning[i-1] = GameObject.Find("SpawnPlatform "+i);
            spawning[i-1].SetActive(false);
        }
        for (int i = 1; i < 5; i++)
        {
            deSpawning[i-1] = GameObject.Find("DeSpawnPlatform " + i);
        }
    }

    public void activateTrap()
    {
        for (int i = 0; i < 8; i++)
        {
            spawning[i].SetActive(true);
        }
        for (int i = 0; i < 4; i++)
        {
            deSpawning[i].SetActive(false);
        }
    }

}
