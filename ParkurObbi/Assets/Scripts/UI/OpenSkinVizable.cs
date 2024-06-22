using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenSkinVizable : MonoBehaviour
{
    [SerializeField, Header("ScriptbleObject")] private Item skin;

    [SerializeField, Header("Куда выводим картинку")] private Image imageIco;

    [SerializeField, Header("Куда выводим картинку")] private SelAndBuy selAndBuy;
    public void ImageReset()
    {
        // Рисуем картинку
        imageIco.sprite = skin.icon;
    }

    public void ClickME(GameObject s)
    {
        // Тут я буду искать компонент itemSkins чтобы записать его и дальше показать игроку этот скин
        skin = s.GetComponent<SkinsVisableInventory>().itemSkins;
        ImageReset();
        selAndBuy.ChekBuyAndSelect(skin);
    }
}
