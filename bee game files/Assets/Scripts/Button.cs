using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Player player;
    public TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void OnMouseUpAsButton()
    {
        if(name == "BuyBee" && player.Honey >= player.CostofBees)
        {
            Debug.Log("ButtonClicked!");
            player.bees += 1;
            player.Honey -= player.CostofBees;
            player.CostofBees += (player.CostofBees * 0.15f);
        }
        if(name == "BuyDaisy" && player.Honey >= player.costOfDaisies)
        {
            player.Daisies += 1;
            player.Honey -= player.costOfDaisies;
            player.costOfDaisies += (player.costOfDaisies * 0.15f);
        }
        if (name == "BuySun" && player.Honey >= player.CostOfSunflowers)
        {
            player.Sunflowers += 1;
            player.Honey -= player.CostOfSunflowers;
            player.CostOfSunflowers += (player.CostOfSunflowers * 0.15f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(name == "BuyBee")
        {
            text.text = "Purchse Bee  " + Mathf.RoundToInt(player.CostofBees).ToString();
        }
        if(name == "BuyDaisy")
        {
            text.text = "Purchse Daisy  " + Mathf.RoundToInt(player.costOfDaisies).ToString();
        }
        if (name == "BuySun")
        {
            text.text = "Purchse Sunflower  " + Mathf.RoundToInt(player.CostOfSunflowers).ToString();
        }

    }
}
