using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Notes:
// PlayerPrefs.GetInt("Upgrade1Level") ve PlayerPrefs.GetInt("Upgrade2Level")'i kontrol ederek upgrade..
//..sisteminin mevcut level'ini cekebilirsiniz.
public class UpgradeSystemManager : MonoBehaviour
{
    public int upgrade1BeginMoney;
    public int upgrade1IncreasingMoneyAmountPerLevel;

    public int upgrade2BeginMoney;
    public int upgrade2IncreasingMoneyAmountPerLevel;

    public int upgrade3BeginMoney;
    public int upgrade3IncreasingMoneyAmountPerLevel;

    internal GameObject upgrade1GameObject;
    Button upgrade1Button;
    Image upgrade1Image;
    TextMeshProUGUI upgarede1LevelText;
    Image upgrade1MoneyImage;
    TextMeshProUGUI upgrade1MoneyText;

    internal GameObject upgrade2GameObject;
    Button upgrade2Button;
    Image upgrade2Image;
    TextMeshProUGUI upgarede2LevelText;
    Image upgrade2MoneyImage;
    TextMeshProUGUI upgrade2MoneyText;

    internal GameObject upgrade3GameObject;
    Button upgrade3Button;
    Image upgrade3Image;
    TextMeshProUGUI upgarede3LevelText;
    Image upgrade3MoneyImage;
    TextMeshProUGUI upgrade3MoneyText;

    void Start()
    {
        InitObjects();
        SetUpgradeSystem();
        upgrade1GameObject.SetActive(true);
        upgrade2GameObject.SetActive(true);
        upgrade3GameObject.SetActive(true);
    }

