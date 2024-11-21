using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;


public class SeleccionObjetos : MonoBehaviour
{
    [SerializeField]
    GameObject textoEditar;
    [SerializeField]
    GameObject textoSeleccionar;
    [SerializeField]
    GameObject textoMover;
    [SerializeField]
    GameObject textoRotar;
    [SerializeField]
    GameObject textoEliminar;
    [SerializeField]
    GameObject esferaDeSeleccion;

    public CreadorObjetos CreadorObjetos;
    GameObject objetoSeleccionado = null;
    public bool estaEnModoObjeto = false;
    private bool bloquearSeleccion;
    public bool moviendoObjeto = false;
    public bool rotandoObjeto = false;
    public bool eliminandoObjeto = false;
    public bool estaEscalando = false;

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
                if ((estaEnModoObjeto && (moviendoObjeto || rotandoObjeto || eliminandoObjeto || estaEscalando))) //colocar objeto. Si le doy click y se cumple que estaba en modo objeto y se esta moviendo, rotando o eliminando.
                        {
                            estaEnModoObjeto = false;
                            objetoSeleccionado.SetActive(true);
                            objetoSeleccionado = null;
                            moviendoObjeto = false;
                            rotandoObjeto = false;
                            eliminandoObjeto = false;
                            textoSeleccionar.SetActive(true);
                            textoEditar.SetActive(false);
                            textoMover.SetActive(false);
                            textoRotar.SetActive(false);
                            textoEliminar.SetActive(false);
                            esferaDeSeleccion.SetActive(false);
                            
 
                        }

                        else 
                        {
                            if (hit.collider.gameObject.tag != "Objetos")
                            {
                                estaEnModoObjeto = true;
                                objetoSeleccionado = hit.collider.gameObject;
                                textoEditar.SetActive(true);
                                esferaDeSeleccion.SetActive(true);
                                esferaDeSeleccion.transform.position = hit.point;
                                SetParent(objetoSeleccionado);
                                if (estaEnModoObjeto)
                                {
                                    
                                    esferaDeSeleccion.transform.position = objetoSeleccionado.transform.position + new Vector3(0f, 0f);
                                }
                                EscalarEsferaSeleccion();

                            }
                            
                            
                        }
                
            }

            
            if (estaEnModoObjeto)
                {
                    

                    textoSeleccionar.SetActive(false);
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

                    else if (estaEscalando)
                    {
                        if (Input.mousePosition.y != 0)
                        {
                        float mouse = Input.mousePosition.y;
                        objetoSeleccionado.transform.localScale = new Vector3(mouse, mouse, mouse) * 0.25f;
                        }
                        
                    }

                    else if (eliminandoObjeto)
                    {
                        Destroy(objetoSeleccionado);
                        estaEnModoObjeto = false;
                        eliminandoObjeto = false;
                        textoEliminar.SetActive(false);

                    }

                }
        
        }

    }

    public void MoverObjeto()
    {
        if (estaEnModoObjeto)
        {
            moviendoObjeto = true;
            textoMover.SetActive(true);
        }
        
    }

    public void RotarObjeto()
    {
        if (estaEnModoObjeto)
        {
            rotandoObjeto = true;
            textoRotar.SetActive(true);
        }
        
    }

    public void EliminarObjeto()
    {
        if (estaEnModoObjeto)
        {
            eliminandoObjeto = true;
            textoEliminar.SetActive(true);
        }
        
    }

    public void EscalarObjeto()
    {
        estaEscalando = true;
    }

    public void EscalarEsferaSeleccion()
    {

        esferaDeSeleccion.gameObject.transform.LeanScaleX(2f, 1f).setLoopPingPong();
        esferaDeSeleccion.gameObject.transform.LeanScaleZ(2f, 1f).setLoopPingPong();

    }

    public void SetParent(GameObject newparent)
    {
        
            esferaDeSeleccion.transform.parent = newparent.transform;
           
        
    }

}
