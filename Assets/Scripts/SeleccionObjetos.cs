using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionObjetos : MonoBehaviour
{

    private GameObject objetoSeleccionado = null;
    public bool estaEnModoObjeto = false;

    private void Start()
    {
        
    }

    void Update()
    {
        


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))

        {

           
            

            if (Input.GetMouseButtonDown(0))
            {
                objetoSeleccionado = hit.collider.gameObject;
                SeleccionarObjeto();


            }
            
            
        }
        if (Physics.Raycast(ray, out hit))
        {
            {
                if (estaEnModoObjeto)
                {

                    objetoSeleccionado.transform.position = hit.point;

                }
            }
        

        }
            
        


    }

    void SeleccionarObjeto()
    {
        Debug.Log("Esta moviendo" + objetoSeleccionado);
        estaEnModoObjeto = !estaEnModoObjeto;
    }

}



 

/*
private GameObject objetoSeleccionado = null;  // Objeto que se seleccionó para mover
private bool estaEnModoObjeto = false;          // Determina si el objeto está en modo de movimiento

 void Update()
{
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    // Verifica si el rayo ha golpeado algún objeto
    if (Physics.Raycast(ray, out hit))
    {
        // Si se hace clic con el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Si no hay objeto seleccionado, seleccionamos el objeto que fue golpeado por el raycast
            if (estaEnModoObjeto == false)
            {
                // Solo seleccionar el objeto si no está en modo de movimiento
                objetoSeleccionado = hit.collider.gameObject;
                estaEnModoObjeto = true;
            }
            // Si el objeto ya está seleccionado, desactivamos el modo de movimiento
            else
            {
                // Si el objeto que se hace clic es el que está seleccionado, desactivar
                if (hit.collider.gameObject == objetoSeleccionado)
                {
                    estaEnModoObjeto = false;
                    objetoSeleccionado = null;
                }
            }
        }
    }

    // Si un objeto está seleccionado, moverlo a la posición del raycast
    if (estaEnModoObjeto && objetoSeleccionado != null)
    {
        // Mueve el objeto seleccionado a la posición del raycast
        objetoSeleccionado.transform.position = hit.point;
    }
}*/
