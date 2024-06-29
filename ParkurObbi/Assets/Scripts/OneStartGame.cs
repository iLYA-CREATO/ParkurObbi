using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStartGame : MonoBehaviour
{
    public int oneStart;
    [SerializeField] private GameObject panelInfo;
    private void Start()
    {
        OutSave();
        if (oneStart == 0)
        {
            panelInfo.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        panelInfo.SetActive(false);
        oneStart = 1;
        Save();
    }

    private void OutSave()
    {
        if (PlayerPrefs.HasKey("StartGame"))
        {
            oneStart = PlayerPrefs.GetInt("StartGame");
        }
        else
        {
            oneStart = 0;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("StartGame", oneStart);
    }
}
