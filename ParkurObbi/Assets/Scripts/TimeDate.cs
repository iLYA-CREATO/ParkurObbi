using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDate : MonoBehaviour
{
    public GameObject ReaclamShow;
    void Awake()
    {
        // �������� ������� UTC ���� � �����
        DateTime currentUTC = DateTime.UtcNow;

        // ������ ������� ����
        DateTime targetDate = new DateTime(2024, 08, 08);

        // ���������, ������ �� ������� ����
        if (currentUTC >= targetDate)
        {
            ReaclamShow.SetActive(true);
        }
        else if (currentUTC < targetDate)
        {
            ReaclamShow.SetActive(false);
        }
    }
}
