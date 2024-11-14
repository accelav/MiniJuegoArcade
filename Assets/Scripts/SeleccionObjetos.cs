using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionObjetos : MonoBehaviour
{

    public bool estaEnModoObjeto = false;
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))

        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            
        }


    }



    private void OnMouseDown()
    {

    estaEnModoObjeto = !estaEnModoObjeto;

    }
}

