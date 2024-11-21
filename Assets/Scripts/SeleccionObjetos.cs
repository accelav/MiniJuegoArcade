using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using TMPro;

public class SeleccionObjetos : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textoMover;
    [SerializeField]
    TextMeshProUGUI textoRotar;
    [SerializeField]
    TextMeshProUGUI textoEliminar;
    public CreadorObjetos CreadorObjetos;
     GameObject objetoSeleccionado = null;
    public bool estaEnModoObjeto = false;
    private bool bloquearSeleccion;
    public bool moviendoObjeto = false;
    public bool rotandoObjeto = false;
    public bool eliminandoObjeto = false;

    private void Update()
    {
               
        if (CreadorObjetos.creandoObjeto) // Mientras el booleano "creandoObjeto" del script "CreadorObjetos" está activo,
                                          // vuelve a empezar el Update
        {
            bloquearSeleccion = true; // Como el script "CreadorObjetos" desactiva el instanciador de objetos
                                    // con el click izquierdo del mouse, y en este script se activa la seleccion 
                                    // de objetos con el mimso click,
                                    // necesitamos que se bloquee el primer click del ratón en este script
                                    // una vez desactivado el instanciador del otro script
                                    // simplemente volviendo a empezar este Update.
            return;
        }

        // Si el bloqueo está activo, lo desactivamos después de un fotograma.
        if (bloquearSeleccion)
        {
            bloquearSeleccion = false;
            return; // Ignora este fotograma.
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (objetoSeleccionado != null && estaEnModoObjeto)
        {
            objetoSeleccionado.SetActive(false);
        }
        
        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (estaEnModoObjeto && (moviendoObjeto || rotandoObjeto || eliminandoObjeto))
                        {
                            estaEnModoObjeto = false;
                            objetoSeleccionado.SetActive(true);
                            objetoSeleccionado = null;
                            moviendoObjeto = false;
                            rotandoObjeto = false;
                            eliminandoObjeto = false;
 
                        }

                        else 
                        {
                            if (hit.collider.gameObject.tag != "Objetos")
                            {
                                estaEnModoObjeto = true;
                                objetoSeleccionado = hit.collider.gameObject;
                            }
                            
                            
                        }

            }

            
            if (estaEnModoObjeto)
                {
                    objetoSeleccionado.SetActive(true);
                    if (moviendoObjeto)
                    {
                        Debug.Log("Esta moviendo" + objetoSeleccionado);
                        objetoSeleccionado.transform.position = hit.point;
                        rotandoObjeto = false;
                        
                    }

                    else if (rotandoObjeto)
                    {
                        objetoSeleccionado.transform.Rotate(Input.mouseScrollDelta * 16);
                        moviendoObjeto = false;
                        
                    }

                    
                    
                    else if (eliminandoObjeto)
                    {
                        Destroy(objetoSeleccionado);
                        estaEnModoObjeto = false;
                        eliminandoObjeto = false;
                    }

                    
  
                }
        
        }

    }

    public void MoverObjeto()
    {
        if (estaEnModoObjeto)
        {
            moviendoObjeto = true;
        }
        
    }

    public void RotarObjeto()
    {
        if (estaEnModoObjeto)
        {
            rotandoObjeto = true;
        }
        
    }

    public void EliminarObjeto()
    {
        if (estaEnModoObjeto)
        {
            eliminandoObjeto = true;
        }
        
    }

}
