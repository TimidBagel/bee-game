using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public List<string> WeatherTypes;
    public string Weather;
    public float shiftRate;
    public TMPro.TextMeshProUGUI WeatherReading;
    public SpriteRenderer Filter;
    public Player player;
    
    void ShiftWeather()
    {
        Weather = WeatherTypes[Random.Range(0, WeatherTypes.Count)];
        if(Weather == "Windy")
        {
            player.Dandelions += Mathf.RoundToInt(player.Dandelions * Random.Range(0, 0.2f));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Weather = "Normal";
        InvokeRepeating("ShiftWeather", shiftRate, shiftRate);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        WeatherReading = GameObject.Find("Weather Reader").GetComponent<TMPro.TextMeshProUGUI>();
        Filter = GameObject.Find("Filter").GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
        WeatherReading.text = "Current Weather:" + Weather;
        if(Weather == "Normal")
        {
            Filter.color = new Color(Filter.color.r, Filter.color.g, Filter.color.b, 0);
        }
        else if(Weather == "Sunny")
        {
            Filter.color = new Color(.63f, .75f, .217f, 0.32f);
        }
        else if(Weather == "Rainy")
        {
            Filter.color = new Color(.255f, .246f, .95f, 0.32f);
        }
        else if(Weather == "Windy")
        {
            Filter.color = new Color(.215f, .255f, .248f, 0.32f);
        }
    }
}
