using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DeathTrap1 : MonoBehaviour
{
    float timer = 0.0f;
    float speed = 1;
    float maxTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 1, 0);
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            speed = -1 * speed;
            timer = 0.0f;
        }

        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
