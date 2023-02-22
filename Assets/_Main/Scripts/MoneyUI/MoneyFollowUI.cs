using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoneyFollowUI : MonoBehaviour
{
    Transform target;
    internal float minMoney;
    internal float maxMoney;
    TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText = GameObject.Find("Canvas").transform.Find("MoneyUI").transform.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        minMoney = FindObjectOfType<MoneyManager>().minMoney;
        maxMoney = FindObjectOfType<MoneyManager>().maxMoney;
        target = GameObject.FindGameObjectWithTag("Follow").transform;

        GetComponent<TextMeshProUGUI>().text = "+$ " + minMoney.ToString();
        //GetComponent<TextMeshProUGUI>().color = Color32.Lerp(GetComponent<TextMeshProUGUI>().color, new Color32(0, 137, 116, 0), 1);

        GetComponent<TextMeshProUGUI>().DOFade(0, 1.5f).OnComplete(() =>
        {
            float textInt = float.Parse(moneyText.text);
            moneyText.text = (textInt + Random.Range(minMoney, maxMoney)).ToString("F1");
            PlayerPrefs.SetFloat("Money", float.Parse(moneyText.text));
            Destroy(gameObject);
        });
    }
}