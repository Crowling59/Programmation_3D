using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out Rigidbody player))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
