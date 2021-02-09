using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(0, Input.GetAxis("Vertical"), 0);
        transform.position += move * 3f * Time.deltaTime;

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacles")
        {
            Destroy(gameObject);
            DeathScreen.instance.Death();
        }
    }
}
