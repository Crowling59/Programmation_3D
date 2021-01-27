using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerController : MonoBehaviour
{
    
    [SerializeField] private Transform corpsHolderTransform;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private Transform spawnPoint4;
    [SerializeField] private Transform spawnPoint5;
    [SerializeField] private Transform spawnPoint6;
    [SerializeField] private Transform spawnPoint7;
    [SerializeField] private Transform spawnPoint8;
    [SerializeField] private Transform spawnPoint9;
    [SerializeField] private Transform spawnPoint10;
    private List<Transform> _spawnPointCorps;
    private List<GameObject> ListCorps;
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnPointCorps = new List<Transform>();
        ListCorps = new List<GameObject>();
        
        _spawnPointCorps.Add(spawnPoint1);
        _spawnPointCorps.Add(spawnPoint2);
        _spawnPointCorps.Add(spawnPoint3);
        _spawnPointCorps.Add(spawnPoint4);
        _spawnPointCorps.Add(spawnPoint5);
        _spawnPointCorps.Add(spawnPoint6);
        _spawnPointCorps.Add(spawnPoint7);
        _spawnPointCorps.Add(spawnPoint8);
        _spawnPointCorps.Add(spawnPoint9);
        _spawnPointCorps.Add(spawnPoint10);
        //Debug.Log(_spawnPointCorps);

        foreach (Transform corpsTransform in _spawnPointCorps) {
             GameObject objet = (GameObject) Instantiate(Resources.Load("Corps"),
                corpsTransform.position,
                Quaternion.identity,
                corpsHolderTransform);
             
             ListCorps.Add(objet);
        }
      

    }

}
