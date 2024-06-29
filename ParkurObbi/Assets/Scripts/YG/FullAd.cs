using UnityEngine;
public class FullAd : MonoBehaviour
{

    [SerializeField] private GameObject panelPause;
    public void StartGame()
    {
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);

        
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);
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
    }
}
