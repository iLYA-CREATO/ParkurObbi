using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform playerPosition;
    public CharacterController characterControllerPlayer;

    [Header("C#")]
    [SerializeField] private CheckPoints checkPoints;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TrigPlatform")
        {
            Respawn();
            Debug.Log("Ты упал");
        }
    }

    public void Respawn()
    {
        characterControllerPlayer.enabled = false;
        playerPosition.transform.position = checkPoints.SpawnPosition.transform.position;
        characterControllerPlayer.enabled = true;
    }
}
