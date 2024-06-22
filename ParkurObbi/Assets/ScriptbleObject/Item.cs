using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [Header("ID")] public int ID;
    [Header("Название")] public string Name;
    [Header("Картинка")] public Sprite icon;
    [Header("Стоимость")] public int Cost;

    [Header("Куплен")] public bool Purchased;
    [Header("Выбран")] public bool Selected;
}