using System;
using UnityEngine;

public class PlusCoin : MonoBehaviour
{
    public Wallet wallet;
    public static event Action UpdateWalletUIPlusCoin; // ��� �� �������� �������� ��� � �� ������ ���-�� ������
    public void GetCoin()
    {
        wallet.Coin += 100;
        Debug.Log("�� ��������� ��� �����");
        UpdateWalletUIPlusCoin?.Invoke();
    }
}
