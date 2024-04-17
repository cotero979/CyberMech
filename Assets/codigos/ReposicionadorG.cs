using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposicionadorG : MonoBehaviour
{
    public Transform bakUp, bakDown, frontUp, frontDown;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < bakUp.position.x)
        {
            float newpostX = frontDown.position.x;
            float rdpostY = Random.Range(frontUp.position.y, frontDown.position.y);
            transform.position = new Vector3(newpostX, rdpostY, transform.position.z);

             gameObject.SetActive(true);


        }
    }
}
