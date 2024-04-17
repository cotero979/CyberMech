using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContact : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] AudioSource audiodedisparo;
    void Start()
    {
        
    }
    private void Awake()
    {
        audiodedisparo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0));
    }


    public void OnTriggerEnter(Collider other)
    {
        //Vector3 posicionbala= transform.position;
        Instantiate(ParticleSystem, transform);
       Destroy(gameObject);
    }
}
