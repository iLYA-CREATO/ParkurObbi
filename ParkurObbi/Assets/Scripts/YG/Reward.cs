using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reward : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    public static event Action UpdateWalletUIRecklamCoin; // Тут мы сообщаем кошельку что в него выгружаем сохранённые деньги
    public GameObject PanelRecklam;


    // Подписанный метод получения награды
    public void RewardedEvent()
    {
        wallet.Coin += 30;
        UpdateWalletUIRecklamCoin?.Invoke();
        PanelRecklam.SetActive(false);
        Debug.Log("NiceRecklam");

    }

    public void ErroVideoEvent()
    {
        PanelRecklam.SetActive(false);

        Debug.Log("ErrorRecklam");
    }
}
