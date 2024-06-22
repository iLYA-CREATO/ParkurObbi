using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using YG;

public class StartSettings : MonoBehaviour
{ 
    public void Start()
    {
        Debug.Log("Сейчас язык: " + YandexGame.lang);
        
        BlockCursor();
    }

    // В самом старте игры будем блокировать курсор игрока
    public void BlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void AnBlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
