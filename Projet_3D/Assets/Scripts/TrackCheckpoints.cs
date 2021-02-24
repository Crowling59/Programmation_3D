using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour //Permet de garder un oeil sur le checkpoint correct suivant et de déclencher un évenement quand ce n'est pas le bon
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    private int m_NextCheckpointSingleIndex;
    
    public int NextCheckpointSingleIndex
    {
        get => m_NextCheckpointSingleIndex;
    }
    
    private List<CheckPointSingle> m_CheckpointSingleList;

    private void Awake()
    {
        //On récupère les transform des checkpoints
        Transform checkpointsTransform = transform.Find("Checkpoints");

        m_CheckpointSingleList = new List<CheckPointSingle>();
        foreach (Transform checkpointsSingleTransform in checkpointsTransform)
        {
            CheckPointSingle checkpointSingle = checkpointsSingleTransform.GetComponent<CheckPointSingle>();
            
            checkpointSingle.SetTrackCheckpoints(this);
            
            m_CheckpointSingleList.Add(checkpointSingle);
        }
        
        //On commence au premier checkpoint
        m_NextCheckpointSingleIndex = 0;
    }
    
    public void PlayerThroughCheckpoint(CheckPointSingle checkpointSingle) // Fonction qui check si c'est le bon checkpoint quand le joueur passe dedans
    {
        if (m_CheckpointSingleList.IndexOf(checkpointSingle) == m_NextCheckpointSingleIndex)
        {
            //Bon Checkpoint, le bon devient donc le suivant
            m_NextCheckpointSingleIndex = m_NextCheckpointSingleIndex = (m_NextCheckpointSingleIndex + 1) % m_CheckpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this,EventArgs.Empty);
        }
        else
        {
            //Mauvais Checkpoint
            StopAllCoroutines();
            StartCoroutine(ShowRoutine());
        }
    }
    
    private IEnumerator ShowRoutine() // Si c'est un mauvais checkpoint ou un déjà récupéré, on lance l'événement pendant 2 secondes et ensuite on "l'arrête"
    {
        OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(2);
        OnPlayerCorrectCheckpoint?.Invoke(this,EventArgs.Empty);
    }
}
