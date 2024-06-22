using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    [SerializeField, Header("Части игрока: ")] private List<GameObject> playerParts;
    [SerializeField, Header("C#: ")] private SkinPlayer skinPlayer;

    public static event Action UpdateShopSkin;// Обновим картинку

    private int _idSkin;// Общая переменная для скрипта
    public void OnEnable()
    {
        SelAndBuy.ButtonSelect += _SelectSkin;
    }
    public void OnDisable()
    {
        SelAndBuy.ButtonSelect -= _SelectSkin;
    }

    public void Start()
    {
        UploadSaveSkin();
        _SelectSkin(_idSkin);
        UpdateShopSkin?.Invoke();
    }
    public void _SelectSkin(int idSkin)
    {
        SaveSkin(idSkin); // Сразу передаём выбранный скин на сохранение

        // Тут реализуем  проверку на выбранный скин
        for (int i = 0; i < skinPlayer._itemSkinPlayer.Count; i++)
        {   
            if (skinPlayer._itemSkinPlayer[i].ID == skinPlayer._itemSkinPlayer[idSkin].ID)
            {
                skinPlayer._itemSkinPlayer[idSkin].Selected = true;
                _RenderMaterial(idSkin);
            }
            else
            {
                skinPlayer._itemSkinPlayer[i].Selected = false;
            }
        }
        UpdateShopSkin?.Invoke();
    }

    public void _RenderMaterial(int idSkin)
    {
        for(int i = 0;i < playerParts.Count;i++)
        {
            playerParts[i].GetComponent<Renderer>().material = skinPlayer._skinMaterialPlayer[idSkin];
        }
    }

    // Тут же и реализуем сохранение выбранного скина 

    private void SaveSkin(int idSkin)
    {
        PlayerPrefs.SetInt("idSkin", idSkin);
    }

    private void UploadSaveSkin()
    {
        if (PlayerPrefs.HasKey("idSkin"))
        {
            _idSkin = PlayerPrefs.GetInt("idSkin");
        }
        else
        {
            _idSkin = 0; // Ставим стандартный скин 
        }
    }
}
