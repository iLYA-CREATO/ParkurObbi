using UnityEngine;

public class MenuController : MonoBehaviour
{
    public OppenerForm MenuPanelOppenerFormShops;
    public OppenerForm MenuPanelOppenerFormSettings;


    [Header("C#")]
    [SerializeField] private MovePlayer _movePlayer;


    public void Update()
    {
        if(MenuPanelOppenerFormShops.IsActiv == true)
        {
            MenuPanelOppenerFormSettings.AllowOpen = false;
        }
        else
        {
            MenuPanelOppenerFormSettings.AllowOpen = true;
        }

        if (MenuPanelOppenerFormSettings.IsActiv == true)
        {
            MenuPanelOppenerFormShops.AllowOpen = false;
        }
        else
        {
            MenuPanelOppenerFormShops.AllowOpen = true;
        }

        BlockPlayeMove();
    }

    // Блокируем управление игрока когда включена любая панель
    public void BlockPlayeMove()
    {
        if (MenuPanelOppenerFormShops.IsActiv == true || MenuPanelOppenerFormSettings.IsActiv == true)
        {
            _movePlayer.enabled = false;
        }
        else
        {
            _movePlayer.enabled = true;

        }
    }
}
