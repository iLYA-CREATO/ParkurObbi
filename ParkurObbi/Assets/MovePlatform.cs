using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private bool moveVertival;
    [SerializeField] private bool moveHorizontal;

    [SerializeField] private GameObject moveObject;

    [SerializeField] private Vector3 goB;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float resetMove; // ¬рем€ через которое помен€етс€ направление движени€


    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (moveHorizontal == true)
        {
            _MoveHorizontal();
        }

        if(moveVertival == true)
        {
            _MoveVertical();
        }

    }
    float timer = 0;
    private void _MoveVertical()
    {
        timer += Time.deltaTime;
        if (timer > resetMove)
        {
            timer = 0;
            goB = -goB;
        }
        transform.position += new Vector3(0f, goB.y * Time.deltaTime * moveSpeed, 0f);
    }
    
    private void _MoveHorizontal()
    {
        
        timer += Time.deltaTime;
        if(timer > resetMove)
        {
            timer = 0;
            goB = -goB;
        }
        transform.position += new Vector3(goB.x * Time.deltaTime * moveSpeed, 0f, goB.z * Time.deltaTime * moveSpeed);

    }
}
