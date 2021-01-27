using UnityEngine;


public class CorpsDestroyController : MonoBehaviour {
    private static LayerMask _layerBall;

    private void Awake() {
        _layerBall = LayerMask.NameToLayer("Balle");
        Debug.Log("layer ok");
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("rentre dans l'event");
        Debug.Log("other:");
        Debug.Log(other.gameObject.layer);
        Debug.Log("_layerBall:");
        Debug.Log(_layerBall);
        if (other.gameObject.layer == _layerBall)
        {
            Debug.Log("Destroyed: ");
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
            
    }
}

