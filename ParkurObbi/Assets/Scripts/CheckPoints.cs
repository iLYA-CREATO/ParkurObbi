using Unity.VisualScripting;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform StartPosition;
    public Transform SpawnPosition;
    public void Start()
    {
        if (SpawnPosition == null)
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
        }
    }
}
