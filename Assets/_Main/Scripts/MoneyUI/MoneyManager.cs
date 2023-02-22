using System.Collections;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public GameObject instantiatedMoney;
    public GameObject instantiatedMoneyText;
    public float minMoney;
    public float maxMoney;
    Vector3 beginMoneyPoint;

    private void Start()
    {
        //minMoney = 0.8f + (PlayerPrefs.GetInt("Upgrade2Level") * 0.2f);
        //maxMoney = 0.8f + (PlayerPrefs.GetInt("Upgrade2Level") * 0.2f);
        GameObject.Find("Canvas").transform.Find("MoneyUI").transform.Find("MoneyText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("Money").ToString("F1");
        beginMoneyPoint = transform.Find("MoneyUI").transform.Find("aaasss").transform.position;
    }

    public void InstantiateMoney(int count)
    {
        minMoney = PlayerPrefs.GetFloat("minMoney", 1f);
        maxMoney = PlayerPrefs.GetFloat("maxMoney", 1f);
        StartCoroutine(SetMoneyToUI(count, minMoney, maxMoney));
    }

    private IEnumerator SetMoneyToUI(int count, float minMoney, float maxMoney)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(instantiatedMoneyText, beginMoneyPoint, Quaternion.identity, GameObject.Find("Canvas").transform);
            instantiatedMoneyText.GetComponent<MoneyFollowUI>().minMoney = minMoney;
            instantiatedMoneyText.GetComponent<MoneyFollowUI>().maxMoney = maxMoney;
            float oldMinMoney = PlayerPrefs.GetFloat("minMoney", 0.5f);
            instantiatedMoneyText.GetComponent<TMPro.TextMeshProUGUI>().text = "+" + Mathf.RoundToInt(oldMinMoney * 10);
            yield return new WaitForSeconds(1f);
        }
    }
}
