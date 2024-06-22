using UnityEngine;

public class TypeControllerPlayer : MonoBehaviour
{
    [Header("����")] public bool flyPlayer;
    [Header("�������")] public bool jumpPlayer;
    [Header("������������")] public bool WolkPlayer;

    [SerializeField, Header("������� ����� ����������")] private KeyCode KeyController;
    public void Update()
    {
        ChangeController();
    }


    // ����� ���������� ����� �������� � ���� �������
    public void ChangeController()
    {
        if (Input.GetKeyDown(KeyController))
        {
            flyPlayer = !flyPlayer;
            jumpPlayer = !jumpPlayer;
            WolkPlayer = !WolkPlayer;
        }
    }
}
