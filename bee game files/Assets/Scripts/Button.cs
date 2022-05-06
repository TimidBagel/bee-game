using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Player player;
    public TMPro.TextMeshProUGUI text;
    public TMPro.TextMeshProUGUI ToolTip;
    public float HoneyNeeded;
    public bool Unlocked;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Player>();
        if (name.Contains("Fact"))
        {
            ToolTip.enabled = false;
        }
        
    }
    private void OnMouseUpAsButton()
    {
        if(name == "BuyBee" && player.Honey >= player.CostofBees)
        {
            Debug.Log("ButtonClicked!");
            player.bees += 1;
            player.Honey -= player.CostofBees;
            player.CostofBees += (player.CostofBees * 0.55f);
        }
        if(name == "BuyDaisy" && player.Honey >= player.costOfDaisies)
        {
            player.Daisies += 1;
            player.Honey -= player.costOfDaisies;
            player.costOfDaisies += (player.costOfDaisies * 0.55f);
        }
        if (name == "BuySun" && player.Honey >= player.CostOfSunflowers)
        {
            player.Sunflowers += 1;
            player.Honey -= player.CostOfSunflowers;
            player.CostOfSunflowers += (player.CostOfSunflowers * 0.55f);
        }
        if(name == "BuyOrchid" && player.Honey >= player.costOfOrchids)
        {
            player.Orchids += 1;
            player.Honey -= player.costOfOrchids;
            player.costOfOrchids += (player.costOfOrchids * 0.55f);
        }
        if (name == "BuyMilkweed" && player.Honey >= player.costOfMilkWeed)
        {
            player.MilkWeeds += 1;
            player.Honey -= player.costOfMilkWeed;
            player.costOfMilkWeed += (player.costOfMilkWeed * 0.55f);
        }
    }  
    private void OnMouseEnter()
    {
        if(Unlocked)
        {
            ToolTip.enabled = true;
        }
        

    }
    private void OnMouseExit()
    {
        ToolTip.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(player.Honey >= HoneyNeeded)
        {
            Unlocked = true;
        }
        if(name == "BuyBee")
        {
            text.text = "Purchase Bee  " + Mathf.RoundToInt(player.CostofBees).ToString();
        }
        if(name == "BuyDaisy")
        {
            text.text = "Purchase Daisy  " + Mathf.RoundToInt(player.costOfDaisies).ToString();
        }
        if (name == "BuySun")
        {
            text.text = "Purchase Sunflower  " + Mathf.RoundToInt(player.CostOfSunflowers).ToString();
        }
        if(name == "BuyOrchid")
        {
            text.text = "Purchase Lily of the Valley  " + Mathf.RoundToInt(player.costOfOrchids).ToString();
        }
        if (name == "BuyMilkweed")
        {
            text.text = "Purchase Milkweed  " + Mathf.RoundToInt(player.costOfMilkWeed).ToString();
        }
    }
}
