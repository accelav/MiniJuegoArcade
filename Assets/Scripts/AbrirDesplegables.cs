using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbrirDesplegables : MonoBehaviour
{
    [SerializeField]
    GameObject desplegableAbajo;
    [SerializeField]
    GameObject flechaAbajo;


    bool isActive = false;
    public float durationAnimation = 0.75f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            LeanTween.moveLocalY(desplegableAbajo, -230f, durationAnimation).setEase(LeanTweenType.linear);

        }
    }

    public void AbrirDesplegable()
    {
        isActive = true;
        flechaAbajo.SetActive(false);
    }


}
