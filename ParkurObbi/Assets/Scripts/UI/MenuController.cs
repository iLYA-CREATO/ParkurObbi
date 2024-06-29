using UnityEngine;

public class MenuController : MonoBehaviour
{
    public OppenerForm MenuPanelOppenerFormShops;
    public OppenerForm MenuPanelOppenerFormSettings;

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
    }
}
