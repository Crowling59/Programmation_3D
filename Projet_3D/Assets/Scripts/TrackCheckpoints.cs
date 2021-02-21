using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    private int m_NextCheckpointSingleIndex;
    
    public int NextCheckpointSingleIndex
    {
        get => m_NextCheckpointSingleIndex;
        set => m_NextCheckpointSingleIndex = value;
    }
    
    private List<CheckPointSingle> m_CheckpointSingleList;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        m_CheckpointSingleList = new List<CheckPointSingle>();
        foreach (Transform checkpointsSingleTransform in checkpointsTransform)
        {
            CheckPointSingle checkpointSingle = checkpointsSingleTransform.GetComponent<CheckPointSingle>();
            
            checkpointSingle.SetTrackCheckpoints(this);
            
            m_CheckpointSingleList.Add(checkpointSingle);
        }

        m_NextCheckpointSingleIndex = 0;
    }
    
    public void PlayerThroughCheckpoint(CheckPointSingle checkpointSingle)
    {
        if (m_CheckpointSingleList.IndexOf(checkpointSingle) == m_NextCheckpointSingleIndex)
        {
            //Correct Checkpoint
            m_NextCheckpointSingleIndex = m_NextCheckpointSingleIndex = (m_NextCheckpointSingleIndex + 1) % m_CheckpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this,EventArgs.Empty);
        }
        else
        {
            //Wrong one
            StopAllCoroutines();
            StartCoroutine(ShowRoutine());
        }
    }
    
    private IEnumerator ShowRoutine()
    {
        OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(2);
        OnPlayerCorrectCheckpoint?.Invoke(this,EventArgs.Empty);
    }
}
