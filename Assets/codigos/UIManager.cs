using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Slider sliderCohetes;

    public PlayerMove plym;
    private float fuelrestante;

    public Slider sliderEscudos;
    private float escudosrestantes;

    private int life;
    [SerializeField] GameObject img1, img2, img3;


    [SerializeField] private float score;
    [SerializeField] private float highScore;
    [SerializeField] private TextMeshProUGUI scoreador;

    private float distanciastart;
    public Transform distanciador;


    void Start()
    {

         distanciastart = distanciador.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        life = plym.vidas;
        sliderCohetes.value = plym.Cohetes;

        sliderEscudos.value = plym.escudos;

        if (life ==3 )
        {
            img3.SetActive(true);
        }
        else if (life == 2)
        {
            img2.SetActive(true);
            img3.SetActive(false);

        }
        else if (life == 1)
        {
            img2.SetActive(false) ;
            img1.SetActive(true);
        }
        else if (life == 0)
        {
            img1.SetActive(false);
        }

      
        score = Mathf.FloorToInt(distanciador.position.x - distanciastart);

        scoreador.text = ("Score " + score);


    }
}
