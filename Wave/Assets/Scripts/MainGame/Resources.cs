using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

    static int Money, Health, Income;
    public GameObject MoneyText, HealthText, IncomeText;

    public void ChangeMoney(int change)
    {
        Money += change;
        MoneyText.GetComponent<Text>().text = Money.ToString();
    }

    public void ChangeHealth(float people, float maxPeople)
    {
        float ratio = (people / maxPeople)*100;

        Health = Mathf.RoundToInt(ratio);

        HealthText.GetComponent<Text>().text = Health.ToString() + "%";
    }

    public void ChangeIncome(float people, float income)
    {
        float weight = 0.1f;
        Income = Mathf.RoundToInt((people*weight) * income);

        IncomeText.GetComponent<Text>().text = Income.ToString();
    }
}
