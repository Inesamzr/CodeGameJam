using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSystem : MonoBehaviour
{
    public float healAmount = 20;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerHealth>().currentHealth < other.gameObject.GetComponent<PlayerHealth>().maxHealth) {
                other.gameObject.GetComponent<PlayerHealth>().heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
