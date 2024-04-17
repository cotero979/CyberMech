using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public Transform bakUp, bakDown, frontUp, frontDown;
    void Start()
    {
        
    }

    void Update()
    {

        if (transform.position.x < bakUp.position.x)
        {
            float newpostX = frontDown.position.x;
            float rdpostY = Random.Range(frontUp.position.y, frontDown.position.y);
            transform.position = new Vector3(newpostX,rdpostY,transform.position.z);



            float distorcionY = Random.Range(550f, 115f);
            float distorcionZ = Random.Range(30f, 170f);
            transform.localScale = new Vector3(transform.localScale.x, distorcionY, distorcionZ);
        }
    }
}
