using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
	#region singleton

	public static Player playerInstance;
	private void Awake()
	{
		if (playerInstance != null)
		{
			Debug.LogWarning("More than one instance of player detected!");
			return;
		}
		playerInstance = this;
	}

	#endregion

	public float bees;
    public GameObject baseBee;
    public float Honey;
    //Daisies
    public float Daisies;
    public GameObject Daisy;
    public float costOfDaisies = 200;
    public float DaisyPower;
    float DaisyMultiplier; // Value Set in Update Function
    //
    public float Sunflowers;
    public float CostOfSunflowers = 550;
    [SerializeField] float SunMult;
    public GameObject Sunflower;
    public float SunflowerPower;
   

    public float CostofBees = 50;
   
    public float AddedHoney;
    //Orchids
    public float costOfOrchids = 550;
    public float OrchidPower;
    public GameObject Orchid;
    public float Orchids;
    public float OrchidMult;
    //
    //Milkweed
    public float costOfMilkWeed = 500;
    public float MilkWeedPower;
    public GameObject MilkWeed;
    public float MilkWeeds;
    public float MilkMult;
    //Dandelions
    public float costOfDandelions = 1000;
    public float DandelionPower;
    public GameObject Dandelion;
    public float Dandelions;
    public float DandMult;


    public World world;
    public TMPro.TextMeshProUGUI HoneyCounter;
   
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addHoney", 1, 1);
        DontDestroyOnLoad(gameObject);
        
        
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
                
            }
            else
            {
                if(thingToSpawn.name == "baseBee")
                {
                    Instantiate(thingToSpawn, new Vector3(0, 0.75f, 0), Quaternion.identity);
                   
                }
                else
                {
                    Instantiate(thingToSpawn, new Vector3(Random.Range(-15, 15), 0.75f, Random.Range(-15, 15)), Quaternion.identity);
                }
                

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
    void Beehive()
    {

    }
    void WeatherBoostedPlants(string Boostweather, float PowerToChange)
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Kit"))
        {
            HoneyCounter = GameObject.Find("HoneyCounter").GetComponent<TMPro.TextMeshProUGUI>();
        }
        DontDestroyOnLoad(GameObject.Find("Jazz"));
        
        world = GameObject.Find("WorldRunner").GetComponent<World>();

        if (world.Weather == "Rainy")
        {
            OrchidPower = 1.5f;
        }
        else
        {
            OrchidPower = 1.1f;
        }
        if(world.Weather == "Sunny")
        {
            SunflowerPower = 1.5f;
        }
        else
        {
            SunflowerPower = 1.1f;
        }
        if (world.Weather == "Windy")
        {
            MilkWeedPower = 1.5f;
        }
        else
        {
            MilkWeedPower = 1.1f;
        }

        HoneyCounter.text = "Honey:"+ Mathf.RoundToInt(Honey).ToString();
        
        
            
        
       
        DaisyMultiplier = (Daisies * DaisyPower);
        OrchidMult = (Orchids * OrchidPower);
        SunMult = (Sunflowers * SunflowerPower);
        if(OrchidMult == 0)
        {
            OrchidMult = 1;
        }
        if(SunMult == 0)
        {
            SunMult = 1;
        }
        if(MilkMult == 0)
        {
            MilkMult = 1;
        }
        if(DandMult == 0)
        {
            DandMult = 1;
        }
        AddedHoney = (bees * DaisyMultiplier * SunMult *OrchidMult *MilkMult * DandMult) - bees;
        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            Regulate("Bees", bees, baseBee);
            Regulate("Daisies", Daisies, Daisy);
            Regulate("Sunflowers", Sunflowers, Sunflower);
            Regulate("Orchids", Orchids, Orchid);
            Regulate("MilkWeeds", MilkWeeds, MilkWeed);
            Regulate("Dands", Dandelions, Dandelion);
        }
        
       
    }
}
