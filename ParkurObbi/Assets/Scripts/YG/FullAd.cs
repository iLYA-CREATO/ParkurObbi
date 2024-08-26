using UnityEngine;
public class FullAd : MonoBehaviour
{

    public GameObject panelPause;
    public bool IsRecklam;
    public void StartGame()
    {
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
        IsRecklam = false;
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);
        IsRecklam = true;
    }

    // Продолжить играть после просмотра пеламмы

    public void ActivePanel()
    {
        panelPause.SetActive(true);
    }
    public void StartGameAd()
    {
        panelPause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        IsRecklam = false;
    }
}
