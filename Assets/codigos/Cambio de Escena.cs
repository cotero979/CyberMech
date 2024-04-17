using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiodeEscena : MonoBehaviour
{
    // Start is called before the first frame update

    public void cambiodesescna(int escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void salirdeescena()
    {
        Application.Quit();
    }
}
