using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    public SeleccionObjetos SeleccionObjetos;
    public bool moviendoObjeto = false;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {

            if (moviendoObjeto)
            {
                Debug.Log("Se deberia mover");
                //SeleccionObjetos.objetoSeleccionado.transform.position = hit.point;

            }
        }
    }

    public void MoverObjeto()
    {
        moviendoObjeto = true;
    }
    
}
