using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class PlayerMove : MonoBehaviour

{
    [Header("Vida")]
    public int vidas=3;
    [SerializeField] private Vector3 respawnpoint;
    [SerializeField] Transform caidaPoint;
    [SerializeField] Transform Toptop;


    [Header("Componenters")]
    private Rigidbody rb;
    private SpriteRenderer sp;
    [SerializeField] ParticleSystem psPropulsores;



    [Header("Movimientos")]
    private float movimientoHorizontal;

    [SerializeField] private float velocidaddemovimiento;
    [SerializeField] private float velocidadcohetes;


    private Vector3 velocidad = Vector3.zero;



    [SerializeField] private float saltacion;

     private bool puedesaltar;

    [Header("PowerUps")]

    public float Cohetes;
    public float escudos;

    [SerializeField] GameObject escudovisual;


    [Header("GamaManagement")]
    [SerializeField] private int scena;






    [SerializeField] private UnityEvent Muerte = new();
    // [SerializeField] private UnityEvent<float> cohetefuel = new ();
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        sp = GetComponent<SpriteRenderer>();

        

        psPropulsores.Stop();



    }

    private void Update()
    {

        movimientoHorizontal = Input.GetAxis("Horizontal") * velocidaddemovimiento * 100;


        if (Input.GetButtonDown("Jump") && puedesaltar)
        {
            Jump();
        }


        if (Input.GetKey("e") && escudos > 0)
        {
            Escudar();
        }
        else
        {
            escudovisual.SetActive(false);
        }


        if (Input.GetAxis("Vertical") > 0 && Cohetes > 0)
        {
            psPropulsores.Play();
            Propulsar();
        }
        else if (Input.GetAxis("Vertical") <= 0)
        {
            psPropulsores.Stop();
        }


        if (transform.position.y > Toptop.position.y)
        {
            transform.position = new Vector3(transform.position.x, Toptop.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {



        Mover(movimientoHorizontal * Time.fixedDeltaTime);
        
       rb.AddForce(new Vector3(0,-20,0));

        if (transform.position.y < caidaPoint.position.y)
        {
            Moricion();
            
            
        }


    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector3(mover, rb.velocity.y, 0);

        rb.velocity = velocidadObjetivo;







        if (mover >= 0)
        {
            //sp.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (mover < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //sp.flipX = true;
        }
    }

  

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ground"))
        {
            //Debug.Log("tocosuelo");
            puedesaltar = true;

            respawnpoint= other.GetComponentInChildren<Transform>().position+ new Vector3(0,5,0);

        }
        else if (other.CompareTag("Fuel"))
        {
            if (Cohetes <= 10)
            {
                Cohetes += 5;
             //   Destroy(other.gameObject);

                other.gameObject.SetActive(false);
            }

        }
        else if (other.CompareTag("Vidas"))
        {
            if(vidas<= 2)
            {
                vidas++; 
              //  Destroy(other.gameObject);
                other.gameObject.SetActive(false);

            }
        }
        else if (other.CompareTag("Escudo"))
        {
            if (escudos <= 10)
            {
                escudos +=5;
               // Destroy(other.gameObject);
                other.gameObject.SetActive(false);

            }
        }

        if (other.CompareTag("Enemy"))
        {
            Moricion();
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            puedesaltar = false;
        }
    }







    public void Jump()
    {
      
        rb.velocity = new Vector3(rb.velocity.x, saltacion, rb.velocity.z);
        puedesaltar = false;
    }
    void Propulsar()
    {
        rb.velocity= new Vector3(0, velocidadcohetes, 0);
        Cohetes -= Time.fixedDeltaTime * 1;
    }

    void Escudar()
    {
        escudovisual.SetActive(true);
        escudos -= Time.fixedDeltaTime*0.5f ;
    }



    void Moricion()
    {
        transform.position = respawnpoint;
        vidas -= 1;
        Muerte.Invoke();
        if (vidas == 0)
        {
            SceneManager.LoadScene(scena);
        }
    }
}
