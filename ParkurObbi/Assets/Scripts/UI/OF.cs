using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OF : MonoBehaviour
{
   // OpenForm
   // ������ ��� �������� ������� ���� ��� ������� �� ������

    public void _OpenF(GameObject Form)
    {
        Form.SetActive(true);
    }
    public void _ClouseF(GameObject Form)
    {
        Form.SetActive(false);
    }

    // �� �� ������ ��������� � ��� ��������� �����
    public void _ClouseFLock(GameObject Form)
    {
        Form.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
