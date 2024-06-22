using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reward : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    public static event Action UpdateWalletUIRecklamCoin; // ��� �� �������� �������� ��� � ���� ��������� ���������� ������
    public GameObject PanelRecklam;


    // ����������� ����� ��������� �������
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
