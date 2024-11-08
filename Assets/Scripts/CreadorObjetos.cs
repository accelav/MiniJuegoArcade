using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorObjetos : MonoBehaviour
{

    [SerializeField]
    GameObject pantallaLateral;
    [SerializeField]
    float durationAnim = 0.25f;
    [SerializeField]
    GameObject botonAirHockey;
    [SerializeField]
    GameObject prefabAirHockey;

    GameObject objetoCreado;
    //GameObject objetoCreado2;


    bool abrirLateral = false;
    bool airHockey = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (airHockey)
        {
            
            if (Physics.Raycast(ray, out hit))
            {

                
                objetoCreado.transform.position = hit.point;

            }
            objetoCreado.transform.position += new Vector3(0, objetoCreado.transform.localScale.y / 2, 0);


            objetoCreado.transform.Rotate(Input.mouseScrollDelta * 16);


            // Fijar el objeto en su posición actual al hacer clic
            if (Input.GetMouseButtonDown(0))
            {
                objetoCreado = null; // Reiniciar para permitir crear otro objeto
                airHockey = false; // Desactivar el modo airHockey
            }
        }

        if (abrirLateral == true)
        {
                LeanTween.moveLocalX(pantallaLateral, 320f, durationAnim).setEase(LeanTweenType.linear);
                abrirLateral = false;
        }

    }

    public void AbrirCreador()
    {
        abrirLateral = true;
    }

    public void AirHockey()
    {
        objetoCreado = Instantiate(prefabAirHockey, Vector3.zero, Quaternion.identity);
        airHockey = true;
    }
}