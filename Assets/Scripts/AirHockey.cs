using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHockey : MonoBehaviour
{
    bool modificar = false;
    public AbrirDesplegables AbrirDesplegables;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (modificar)
        {
            if (Physics.Raycast(ray, out hit))
            {
                AbrirDesplegables.AbrirDesplegable();
            }
        }
    }

    public void OnMouseDown()
    {
        modificar = true;
        
    }
}
