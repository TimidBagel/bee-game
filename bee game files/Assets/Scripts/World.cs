using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public List<string> WeatherTypes;
    public string Weather;
    public float shiftRate;
    public TMPro.TextMeshProUGUI WeatherReading;
        
    public IEnumerator weatherShift()
    {
        Weather = WeatherTypes[Random.Range(0,  WeatherTypes.Count)];
        yield return new WaitForSeconds(shiftRate);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("weatherShift");
    }

    // Update is called once per frame
    void Update()
    {
        WeatherReading.text = "Current Weather:" + Weather;
    }
}
