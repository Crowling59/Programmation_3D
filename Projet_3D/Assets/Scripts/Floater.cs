using System;
using UnityEngine;

public class Floater : MonoBehaviour
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
        m_Rigidbody = gameManager.BoatController.BoatRigidbody;
    }

    void FixedUpdate()
    {
        m_ForceFactor = 1f - ((transform.position.y - waterLevel) / floatThreshold);

        if (m_ForceFactor > 0f)
        {
            m_FloatForce = -Physics.gravity * (m_ForceFactor - m_Rigidbody.velocity.y * waterDensity);
            m_FloatForce += new Vector3(0f, -downForce, 0f);
            m_Rigidbody.AddForceAtPosition(m_FloatForce,transform.position);
        }
    }
}
