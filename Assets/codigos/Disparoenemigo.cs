using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private Transform Player;
    [SerializeField] private GameObject bala;

    [SerializeField] private float gunRange;

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,Player.transform.position)<gunRange)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        

    }


}

   