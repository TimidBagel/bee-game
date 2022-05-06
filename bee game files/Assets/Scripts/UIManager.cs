using UnityEngine;

public class UIManager : MonoBehaviour
{
	public Player player;
	public GameObject storePannel;
	public GameObject storeButton;
	public GameObject factPannel;
	public void OpenStore() // hopefully add an animation for opening the store
	{
		storePannel.SetActive(true);
		factPannel.SetActive(false);
		storeButton.SetActive(false);
	}
	public void CloseStore()
	{
		storePannel.SetActive(false);
		factPannel.SetActive(false);
		storeButton.SetActive(true);
	}
	public void PurchaseBee()
	{
		if (player.Honey >= player.CostofBees)
		{
			player.bees++;
			player.Honey -= player.CostofBees;
			player.CostofBees += (player.CostofBees * 0.55f);
		}
	}
	public void PurchaseDaisy()
	{
		if (player.Honey >= player.costOfDaisies)
		{
			player.Daisies++;
			player.Honey -= player.costOfDaisies;
			player.costOfDaisies += (player.costOfDaisies * 0.55f);
		}
	}
	public void PurchaseSunflower()
	{
		if (player.Honey >= player.CostOfSunflowers)
		{
			player.Sunflowers++;
			player.Honey -= player.CostOfSunflowers;
			player.CostOfSunflowers += (player.CostOfSunflowers * 0.55f);
		}
	}
	public void PurchaseOrchid()
	{
		if (player.Honey >= player.costOfOrchids)
		{
			player.Orchids++;
			player.Honey -= player.costOfOrchids;
			player.costOfOrchids += (player.costOfOrchids * 0.55f);
		}
	}
	public void PurchaseMilkweed()
	{
		if (player.Honey >= player.costOfMilkWeed)
		{
			player.MilkWeeds++;
			player.Honey -= player.costOfMilkWeed;
			player.costOfMilkWeed += (player.costOfMilkWeed * 0.55f);
		}
	}
	public void ViewFactsPage()
	{
		factPannel.SetActive(true);
	}
}
