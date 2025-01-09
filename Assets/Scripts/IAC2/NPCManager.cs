using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public List<GameObject> npcList;
    private int count = 0;
    private bool isSpawning = false;

    void Update()
    {
        if (count <= 2 && !isSpawning)
        {
            StartCoroutine(CreateNPCs());
        }
        
    }

    IEnumerator CreateNPCs()
    {
        isSpawning = true;  // Indicate that the coroutine is running

        while (count <= 2)   // Loop until 3 NPCs have been created
        {
            Vector3 newPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            count++;
            int index = Random.Range(0, npcList.Count);
            GameObject npc = npcList[index];
            Instantiate(npc, newPosition,this.transform.rotation);
            yield return new WaitForSeconds(Random.Range(0,20f));  
        }
        isSpawning = false;
        count = 0;  
        yield return new WaitForSeconds(10f);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
        }
        
    }

}
