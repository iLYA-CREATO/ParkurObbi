using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [Header("ID")] public int ID;
    [Header("��������")] public string Name;
    [Header("��������")] public Sprite icon;
    [Header("���������")] public int Cost;

    [Header("������")] public bool Purchased;
    [Header("������")] public bool Selected;
}