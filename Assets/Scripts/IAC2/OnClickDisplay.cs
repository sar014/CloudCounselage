using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickDisplay : MonoBehaviour
{
    public Manager manager;
    public bool OnClick;   
    public Canvas CareerOpportunity;
    // public Transform player;

    void Start()
    {
        OnClick = false;
    }
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0) && manager.OnClick==false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Draw the ray in the Scene view
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform && CompareTag("Clickable"))
                {
                    displayInfo();
                    manager.OnClick = true;
                }
            }
        }       
    }

    public void OnButtonClick()
    {
        CareerOpportunity.gameObject.SetActive(false);
        manager.OnClick = false;
    }

    void displayInfo()
    {
        if (CareerOpportunity != null)
        {
            CareerOpportunity.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("CareerOpportunity Canvas is not assigned!");
        }
    }
}
