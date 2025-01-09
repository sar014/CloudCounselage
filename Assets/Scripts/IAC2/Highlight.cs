using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public GameObject HighlightPrefab;
    public Manager manager;
    GameObject childGameObject;
    public GameObject highlitedBuild;
    // Start is called before the first frame update
    void Start()
    {
        Transform childTransform = HighlightPrefab.transform.Find("HCube");
        childGameObject = childTransform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Function has to be called every frame to keep track of when the building changes
        if(highlitedBuild!=null)
        {
            //Enables the building when its highlighted/press enter
            manager.EnableBuilding(highlitedBuild);
        }
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            highlitedBuild = this.gameObject;
            childGameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player")
        {
            childGameObject.SetActive(false);

            //Removing the highlighted game object after exit so that varible can be updated when a plyer moves to a new building
            highlitedBuild = null;
        }
        
    }
}
