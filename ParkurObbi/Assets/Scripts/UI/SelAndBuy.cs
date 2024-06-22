using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SelAndBuy : MonoBehaviour
{
    // ������
    public static event Action<int> ButtonSelect;
    public static event Action UpdateWalletUI; // ��� �� �������� �������� ��� � �� ������ ���-�� ������
    private Item Skin;
    private int idSkin;
    [SerializeField, Header("������ ������")] private Button buttonSelect;
    [SerializeField, Header("������ �������")] private Button buttonBuy;

    [Header("C#: ")]
    [SerializeField] private Wallet wallet;

    [Header("Bool: ")]
    [SerializeField] private bool isBuy;

    [Header("Form: ")]
    [SerializeField] private GameObject FormReword;
    
    public void Start()
    {
        
    }
    public void ChekBuyAndSelect(Item _skin) // ������� ���� ��� ���� �� ������� ������ �������
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
        // ��������� �������� ��� ���� ��������� item �� ��������� ��� ������� �� ������
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

    // ��� ����� ������������� �������� �� ������� ������ � ������ 
    // � ���� � ���� ������� ����� ������ ����� ���������� ������ ���������� � �������� ��� ������
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
            ProcessPurchase();// �������� ������� �������
            Debug.Log("�� ������ ����");
        }
        else
        {
            // ��� ���� ������������ ���������� ����� � �������� ������� �� �������
            FormReword.SetActive(true); // ��������� ������ ��� ��������� ��������
            Debug.Log("������������ �����");
        }
    }

    public void ClouseReward()
    {
        FormReword.SetActive(false); // ��������� ���� � ������������ �������
    }
    // ��� ����� ������� ��������� ������� ������� ��������� ������� ����� ������������ ���
    private void ProcessPurchase()
    {
        wallet.Coin -= Skin.Cost; // ����� ������ �� ������� �����
        Skin.Purchased = true;
        UpdateWalletUI?.Invoke();
        ChekBuyAndSelect();
    }

    //����� �����
    public void _SelectSkin()
    {
        Skin.Selected = true;
        idSkin = Skin.ID;
        ChekBuyAndSelect();
        ButtonSelect?.Invoke(idSkin);
    }
}
