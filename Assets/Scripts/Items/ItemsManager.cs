using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using UnityEditor.PackageManager.Requests;

public class ItemsManager : Singleton<ItemsManager>
{
    [Header("Coins")]
    public int coins;
    public TextMeshProUGUI coinsNumber;

    public void CoinsCounter()
    {
        coinsNumber.text = "x" + coins.ToString();
    }

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        coins = 0;

        CoinsCounter();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;

        CoinsCounter();
    }
}
