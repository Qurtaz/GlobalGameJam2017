using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

    public static int Money, Health, Income;
    public GameObject nsMoneyText, nsHealthText, nsIncomeText;
    public static GameObject MoneyText, HealthText, IncomeText;

    void Start()
    {
        MoneyText = nsMoneyText;
        HealthText = nsHealthText;
        IncomeText = nsIncomeText;
        ChangeMoney(3000);
        CalculateHealth();
    }

    public static void ChangeMoney(int change)
    {
        Money += change;
        MoneyText.GetComponent<Text>().text = "Money: " + Money.ToString();
    }

    public static void ChangeHealth(float people, float maxPeople)
    {
        float ratio = (people / maxPeople) * 100;
        Health = Mathf.RoundToInt(ratio);
        HealthText.GetComponent<Text>().text = "Health: " + Health.ToString() + "%";
    }

    public static void ChangeIncome(float people, float income)
    {
        Income = Mathf.RoundToInt((people * NormalBuilding.incomeWeight) * income);

        IncomeText.GetComponent<Text>().text = "Income: " + Income.ToString();
    }

    public void CalculateHealth()
    {
        int allCurrentPeople = 0, maxCurrentPeople = 0;
        
        foreach (GameObject house in Generator.Houses)
        {
            if (house != null)
            {
                NormalBuilding normBuild = house.GetComponent<NormalBuilding>();
                maxCurrentPeople += normBuild.maxPeople;
                allCurrentPeople += normBuild.currentPeople;
            }
        }
        Debug.Log("HP");
        ChangeHealth(allCurrentPeople,maxCurrentPeople);
    }
}
