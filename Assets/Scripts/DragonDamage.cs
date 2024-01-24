using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDamage : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    [SerializeField] private GameObject fire;

    [SerializeField] private float sphereCastRadius = 0.5f;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.SphereCast(fire.transform.position, sphereCastRadius, fire.transform.up, out hit, 1000f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hit.collider.GetComponent<PlayerHealth>().takeDamage(damage * Time.deltaTime);
            }
            Debug.DrawRay(fire.transform.position, fire.transform.up * 1000f, Color.red);
        }
    }
}
