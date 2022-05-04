using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bees;
    public GameObject baseBee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            bees += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) && bees > 1) 
        {
            bees -= 1;
        }
        GameObject[] amountBees = GameObject.FindGameObjectsWithTag("Bees");
        Debug.Log(amountBees.Length);
       
        if(amountBees.Length < bees)
        {
            Instantiate(baseBee, new Vector3(transform.position.x + Random.Range(-55, 55), transform.position.y + Random.Range(-55, 55)), Quaternion.identity);
        }
        else if(amountBees.Length > bees)
        {
            for(float i = amountBees.Length - bees; i > 0; i--)
            {
                Destroy(GameObject.FindWithTag("Bees"));
            }
            
        }
        
    }
}
