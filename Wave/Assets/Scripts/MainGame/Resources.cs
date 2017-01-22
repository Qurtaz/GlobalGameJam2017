using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

    static int Money, Health, Income;
    public GameObject MoneyText, HealthText, IncomeText;
    

    public void ChangeMoney(int change)
    {
        Money += change;
        MoneyText.GetComponent<Text>().text = "Money: " + Money.ToString();
    }

    public void ChangeHealth(float people, float maxPeople)
    {
        float ratio = (people / maxPeople) * 100;
        Health = Mathf.RoundToInt(ratio);
        HealthText.GetComponent<Text>().text = "Health: " + Health.ToString() + "%";
    }

    public void ChangeIncome(float people, float income)
    {
        Income = Mathf.RoundToInt((people * NormalBuilding.incomeWeight) * income);

        IncomeText.GetComponent<Text>().text = "Income: " + Income.ToString();
    }

    public void CalculateHealth()
    {
        //GameObject[] 
        //foreach (GameObject panel in Panels)
        //{
        //    panel.SetActive(false);
        //}
        ChangeHealth(10,100);
    }
}
