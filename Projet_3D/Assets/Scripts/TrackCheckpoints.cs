using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{

    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;
    
    
    private List<CheckPointSingle> checkpointSingleList;
    //public List<CheckPointSingle> CheckpointSingleList => checkpointSingleList;
    
    private int nextCheckpointSingleIndex;
    public int NextCheckpointSingleIndex => nextCheckpointSingleIndex;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckPointSingle>();
        foreach (Transform checkpointsSingleTransform in checkpointsTransform)
        {
            CheckPointSingle checkpointSingle = checkpointsSingleTransform.GetComponent<CheckPointSingle>();
            
            checkpointSingle.SetTrackCheckpoints(this);
            
            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndex = 0;
    }
    
    public void PlayerThroughCheckpoint(CheckPointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //Correct Checkpoint
            Debug.Log("Correct");
            nextCheckpointSingleIndex = nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            Debug.Log("nextCheckpointSingleIndex");
            Debug.Log(nextCheckpointSingleIndex);
            Debug.Log("checkpointSingleList.Count");
            Debug.Log(checkpointSingleList.Count);
            OnPlayerCorrectCheckpoint?.Invoke(this,EventArgs.Empty);
        }
        else
        {
            //Wrong one
            Debug.Log("Wrong");
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
