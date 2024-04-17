using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatecosasdeagarrar : MonoBehaviour
{
    [SerializeField] private float speedrotation=200;
    private float rotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
          rotation= Time.deltaTime*speedrotation;

        transform.localRotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotation, rotation));
    }
}
