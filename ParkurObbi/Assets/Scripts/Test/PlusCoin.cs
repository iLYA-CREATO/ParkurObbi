using System;
using UnityEngine;

public class PlusCoin : MonoBehaviour
{
    public Wallet wallet;
    public static event Action UpdateWalletUIPlusCoin; // Тут мы сообщаем кошельку что в нём другое кол-во валюты
    public void GetCoin()
    {
        wallet.Coin += 100;
        Debug.Log("Мы прибавили вам койны");
        UpdateWalletUIPlusCoin?.Invoke();
    }
}
