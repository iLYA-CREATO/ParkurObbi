using UnityEngine;

public class TypeControllerPlayer : MonoBehaviour
{
    [Header("Палёт")] public bool flyPlayer;
    [Header("Ппрыжок")] public bool jumpPlayer;
    [Header("Передвижение")] public bool WolkPlayer;

    [SerializeField, Header("Клавиша смены управления")] private KeyCode KeyController;
    public void Update()
    {
        ChangeController();
    }


    // Смена управления будет работать в этом скрипте
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
