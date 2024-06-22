using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField, Header("��� ����")] private Wallet wallet;
    public SaveWallet WalletSave;

    [SerializeField, Header("����� ������")] private TextMeshProUGUI TextMoney;
    // ������������� �� �������

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

    // ������������ �� �������
    public void OnDisable()
    {
        SelAndBuy.UpdateWalletUI -= UpdateWalletTextUI;
        PlusCoin.UpdateWalletUIPlusCoin -= UpdateWalletTextUI;
        SaveWallet.UpdateWalletUIStartGameSave -= UpdateWalletTextUI;
        Reward.UpdateWalletUIRecklamCoin -= UpdateWalletTextUI;

    }

    // ���������� ������ ��������
    public void UpdateWalletTextUI()
    {
        TextMoney.text = wallet.Coin.ToString();
        WalletSave._SaveWallet(); // ��������� ��� ����� ��������� ������
    }
}
