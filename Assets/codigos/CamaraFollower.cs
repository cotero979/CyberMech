using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollower : MonoBehaviour
{

    [SerializeField] private Transform Player;
    [SerializeField] private Transform Camera;

    private float followplayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(followplayer<Player.position.x)
            followplayer = Player.position.x;


        Camera.position= new Vector3(followplayer,Camera.position.y,Camera.position.z);
    }

    public void CameraDeadRespawn()

    {
        followplayer = Player.position.x;
    }
}
