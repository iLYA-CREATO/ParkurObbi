using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private Transform StartPosition;
    public Transform SpawnPosition;
    public List<Transform> allSpawn;

    [SerializeField] private int idSpwn;
    [SerializeField] private int fianalId;
    public RespawnPlayer RespawnPlayer;

    [SerializeField] private GameObject PanelWin;

    [SerializeField] private AudioClip checkPointSound;

    [SerializeField] private PlaySound playSound;


    private void Start()
    {
        if (PlayerPrefs.HasKey("SpawnPosition"))
        {
            idSpwn = PlayerPrefs.GetInt("SpawnPosition");
            SpawnPosition = allSpawn[idSpwn];
            RespawnPlayer.Respawn();
        }
        else
        {
            SpawnPosition = StartPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CP")
        {
            SpawnPosition = other.GetComponent<Transform>();
            Debug.Log("Ты коснулся чекпоинта");
            
            for (int i = 0; i < allSpawn.Count; i++)
            {
                if (allSpawn[i].name == SpawnPosition.name)
                {
                    idSpwn = i;
                    PlayerPrefs.SetInt("SpawnPosition", idSpwn);
                    playSound._PlaySound(checkPointSound);
                }

                if(idSpwn == fianalId)
                {
                    idSpwn = 0;
                    PanelWin.SetActive(true);
                    Time.timeScale = 0f;
                    Cursor.lockState = CursorLockMode.None;
                    PlayerPrefs.SetInt("SpawnPosition", idSpwn);
                }
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        PanelWin.SetActive(false);
        SpawnPosition = StartPosition;
        Cursor.lockState = CursorLockMode.Locked;
        RespawnPlayer.Respawn();
    }
}
