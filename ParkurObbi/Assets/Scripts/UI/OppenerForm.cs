using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppenerForm : MonoBehaviour
{
    [SerializeField, Header("Название открываемой панели")]private string NameForm;
    public GameObject Form;
    public KeyCode PressKey;
    public bool IsActiv = false;
    public bool AllowOpen = true;

    public void Update()
    {
        if (AllowOpen == true)
        {
            if (IsActiv == false)
                OpenForm();
            else
                ClouseForm();
        }
    }
    public void OpenForm()
    {
        if(Input.GetKeyDown(PressKey))
        {
            Form.SetActive(true);
            IsActiv = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ClouseForm()
    {
        if (Input.GetKeyDown(PressKey))
        {
            Form.SetActive(false);
            IsActiv = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
