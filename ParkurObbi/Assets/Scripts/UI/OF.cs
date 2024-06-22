using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OF : MonoBehaviour
{
   // OpenForm
   // Скрипт для открытия простых окон при нажатия на кнопку

    public void _OpenF(GameObject Form)
    {
        Form.SetActive(true);
    }
    public void _ClouseF(GameObject Form)
    {
        Form.SetActive(false);
    }

    // он не просто закрывает а ещё блокирует мышку
    public void _ClouseFLock(GameObject Form)
    {
        Form.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
