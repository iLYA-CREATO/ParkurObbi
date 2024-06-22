using UnityEngine;
public class FullAd : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }

}
