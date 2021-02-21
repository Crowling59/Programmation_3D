using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{

    [SerializeField] private TrackCheckpoints trackCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trackCheckpoint.PlayerThroughCheckpoint(this);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        trackCheckpoint = trackCheckpoints;
    }
}
