using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DeathTrap1 : MonoBehaviour
{
    float timer = 0.0f;
    float speed = 2;
    float maxTime = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(1, 0, 0);
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            speed = -1 * speed;
            timer = 0.0f;
        }

        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
