using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClearSave : MonoBehaviour
{
//#if UNITY_EDITOR
    [SerializeField] private GameObject ButtonClearSave;
    public void ResetSave()
    {
        // Удаляем все сохранения
        ButtonClearSave.SetActive(true);
        PlayerPrefs.DeleteAll();
    }
}
//#endif
