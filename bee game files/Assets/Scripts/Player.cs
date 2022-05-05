using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float bees;
    public GameObject baseBee;
    public float Honey;
    public float Daisies;
    public GameObject Daisy;
    public float Sunflowers;
    public GameObject Sunflower;
    //Costs
    public float costOfDaisies = 100;
    public float CostofBees = 50;
    public float CostOfSunflowers = 150;
    public float AddedHoney;
    float DaisyMultiplier; // Value Set in Update Function
    [SerializeField] float SunMult;
    public World world;
    public TMPro.TextMeshProUGUI HoneyCounter;
    public float DaisyPower;
    public float SunflowerPower;
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
    void Regulate(string tag, float count, GameObject thingToSpawn)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        if (objects.Length < count)
        {
            if (SceneManager.GetActiveScene().name.Contains("Kit"))
            {
                Instantiate(thingToSpawn, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5)), Quaternion.identity);
            }
            else
            {
                Instantiate(thingToSpawn, new Vector3(Random.Range(-5, 5), 0.75f, Random.Range(-5, 5)), Quaternion.identity);

            }

        }
        else if (objects.Length > count)
        {
            for (float i = objects.Length - count; i > 0; i--)
            {
                Destroy(GameObject.FindWithTag(tag));
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        if(world.Weather == "Sunny")
        {
            SunflowerPower = 1.5f;
        }
        else
        {
            SunflowerPower = 1.1f;
        }
        
        HoneyCounter.text = "Honey:"+ Mathf.RoundToInt(Honey).ToString();
        if (Input.GetKeyUp("b") && Honey >= CostofBees)
        {
            bees += 1;
            Honey -= CostofBees;
            CostofBees += (CostofBees * 0.15f);
        }
        if(Input.GetKeyUp("d") && Honey >= costOfDaisies)
        {
            Daisies += 1;
            Honey -= costOfDaisies;
            costOfDaisies += (costOfDaisies * 0.55f);
        }
            
        if(Input.GetKeyUp("s") && Honey >= CostOfSunflowers)
        {
            Sunflowers += 1;
            Honey -= CostOfSunflowers;
            CostOfSunflowers += (CostOfSunflowers * 0.45f);
        }
       
        GameObject[] amountBees = GameObject.FindGameObjectsWithTag("Bees");
        GameObject[] amountDaisies = GameObject.FindGameObjectsWithTag("Daisies");
        GameObject[] amountSunFlowers = GameObject.FindGameObjectsWithTag("Sunflowers");
        DaisyMultiplier = (Daisies * DaisyPower);
        
        if (Sunflowers >= 1)
        {
            SunMult = (Sunflowers * SunflowerPower);
        }
        else
        {
            SunMult = 1;
        }
        AddedHoney = (bees * DaisyMultiplier * SunMult) - bees;
        Regulate("Bees", bees, baseBee);
        Regulate("Daisies", Daisies, Daisy);
        Regulate("Sunflowers", Sunflowers, Sunflower);

        //if (amountBees.Length < bees)
        //{
        //    if (SceneManager.GetActiveScene().name.Contains("Kit"))
        //    {
        //        Instantiate(baseBee, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5)), Quaternion.identity);
        //    }
        //    else
        //    {
        //        Instantiate(baseBee, new Vector3(Random.Range(-5, 5), 0.75f, Random.Range(-5, 5)), Quaternion.identity);

        //    }
           
        //}
        //else if(amountBees.Length > bees)
        //{
        //    for(float i = amountBees.Length - bees; i > 0; i--)
        //    {
        //        Destroy(GameObject.FindWithTag("Bees"));
        //    }
            
        //}

        //if (amountDaisies.Length < Daisies)
        //{
        //    if (SceneManager.GetActiveScene().name.Contains("Kit"))
        //    {
        //        Instantiate(Daisy, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5)), Quaternion.identity);
        //    }
        //    else
        //    {
        //        Instantiate(Daisy, new Vector3(Random.Range(-5, 5), 0.75f, Random.Range(-5, 5)), Quaternion.identity);

        //    }
        //}
        //else if (amountDaisies.Length > Daisies)
        //{
        //    for (float i = amountDaisies.Length - Daisies; i > 0; i--)
        //    {
        //        Destroy(GameObject.FindWithTag("Daisies"));
        //    }

        //}
        //if (amountSunFlowers.Length < Sunflowers)
        //{
        //    if (SceneManager.GetActiveScene().name.Contains("Kit"))
        //    {
        //        Instantiate(Sunflower, new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5)), Quaternion.identity);
        //    }
        //    else
        //    {
        //        Instantiate(Sunflower, new Vector3(Random.Range(-5, 5), 0.75f, Random.Range(-5, 5)), Quaternion.identity);

        //    }
        //}
        //else if (amountSunFlowers.Length > Sunflowers)
        //{
        //    for (float i = amountSunFlowers.Length - Sunflowers; i > 0; i--)
        //    {
        //        Destroy(GameObject.FindWithTag("Sunflowers"));
        //    }

        //}

    }
}
