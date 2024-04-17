using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirEnemigo : MonoBehaviour
{

    public Transform Player;
    [SerializeField] private float rotationspeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerposition = Player.transform.position;

        playerposition.z = 0;

        transform.up =  Vector3.MoveTowards(transform.up,playerposition, rotationspeed*Time.deltaTime);
    }
}
