using System.Collections;
using UnityEngine;


public class CorpsController : MonoBehaviour
{
    private Rigidbody _corpsRigidbody;
    [SerializeField] private float speed = 0.0001f;
    
    private void Awake() {
        _corpsRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(DoMovements());
    }
    
    private IEnumerator DoMovements() {
        while (true) {
            float timeToDoMovement = Random.Range(2f, 6f);
            float timer = 0f;
            Vector3 deltaPosition = new Vector3(Random.Range(-1f, 1f),
                Random.Range(-0.15f, 0.15f),
                Random.Range(-1f, 1f)) * speed;

            while (timer < timeToDoMovement) {
                timer += Time.deltaTime;
                _corpsRigidbody.position += deltaPosition;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
