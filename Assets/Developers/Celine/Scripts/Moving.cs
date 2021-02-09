using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(0, Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacles")
        {
            Destroy(gameObject);
            DeathScreen.instance.Death();
        }
    }
}
