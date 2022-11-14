using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCheck : MonoBehaviour
{
    public bool flourEnteredBowl = false;
  
    
    Rigidbody rb;
    public Transform flourHoldArea;
    public Transform saltSugarHoldArea;
    public Transform btJuiceHoldArea;
    public TMP_Text steps;
    
    public GameObject mixingUI;
    public GameObject mixingSlider;
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");

        if (other.gameObject.tag == "bowlTrigger" )
        {
            if (gameObject.tag == "flour")
            {
                flourEnteredBowl = true;
                adjustComponents();
                
                gameObject.transform.position = flourHoldArea.position;
                
            }
           
            if(gameObject.tag == "saltnSugar")
            {
                
                adjustComponents();
               
                gameObject.transform.position = saltSugarHoldArea.position;
                steps.text = "tap all the buttons in the correct order to mix the dry ingredients";
               

                mixingUI.SetActive(true);
                mixingSlider.SetActive(true);
            }

            if(gameObject.tag == "btJuice")
            {
                adjustComponents();
                gameObject.transform.position= btJuiceHoldArea.position;
                steps.text = "tap all the buttons in the correct order to mix the ingredients into a dough";
                mixingUI.SetActive(true);
                mixingSlider.GetComponent<Slider>().value= 0;
                mixingSlider.SetActive(true);
            }


        }
       

    }

    void adjustComponents()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = 10;
        Destroy(gameObject.GetComponent<Lean.Touch.LeanDragTranslate>());
        Destroy(rb);
    }
    
}