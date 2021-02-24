using UnityEngine;

public class CheckPointSingle : MonoBehaviour // Permet d'actualiser le dernier checkpoint du joueur
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
