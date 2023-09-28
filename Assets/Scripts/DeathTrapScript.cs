using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
