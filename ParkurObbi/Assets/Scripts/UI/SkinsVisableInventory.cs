using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SkinsVisableInventory : MonoBehaviour
{
    [Header("ScriptbleObject")] public Item itemSkins;

    [SerializeField, Header("Картинка в инвенторе")] private Image image;
    [SerializeField, Header("Текст стоимости")] private TextMeshProUGUI textMoney;
    [SerializeField, Header("Текст названия")] private TextMeshProUGUI textName;
    string lang;

    public void Start()
    {
        lang = YandexGame.lang;
        image.sprite = itemSkins.icon;
        MoneyText();
    }
    private void OnEnable()
    {
        SelectSkin.UpdateShopSkin += MoneyText;
        MoneyText();
    }
    public void OnDisable()
    {
        SelectSkin.UpdateShopSkin -= MoneyText;
    }

    private void MoneyText()
    {
        if (itemSkins.Purchased == true && itemSkins.Selected == false)
        {
            //Цена не будет показываться если куплен
            switch (lang)
            {
                case "ru": // Русский
                    textMoney.text = "Куплен";
                    break;
                case "en": // Английский
                    textMoney.text = "Purchased";
                    break;
                case "tr": // Туреций
                    textMoney.text = "Satın alındı";
                    break;
                /*case "be":// Белоруский
                    textMoney.text = "Набыты";
                    break;
                case "de": // Немецкий
                    textMoney.text = "Gekauft";
                    break;
                case "uk": // Украинский
                    textMoney.text = "Куплений";
                    break;
                case "bg": // Болгарский
                    textMoney.text = "Закупени";
                    break;
                case "pl": // Польский
                    textMoney.text = "Zakupione";
                    break;
                case "fr": // Француский
                    textMoney.text = "Acheté";
                    break;
                case "pt": // Португальский
                    textMoney.text = "Comprado";
                    break;
                case "et": // Эстонский 
                    textMoney.text = "Ostetud";
                    break;*/

            }
        }
        else if (itemSkins.Purchased == false && itemSkins.Selected == false)
        {
            // Будет показываться цена если скин не куплен
            textMoney.text = itemSkins.Cost.ToString();
        }
        else if (itemSkins.Purchased == true && itemSkins.Selected == true)
        {
            //Выбран
            switch (lang)
            {
                case "ru": // Русский
                    textMoney.text = "Выбран";
                    break;
                case "en": // Английский
                    textMoney.text = "Selected";
                    break;
                case "tr": // Туреций
                    textMoney.text = "Seçildi";
                    break;
                /*case "be":// Белоруский
                    textMoney.text = "Абраны";
                    break;
                case "de": // Немецкий
                    textMoney.text = "Ausgewählt";
                    break;
                case "uk": // Украинский
                    textMoney.text = "Вибраний";
                    break;
                case "bg": // Болгарский
                    textMoney.text = "Избрано";
                    break;
                case "pl": // Польский
                    textMoney.text = "Wybrany";
                    break;
                case "fr": // Француский
                    textMoney.text = "Choisi";
                    break;
                case "pt": // Португальский
                    textMoney.text = "Selecionado";
                    break;
                case "et": // Эстонский 
                    textMoney.text = "Valitud";
                    break;*/

            }
        }
    }
}

/*switch (YandexGame.lang)
{
    case "ru": // Русский
        textMoney.text = "Куплен";
        break;
    case "en": // Английский
        textMoney.text = "";
        break;
    case "tr": // Туреций
        textMoney.text = "";
        break;
    case "be":// Белоруский
        textMoney.text = "";
        break;
    case "de": // Немецкий
        textMoney.text = "";
        break;
    case "uk": // Украинский
        textMoney.text = "";
        break;
    case "bg": // Болгарский
        textMoney.text = "";
        break;
    case "pl": // Польский
        textMoney.text = "";
        break;
    case "fr": // Француский
        textMoney.text = "";
        break;
    case "pt": // Португальский
        textMoney.text = "";
        break;
    case "et": // Эстонский 
        textMoney.text = "";
        break;

}*/