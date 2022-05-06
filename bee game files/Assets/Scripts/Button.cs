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
        if(name == "Purchase Bee")
        {
            text.text = "Purchase Bee  " + Mathf.RoundToInt(player.CostofBees).ToString() + ".00";
        }
        if(name == "Purchase Daisy")
        {
            text.text = "Purchase Daisy  " + Mathf.RoundToInt(player.costOfDaisies).ToString() + ".00";
        }
        if (name == "Purchase Sunflower")
        {
            text.text = "Purchase Sunflower\n$" + Mathf.RoundToInt(player.CostOfSunflowers).ToString() + ".00";
        }
        if(name == "Purchase Lily")
        {
            text.text = "Purchase Lily of the Valley\n$" + Mathf.RoundToInt(player.costOfOrchids).ToString() + ".00";
        }
        if (name == "Purchase Milkweed")
        {
            text.text = "Purchase Milkweed\n$" + Mathf.RoundToInt(player.costOfMilkWeed).ToString() + ".00";
        }
    }
}
