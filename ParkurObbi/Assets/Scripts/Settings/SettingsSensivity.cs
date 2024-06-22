using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSensivity : MonoBehaviour
{
    [SerializeField, Header("")] private float StandartSensivityXdesktop;
    [SerializeField, Header("")] private float StandartSensivityYdesktop;
    [Header("����� ��� ��")]
    [Space]
    public float sensivityXdesktop;
    public float sensivityYdesktop;
    [Space]

    [SerializeField, Header("������� ����� X")]private Slider sensivitySliderX;
    [SerializeField, Header("������� ����� Y")]private Slider sensivitySliderY;

    [SerializeField, Header("������ ������")]private CinemachineFreeLook cameraPlayer;
    public void Start()
    {
        UploadSaveSensivity();
    }
    public void SaveSensivity()
    {
        sensivityXdesktop = sensivitySliderX.value;
        sensivityYdesktop = sensivitySliderY.value;
        PlayerPrefs.SetFloat("sensivityXdesktop", sensivityXdesktop);
        PlayerPrefs.SetFloat("sensivityYdesktop", sensivityYdesktop);
        SliderOut(sensivityXdesktop, sensivityYdesktop);
    }

    private void UploadSaveSensivity()
    {
            // ��� ���������� ��� ��
            if (PlayerPrefs.HasKey("sensivityXdesktop"))
            {
                sensivityXdesktop = PlayerPrefs.GetFloat("sensivityXdesktop");
            }
            else
            {
                sensivityXdesktop = StandartSensivityXdesktop;
                sensivityYdesktop = StandartSensivityYdesktop;
            }

            if (PlayerPrefs.HasKey("sensivityYdesktop"))
            {
                sensivityYdesktop = PlayerPrefs.GetFloat("sensivityYdesktop");
            }
            else
            {
                sensivityYdesktop = StandartSensivityYdesktop; // ������ ����������� �����
            }
            SliderOut(sensivityXdesktop, sensivityYdesktop);
            //Debug.LogError("���������� ����� ��� ��");

    }

    // ����� �������� ������ �������� �� ������ ���� ��������
    private void SliderOut(float x, float y)
    {
        sensivitySliderX.value = x;
        sensivitySliderY.value = y;

        cameraPlayer.m_YAxis.m_MaxSpeed = x;
        cameraPlayer.m_XAxis.m_MaxSpeed = y;
    }
}
