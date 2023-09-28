using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    float timer = 0.0f;
    float speed = 0.1f;
    float maxTime = 1.2f;
    public GameObject particleSystemToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HoverAndRotate();
    }
    void HoverAndRotate()
    {
        Vector3 movement = new Vector3(0, 1, 0);
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            speed = -1 * speed;
            timer = 0.0f;
        }

        transform.position = transform.position + movement * speed * Time.deltaTime;
        transform.Rotate(0, 0.5f, 0);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Instantiate(particleSystemToSpawn, transform.position, transform.rotation), 1);
            if (tag == "StarPowerUp")
            {
                GameManager.Instance.IncrementScore(50);
                Destroy(gameObject);
            }
            if (tag == "DoubleJumpPowerUp")
            {
                GameManager.Instance.IncrementScore(25);
                other.gameObject.GetComponent<PlayerMovement>().hasDoubleJumpPowerUp = true;
                gameObject.SetActive(false);
                Invoke("RespawnPickUp", 30);
            }
        }
    }
    void RespawnPickUp()
    {
        gameObject.SetActive(true);
    }
}
