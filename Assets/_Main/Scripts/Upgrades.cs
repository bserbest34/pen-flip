using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    TapAndHold manager;


    private void Start()
    {
        //UpgradeSpeed(PlayerPrefs.GetInt("Upgrade1Level"));
    }
    private void Update()
    {
        //UpgradeSpeed(PlayerPrefs.GetInt("Upgrade1Level"));
    }
    internal void UpgradeSpeed(int level)
    {
        switch (level)
        {
            case 1:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1);
                break;
            case 2:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.1f);
                break;
            case 3:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.2f);
                break;
            case 4:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.3f);
                break;
            case 5:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.4f);
                break;
            case 6:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.5f);
                break;
            case 7:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.6f);
                break;
            case 8:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.7f);
                break;
            case 9:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.8f);
                break;
            case 10:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 1.9f);
                break;
            case 11:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2);
                break;
            case 12:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.1f);
                break;
            case 13:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.2f);
                break;
            case 14:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.3f);
                break;
            case 15:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.4f);
                break;
            case 16:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.5f);
                break;
            case 17:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.6f);
                break;
            case 18:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.7f);
                break;
            case 19:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.8f);
                break;
            case 20:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 2.9f);
                break;
            case 21:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3f);
                break;
            case 22:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.1f);
                break;
            case 23:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.2f);
                break;
            case 24:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.3f);
                break;
            case 25:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.4f);
                break;
            case 26:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.5f);
                break;
            case 27:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.6f);
                break;
            case 28:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.7f);
                break;
            case 29:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.8f);
                break;
            case 30:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 3.9f);
                break;
            case 31:
                PlayerPrefs.SetFloat("MaxAnimSpeed", 4f);
                break;
            default:
                break;
        }
    }
}
