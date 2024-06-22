using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using YG;

public class StartSettings : MonoBehaviour
{ 
    public void Start()
    {
        Debug.Log("������ ����: " + YandexGame.lang);
        
        BlockCursor();
    }

    // � ����� ������ ���� ����� ����������� ������ ������
    public void BlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void AnBlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
