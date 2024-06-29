using System;
using UnityEngine;

public class SaveWallet : MonoBehaviour
{
    // Основной скрипт сохранения 
    [Header("C#")]
    [SerializeField] private Wallet wallet;

    public static event Action UpdateWalletUIStartGameSave; // Тут мы сообщаем кошельку что в него выгружаем сохранённые деньги

    public void Awake()
    {
        LoadSaveWallet();
    }

    public void _SaveWallet()
    {
        PlayerPrefs.SetInt("Coin", wallet.Coin);
    }
    public void LoadSaveWallet()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            wallet.Coin = PlayerPrefs.GetInt("Coin");
            UpdateWalletUIStartGameSave?.Invoke();
        }
    }
}
