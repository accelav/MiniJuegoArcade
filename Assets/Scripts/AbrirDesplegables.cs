using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class AbrirDesplegables : MonoBehaviour
{
    public CreadorObjetos CreadorObjetos;
    public SeleccionObjetos SeleccionObjetos;
    
    [SerializeField]
    GameObject pantallaLateral;
    [SerializeField]
    float durationAnim = 0.25f;
    [SerializeField]
    GameObject desplegableAbajo;
    [SerializeField]
    GameObject flechaAbajo;
    [SerializeField]
    TextMeshProUGUI textoBienvenida;
    [SerializeField]
    TextMeshProUGUI textoEditar;
    [SerializeField]
    GameObject textoCrear;


    

    bool abrirLateral = false;
    bool abriendoDesplegable = false;
    // Start is called before the first frame update
    void Start()
    {
        textoBienvenida.gameObject.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (abriendoDesplegable)
        {
            textoEditar.gameObject.SetActive(true);
            LeanTween.moveLocalY(desplegableAbajo, -218f, durationAnim).setEase(LeanTweenType.linear);
            LeanTween.moveLocalY(textoBienvenida.gameObject, 273f, durationAnim).setEase(LeanTweenType.linear);
            LeanTween.moveLocalX(textoEditar.gameObject, 0f, durationAnim).setEase(LeanTweenType.linear);

        }

        if (abrirLateral)
        {
                textoEditar.gameObject.SetActive(false);
                LeanTween.moveLocalX(pantallaLateral, 275f, durationAnim).setEase(LeanTweenType.linear);
                textoEditar.gameObject.SetActive(false);
                
  
        }
    }

        

    public void AbrirDesplegable()
    {
        abriendoDesplegable = true;
        flechaAbajo.SetActive(false);
    }
    public void AbrirCreador()
    {
        abrirLateral = true;
    }

}
