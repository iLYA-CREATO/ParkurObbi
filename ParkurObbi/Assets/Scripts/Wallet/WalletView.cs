using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField, Header("Где инфа")] private Wallet wallet;
    public SaveWallet WalletSave;

    [SerializeField, Header("Текст вывода")] private TextMeshProUGUI TextMoney;
    // Подписываемся на событие

    public void Start()
    {
        UpdateWalletTextUI();
    }
    public void OnEnable()
    {
        SelAndBuy.UpdateWalletUI += UpdateWalletTextUI;
        PlusCoin.UpdateWalletUIPlusCoin += UpdateWalletTextUI;
        SaveWallet.UpdateWalletUIStartGameSave += UpdateWalletTextUI;
        Reward.UpdateWalletUIRecklamCoin += UpdateWalletTextUI;
    }

    // Отписываемся от событие
    public void OnDisable()
    {
        SelAndBuy.UpdateWalletUI -= UpdateWalletTextUI;
        PlusCoin.UpdateWalletUIPlusCoin -= UpdateWalletTextUI;
        SaveWallet.UpdateWalletUIStartGameSave -= UpdateWalletTextUI;
        Reward.UpdateWalletUIRecklamCoin -= UpdateWalletTextUI;

    }

    // обновление текста кошелька
    public void UpdateWalletTextUI()
    {
        TextMoney.text = wallet.Coin.ToString();
        WalletSave._SaveWallet(); // Сохраняем тут любое изменение валюты
    }
}
