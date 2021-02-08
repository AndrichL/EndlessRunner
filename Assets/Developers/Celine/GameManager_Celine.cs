using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Celine : MonoBehaviour
{
    public float timer = 0f;

    public GameObject randomObject;
    public GameObject spawnPosObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        timer += 0.5f * Time.deltaTime;

        if (timer >= 2)
        {
            timer = 0;
            Vector3 spawnPosition = new Vector3(0, Random.Range(-3f, 5f));
            Instantiate(randomObject, spawnPosObject.transform.position += spawnPosition, Quaternion.identity);
        }

        
    }
}
