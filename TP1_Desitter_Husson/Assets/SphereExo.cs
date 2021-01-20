using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereExo : MonoBehaviour
{
    //Les [SerializeField] peuvent être modifiés directement depuis unity pendant le fonctionnement de la scene
    [SerializeField] private GameObject sphereObjet1 = default;
    [SerializeField] private GameObject sphereObjet2 = default;
    [SerializeField] private Vector3 centre = default;
    [SerializeField] private float rayon = 5f;
    [SerializeField] private int nbPoints = 6;
    [SerializeField] private float angleRotationX = 90f;
    [SerializeField] private float angleRotationY = 90f;
    [SerializeField] private float angleRotationZ = 90f;
    
    
    //DOCUMENTATION ON TRANSFORM OBJECT (Transform _formeCercle, foreach(Transform sousObjet in _formeCercle))
    //---->https://docs.unity3d.com/ScriptReference/Transform.html
    private Transform _formeCercle;
    
    
    
    
    
    //DOCUMENTATION ON AWAKE FCT
    //---->https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    void Awake()
    {
        //DOCUMENTATION ON TRANSFORM COMPONENT
        //---->https://docs.unity3d.com/ScriptReference/Component-transform.html
        _formeCercle = transform;
    }
    void Start()
    {
        StartCoroutine(Initialisation());
        //DOCUMENTATION FOR COROUTINE SETUP (IEnumerator type, StartCoroutine, yield return new WaitForSeconds(arg))
        //----> https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
    }

    private IEnumerator Initialisation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            List<Vector3> data = CalculCoordonnees();

            foreach (Transform sousObjet in _formeCercle)
            {
                Destroy(sousObjet.gameObject);
            }

            foreach (Vector3 fablab in data)
            {

                int i = Random.Range(0, 2);
                
                Debug.Log(angleRotationX);
                Debug.Log(angleRotationY);
                Debug.Log(angleRotationZ);

                if (i == 0)
                {
                    Instantiate(sphereObjet1, fablab, Quaternion.Euler( angleRotationX, angleRotationY,
                        angleRotationZ), _formeCercle);
                }
                else
                {
                    Instantiate(sphereObjet2, fablab, Quaternion.Euler( angleRotationX, angleRotationY,
                        angleRotationZ), _formeCercle);
                }

            }
                
        }
    }

    private List<Vector3> CalculCoordonnees() {

        List<float> coordonnesX = new List<float> ();
        List<float> coordonnesY = new List<float> ();
        List<List<float>> coordonnes = new List<List<float>> ();
        
        float angle = 2*Mathf.PI / nbPoints;
        for (int i = 0; i < nbPoints; i++)
        {
            float x = rayon * Mathf.Cos(angle*i);
            float y = rayon * Mathf.Sin(angle*i);
            coordonnesX.Add(x);
            coordonnesY.Add(y);
            //Debug.Log(coordonnesX[i]);
            //Debug.Log(coordonnesY[i]);
        }
        coordonnes.Add(coordonnesX);
        coordonnes.Add(coordonnesY);
        
        List<Vector3> coordSphere = new List<Vector3>();
            
        for (int i = 0; i < coordonnesX.Count; i++) {
            coordSphere.Add(new Vector3(
                centre.x + coordonnes[0][i],
                centre.y + coordonnes[1][i],
                centre.z));
            //Debug.Log(coordSphere[i]);
        }
        
        return coordSphere;
        
    }
}
