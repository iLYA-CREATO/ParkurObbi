using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SelAndBuy : MonoBehaviour
{
    // Ивенты
    public static event Action<int> ButtonSelect;
    public static event Action UpdateWalletUI; // Тут мы сообщаем кошельку что в нём другое кол-во валюты
    private Item Skin;
    private int idSkin;
    [SerializeField, Header("Кнопка выбора")] private Button buttonSelect;
    [SerializeField, Header("Кнопка покупки")] private Button buttonBuy;

    [Header("C#: ")]
    [SerializeField] private Wallet wallet;

    [Header("Bool: ")]
    [SerializeField] private bool isBuy;

    [Header("Form: ")]
    [SerializeField] private GameObject FormReword;
    
    public void Start()
    {
        
    }
    public void ChekBuyAndSelect(Item _skin) // Передаём сюда тот скин на который нажали кнопкой
    {
        Skin = _skin;
        if (Skin.Selected == true)
        {
            Skin.Purchased = true;
        }

        if (Skin.Purchased == true)
        {
            buttonBuy.interactable = false;
        }

        if (Skin.Purchased == false)
        {
            buttonBuy.interactable = true;
        }

        if (Skin.Selected == true)
        {
            buttonSelect.interactable = false;
        }

        if (Skin.Selected == false)
        {
            buttonSelect.interactable = true;
        }

        if (Skin.Selected == false && Skin.Purchased == false)
        {
            buttonSelect.interactable = true;
        }

        if (Skin.Purchased == false)
        {
            buttonSelect.interactable = false;
        }
    }
    public void ChekBuyAndSelect() 
    {
        // Повторная проверка уже имея компонент item мы проверяем при нажатии на кнопку
        if (Skin.Selected == true)
        {
            Skin.Purchased = true;
        }

        if (Skin.Purchased == true)
        {
            buttonBuy.interactable = false;
        }
        
        if (Skin.Purchased == false)
        {
            buttonBuy.interactable = true;
        }

        if (Skin.Selected == true)
        {
            buttonSelect.interactable = false;
        }
        
        if (Skin.Selected == false)
        {
            buttonSelect.interactable = true;
        }
        
        if (Skin.Selected == false && Skin.Purchased == false)
        {
            buttonSelect.interactable = true;
        }
        
        if (Skin.Purchased == false )
        {
            buttonSelect.interactable = false;
        }
    }

    // Тут будет производиться проверка на наличия валюты у игрока 
    // И если у него небудет хвать валюты будем предлогать игроку посмотреть и получить эту валюту
    private void ChekingBuy()
    {
        if (wallet.Coin >= Skin.Cost)
        {
            isBuy = true;
        }
        else
        {
            isBuy = false;
        }
    }
    public void _BuySkin()
    {
        isBuy = false;
        ChekingBuy();

        if(isBuy == true)
        {
            ProcessPurchase();// Вызываем процесс покупки
            Debug.Log("Вы купили скин");
        }
        else
        {
            // тут буду отрабатывать недостаток денег и вызывать рекламу по желанию
            FormReword.SetActive(true); // Запускаем панель для просмотра рекламмы
            Debug.Log("Недостаточно денег");
        }
    }

    public void ClouseReward()
    {
        FormReword.SetActive(false); // Закрываем окно с предложением рекламы
    }
    // Для более простой настройки скрипта процесс финальной покупки будем обрабатывать тут
    private void ProcessPurchase()
    {
        wallet.Coin -= Skin.Cost; // Игрок платит за пакупку скина
        Skin.Purchased = true;
        UpdateWalletUI?.Invoke();
        ChekBuyAndSelect();
    }

    //Выбор скина
    public void _SelectSkin()
    {
        Skin.Selected = true;
        idSkin = Skin.ID;
        ChekBuyAndSelect();
        ButtonSelect?.Invoke(idSkin);
    }
}
