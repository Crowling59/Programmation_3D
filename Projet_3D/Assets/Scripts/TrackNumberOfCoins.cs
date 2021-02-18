using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackNumberOfCoins : MonoBehaviour
{
    [SerializeField] private CoinPickupManager coinPickupManager;

    [SerializeField] private TextMeshProUGUI coinsUI;
   
    void Start()
    {
        coinsUI.text = "<color=yellow>0</color>";
    }

    
    void Update()
    {
        coinsUI.text = "<color=yellow>" + coinPickupManager.Coins + "</color>";
    }
}
