using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class AbrirDesplegables : MonoBehaviour
{
    
    [SerializeField]
    GameObject pantallaLateral;
    [SerializeField]
    float durationAnim = 0.25f;
    [SerializeField]
    GameObject desplegableAbajo;
    [SerializeField]
    GameObject flechaAbajo;
    [SerializeField]
    GameObject textoBienvenida;
    [SerializeField]
    GameObject textoEditar;
 
    


    

    bool abrirLateral = false;
    bool abriendoDesplegable = false;
    // Start is called before the first frame update
    void Start()
    {
        textoBienvenida.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (abriendoDesplegable)
        {
            
            LeanTween.moveLocalY(desplegableAbajo, 69f, durationAnim).setEase(LeanTweenType.linear);
            LeanTween.moveLocalY(textoBienvenida, 375f, durationAnim).setEase(LeanTweenType.linear);
            LeanTween.moveLocalX(textoEditar, -144f, durationAnim).setEase(LeanTweenType.linear);

        }

        if (abrirLateral)
        {
                

                
                LeanTween.moveLocalX(pantallaLateral, -146f, durationAnim).setEase(LeanTweenType.linear);
                textoEditar.SetActive(false);

;
                
                
                
  
        }
    }

        

    public void AbrirDesplegable()
    {
        abriendoDesplegable = true;
        flechaAbajo.SetActive(false);
        textoEditar.SetActive(true);
    }
    public void AbrirCreador()
    {
        abrirLateral = true;
        textoEditar.gameObject.SetActive(false);
    }

}
