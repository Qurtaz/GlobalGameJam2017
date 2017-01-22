using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

    static int Money, Health, Income;
    public GUIText MoneyText, HealthText, IncomeText;

    public void ChangeMoney(int change)
    {
        Money += change;
        MoneyText.text = Money.ToString();
    }

    public void ChangeHealth(int people, int maxPeople)
    {
        float ratio = (people / maxPeople)*100;

        Health = Mathf.RoundToInt(ratio);

        HealthText.text = Health.ToString();
    }

    public void ChangeIncome(int people, int income)
    {
        float weight = 0.1f;
        Income = Mathf.RoundToInt((people*weight) * income);

        IncomeText.text = Income.ToString();
    }
}
