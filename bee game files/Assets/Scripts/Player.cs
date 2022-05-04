using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bees;
    public GameObject baseBee;
    public float Honey;
    public float Daisies;
    public GameObject Daisy;
    public float costOfDaisies = 100;
    public float CostofBees = 50;
    public float AddedHoney;
    float DaisyMultiplier; // Value Set in Update Function
    public World world;
    public TMPro.TextMeshProUGUI HoneyCounter;
    public float DaisyPower;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addHoney", 1, 1);
    }
    void addHoney()
    {
        Honey += AddedHoney;
    }
    void calcRate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        AddedHoney = (bees * DaisyMultiplier) - bees;
        HoneyCounter.text = "Honey:"+ Mathf.RoundToInt(Honey).ToString();
        if (Input.GetKeyUp("b") && Honey >= CostofBees)
        {
            bees += 1;
            Honey -= CostofBees;
            CostofBees += (CostofBees * 0.05f);
        }
        if(Input.GetKeyUp("d") && Honey >= costOfDaisies)
        {
            Daisies += 1;
            Honey -= costOfDaisies;
            costOfDaisies += (costOfDaisies * 0.05f);
        }
            
        
       
        GameObject[] amountBees = GameObject.FindGameObjectsWithTag("Bees");
        GameObject[] amountDaisies = GameObject.FindGameObjectsWithTag("Daisies");
        DaisyMultiplier = (Daisies * DaisyPower);
        if(amountBees.Length < bees)
        {
            Instantiate(baseBee, new Vector3(transform.position.x + Random.Range(-75, 75), transform.position.y + Random.Range(-45, 45)), Quaternion.identity);
        }
        else if(amountBees.Length > bees)
        {
            for(float i = amountBees.Length - bees; i > 0; i--)
            {
                Destroy(GameObject.FindWithTag("Bees"));
            }
            
        }

        if (amountDaisies.Length < Daisies)
        {
            Instantiate(Daisy, new Vector3(transform.position.x + Random.Range(-75, 75), transform.position.y + Random.Range(-45, 45)), Quaternion.identity);
        }
        else if (amountDaisies.Length > Daisies)
        {
            for (float i = amountBees.Length - bees; i > 0; i--)
            {
                Destroy(GameObject.FindWithTag("Daisies"));
            }

        }

    }
}
