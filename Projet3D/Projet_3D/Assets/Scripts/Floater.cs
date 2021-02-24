using System;
using UnityEngine;

public class Floater : MonoBehaviour // Permet de faire tenir le bateau au dessus de l'eau et normalement le faire flotter
{
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private float waterLevel = 0f;

    [SerializeField] private float floatThreshold = 2f;

    [SerializeField] private float waterDensity = 0.125f;

    [SerializeField] private float downForce = 4.0f;

    private float m_ForceFactor;
    
    private Vector3 m_FloatForce;

    private Rigidbody m_Rigidbody;
    
    
    private void Awake() 
    {
        //On récupère le rigidbody du bateau
        m_Rigidbody = gameManager.BoatController.BoatRigidbody;
    }

    void FixedUpdate()
    {
        //Si le bateau commence à couler, on lui ajoute une force dans l'autre sens pour le faire flotter
        m_ForceFactor = 1f - ((transform.position.y - waterLevel) / floatThreshold);

        if (m_ForceFactor > 0f)
        {
            m_FloatForce = -Physics.gravity * (m_ForceFactor - m_Rigidbody.velocity.y * waterDensity);
            m_FloatForce += new Vector3(0f, -downForce, 0f);
            m_Rigidbody.AddForceAtPosition(m_FloatForce,transform.position);
        }
    }
}
