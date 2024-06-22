using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenSkinVizable : MonoBehaviour
{
    [SerializeField, Header("ScriptbleObject")] private Item skin;

    [SerializeField, Header("���� ������� ��������")] private Image imageIco;

    [SerializeField, Header("���� ������� ��������")] private SelAndBuy selAndBuy;
    public void ImageReset()
    {
        // ������ ��������
        imageIco.sprite = skin.icon;
    }

    public void ClickME(GameObject s)
    {
        // ��� � ���� ������ ��������� itemSkins ����� �������� ��� � ������ �������� ������ ���� ����
        skin = s.GetComponent<SkinsVisableInventory>().itemSkins;
        ImageReset();
        selAndBuy.ChekBuyAndSelect(skin);
    }
}
