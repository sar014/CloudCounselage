using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public bool OnClick = false;
    public LiftFunctions liftFunctions;
    public List<GameObject> builds;
    public GameObject Finalbuild;
    public GameObject WelcomeScreen;
    public GameObject RulesPage;
    public Animator alreadyVisted;
 
    [SerializeField] GameObject outsideEnvironment;
    [SerializeField] GameObject InsideLift;
    [SerializeField] GameObject OutsideLift; 
    [SerializeField] List<GameObject> buildingVisited; 

    GameObject[] inactiveObjects;  

    private void Start() {
        //Helps in finding all objects: active and inactive
        inactiveObjects = Resources.FindObjectsOfTypeAll<GameObject>();
    }

    public void StartGame()
    {
        outsideEnvironment.SetActive(true);
        WelcomeScreen.SetActive(false); 
    }  

    public void Rules()
    {
        RulesPage.SetActive(true);
        outsideEnvironment.SetActive(false);
        WelcomeScreen.SetActive(false); 
    }

    public void BackToWelcomeScreen()
    {
        RulesPage.SetActive(false);
        WelcomeScreen.SetActive(true);
    }

    void Update() 
    {
        onEnterBuilding();
        
    }

    //After Entering building
    void onEnterBuilding()
    {
        //After doors of lift close, wait for sometime before quiz starts
        if(Input.GetKeyDown(KeyCode.Return) && Finalbuild!=null)
        {
            //After visiting building once you cant visit again
            if(buildingVisited.Contains(Finalbuild))
            {
                alreadyVisted.SetTrigger("FadeOut");
                Debug.Log("Alread Visited");
            }
            else
            {
                Debug.Log("Entered");
                Finalbuild.SetActive(true);
                outsideEnvironment.SetActive(false);
            }
           
        }
    }

    IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(5f);
        InsideLift.SetActive(true);
        Finalbuild.SetActive(false);
    }

    //After Entering lift. Called from LiftFunctions
    public void OnEnterLift()
    {
        StartCoroutine(WaitForSomeTime());
        
    }

    public void EnableBuilding(GameObject building)
    {
        // Debug.Log("GameObject Passed"+building.name);
        foreach(GameObject b in builds)
        {
            if(b.name==building.name)
            {
                Finalbuild = b;
                Debug.Log(Finalbuild.name);
                SetName(Finalbuild.name);
            }
        }    
    }

    //Helps in finding inside lift and outside lift for a particular building. Can be used depending on the building entering
    public void SetName(string name)
    {
        string insideLift_name = name+"Inside";
        string outsideLift_name = name+"Outside";
        // Debug.Log(insideLift_name);
        // Debug.Log(outsideLift_name);

        foreach (GameObject obj in inactiveObjects)
        {
            if (obj.name == insideLift_name)
            {
                InsideLift = obj;  // Assign the found inactive object
            }
            else if (obj.name == outsideLift_name)
            {
                OutsideLift = obj;  // Assign the found inactive object
            }
        }
    }


    //On clicking "Go back to Main Street" button
    public void GoBack()
    {
        buildingVisited.Add(Finalbuild);
        if(InsideLift==null)
        {
            Debug.Log(InsideLift.name+"Not Found");
        }
        else
        {
            outsideEnvironment.SetActive(true);
            
            OutsideLift.SetActive(false);
            InsideLift.SetActive(false);
        }
       
    }

    public void GoBackToMainGame()
    {
        SceneManager.LoadScene(0);
    }

}
