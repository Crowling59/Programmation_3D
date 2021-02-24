using UnityEngine;

public class TrackCheckPointsUI : MonoBehaviour //Permet de gérer les évenements des checkpoints
{
    [SerializeField] private GameManager gameManager;
    
    private void Start()
    {
        //On ajoute aux évenements les actions correspondantes
        gameManager.TrackCheckPoints.OnPlayerCorrectCheckpoint += TrackCheckpoints_OnPlayerCorrectCheckpoint;
        gameManager.TrackCheckPoints.OnPlayerWrongCheckpoint += TrackCheckpoints_OnPlayerWrongCheckpoint;

        Hide();
    }

    private void TrackCheckpoints_OnPlayerWrongCheckpoint(object sender, System.EventArgs e) // On affiche le message de warning
    {
        Show();
    }
    
    private void TrackCheckpoints_OnPlayerCorrectCheckpoint(object sender, System.EventArgs e) // On cache le message de warning
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
