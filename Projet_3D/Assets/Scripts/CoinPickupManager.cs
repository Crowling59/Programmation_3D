using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupManager : MonoBehaviour
{
    public int Coins = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Coin")
        {
            Coins++;
            Destroy(other.gameObject);
        }
    }
}
