using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
   [SerializeField] private int coin;

    public int Coin
    { 
        get 
        { 
            return coin; 
        }
        set 
        { 
            if(coin  >= 0)
                coin = value; 
        }
    }
}
