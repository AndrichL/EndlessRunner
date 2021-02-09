using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Celine : MonoBehaviour
{
    public float timer = 0f;

    public GameObject randomObject;
    public GameObject spawnPosObject;
    public int Obstacles;
    public Transform[] spawns;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Spawn()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(spawns);

        for (int i = 0; i < Obstacles; i++)
        {
            if (freeSpawnPoints.Count < 0)
            {
                return;
            }
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index);
            Instantiate(randomObject, pos.position, pos.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
      

        timer += 1f * Time.deltaTime;

        if (timer >= 5)
        {
            timer = 0;
            Spawn();
        }

        
    }
}