    void OnClickUpgrade1()
    {
        if (PlayerPrefs.GetFloat("Money") < int.Parse(upgrade1MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade1Level", PlayerPrefs.GetInt("Upgrade1Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade1Money"));
        PlayerPrefs.SetInt("Upgrade1Money", (PlayerPrefs.GetInt("Upgrade1Money") + (PlayerPrefs.GetInt("Upgrade1Level") + 5)));

        upgrade1MoneyText.text = PlayerPrefs.GetInt("Upgrade1Money").ToString();
        upgarede1LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade1Level").ToString();



        SetUpgradeSystem();
        //FindObjectOfType<Upgrades>().UpgradeSpeed(PlayerPrefs.GetInt("Upgrade1Level"));
        FindObjectOfType<TapAndHold>().SpeedUpgrade(); //speed upgrade
    }

    void OnClickUpgrade2()
    {
        if (PlayerPrefs.GetFloat("Money") < int.Parse(upgrade2MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade2Level", PlayerPrefs.GetInt("Upgrade2Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade2Money"));
        PlayerPrefs.SetInt("Upgrade2Money", (PlayerPrefs.GetInt("Upgrade2Money") +(PlayerPrefs.GetInt("Upgrade2Level")+5)));

        upgrade2MoneyText.text = PlayerPrefs.GetInt("Upgrade2Money").ToString();
        upgarede2LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade2Level").ToString();

        SetUpgradeSystem();
        FindObjectOfType<TapAndHold>().IncomeUpgrade();
        //FindObjectOfType<MoneyManager>().minMoney = 0.8f + (PlayerPrefs.GetInt("Upgrade2Level") * 0.2f); //income upgrade
        //FindObjectOfType<MoneyManager>().maxMoney = 0.8f + (PlayerPrefs.GetInt("Upgrade2Level") * 0.2f); //income upgrade
    }
    void OnClickUpgrade3()
    {
        if (PlayerPrefs.GetFloat("Money") < int.Parse(upgrade3MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade3Level", PlayerPrefs.GetInt("Upgrade3Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade3Money"));
        PlayerPrefs.SetInt("Upgrade3Money", (PlayerPrefs.GetInt("Upgrade3Money") + (PlayerPrefs.GetInt("Upgrade3Level") + 5)));

        upgrade3MoneyText.text = PlayerPrefs.GetInt("Upgrade3Money").ToString();
        upgarede3LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade3Level").ToString();

        SetUpgradeSystem();

        FindObjectOfType<TapAndHold>().StaminaUpgrade(); //stamina upgrade
    }

    void SetUpgradeSystem()
    {
        SetUpgrade1UpgradeSystem();
        SetUpgrade2UpgradeSystem();
        SetUpgrade3UpgradeSystem();
    }

    void SetUpgrade1UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade1Money"))
        {
            ColorBlock colors = upgrade1Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade1Button.colors = colors;
            upgrade1GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade1MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade1Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade1Button.colors = colors;
            upgrade1GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade1MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade2UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade2Money"))
        {
            ColorBlock colors = upgrade2Button.colors;
            colors.pressedColor = new Color(0.76f, 0.76f, 0.76f, 1);
            upgrade2Button.colors = colors;
            upgrade2GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade1Image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade2Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade2Button.colors = colors;
            upgrade2GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade1Image.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade3UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade3Money"))
        {
            ColorBlock colors = upgrade3Button.colors;
            colors.pressedColor = new Color(0.76f, 0.76f, 0.76f, 1);
            upgrade3Button.colors = colors;
            upgrade3GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade1Image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade3Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade3Button.colors = colors;
            upgrade3GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade1Image.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetMoney(int number)
    {
        float money = PlayerPrefs.GetFloat("Money");
        PlayerPrefs.SetFloat("Money", money - number);
        transform.Find("MoneyUI").transform.Find("MoneyText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("Money").ToString("F1");
    }

    void InitObjects()
    {
        upgrade1GameObject = transform.Find("Upgrade1").gameObject;
        upgrade1Button = upgrade1GameObject.GetComponent<Button>();
        upgrade1Button.onClick.AddListener(OnClickUpgrade1);
        upgrade1Image = transform.Find("Upgrade1").transform.Find("Image").GetComponent<Image>();
        upgarede1LevelText = transform.Find("Upgrade1").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade1MoneyImage = transform.Find("Upgrade1").transform.Find("Money").GetComponent<Image>();
        upgrade1MoneyText = transform.Find("Upgrade1").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        upgrade2GameObject = transform.Find("Upgrade2").gameObject;
        upgrade2Button = upgrade2GameObject.GetComponent<Button>();
        upgrade2Button.onClick.AddListener(OnClickUpgrade2);
        upgrade1Image = transform.Find("Upgrade2").transform.Find("Image").GetComponent<Image>();
        upgarede2LevelText = transform.Find("Upgrade2").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade2MoneyImage = transform.Find("Upgrade2").transform.Find("Money").GetComponent<Image>();
        upgrade2MoneyText = transform.Find("Upgrade2").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        upgrade3GameObject = transform.Find("Upgrade3").gameObject;
        upgrade3Button = upgrade3GameObject.GetComponent<Button>();
        upgrade3Button.onClick.AddListener(OnClickUpgrade3);
        upgrade1Image = transform.Find("Upgrade3").transform.Find("Image").GetComponent<Image>();
        upgarede3LevelText = transform.Find("Upgrade3").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade3MoneyImage = transform.Find("Upgrade3").transform.Find("Money").GetComponent<Image>();
        upgrade3MoneyText = transform.Find("Upgrade3").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        ConfigureInitializedObjects();
    }

    void ConfigureInitializedObjects()
    {

        if (PlayerPrefs.GetInt("Upgrade1Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade1Level", 1);
            upgarede1LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade1Level").ToString();
        }
        else
        {
            upgarede1LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade1Level").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade2Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade2Level", 1);
            upgarede2LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade2Level").ToString();
        }
        else
        {
            upgarede2LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade2Level").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade3Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade3Level", 1);
            upgarede3LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade3Level").ToString();
        }
        else
        {
            upgarede3LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade3Level").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade1Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade1Money", upgrade1BeginMoney);
            upgrade1MoneyText.text = PlayerPrefs.GetInt("Upgrade1Money").ToString();
        }
        else
        {
            upgrade1MoneyText.text = PlayerPrefs.GetInt("Upgrade1Money").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade2Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade2Money", upgrade2BeginMoney);
            upgrade2MoneyText.text = PlayerPrefs.GetInt("Upgrade2Money").ToString();
        }
        else
        {
            upgrade2MoneyText.text = PlayerPrefs.GetInt("Upgrade2Money").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade3Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade3Money", upgrade3BeginMoney);
            upgrade3MoneyText.text = PlayerPrefs.GetInt("Upgrade3Money").ToString();
        }
        else
        {
            upgrade3MoneyText.text = PlayerPrefs.GetInt("Upgrade3Money").ToString();
        }
    }
}
