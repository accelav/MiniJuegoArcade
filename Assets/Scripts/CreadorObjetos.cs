using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreadorObjetos : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textoCrear;
    [SerializeField]
    TextMeshProUGUI textoCreador;
    [SerializeField]
    GameObject textoVolverASeleccionar;


    public GameObject objetoCreado;
    public bool creandoObjeto = false;

    
    void Start()
    {

    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (objetoCreado != null)
        {
            objetoCreado.SetActive(false);
        }
        if (creandoObjeto)
        {
            
            if (Physics.Raycast(ray, out hit))
            {

                
                objetoCreado.transform.position = hit.point;
                objetoCreado.SetActive(true);
               

            }
            //objetoCreado.transform.position += new Vector3(0, objetoCreado.transform.localScale.y / 2, 0);

            

            objetoCreado.transform.Rotate(Input.mouseScrollDelta * 16);




            // Fijar el objeto en su posici�n actual al hacer clic
            if (Input.GetMouseButtonDown(0))
            {
                objetoCreado = null; // Reiniciar para permitir crear otro objeto
                creandoObjeto = false; // Desactivar el modo crear objeto
                textoCreador.gameObject.SetActive(false);
                textoVolverASeleccionar.gameObject.SetActive(true);
            }
        }




    }



    public void CrearObjeto(GameObject prefab)
    {
        objetoCreado = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        creandoObjeto = true;
        textoCrear.gameObject.SetActive(false);
        textoCreador.gameObject.SetActive(true);
    }



}