using UnityEngine;

public class RollingMovement : MonoBehaviour
{
    [SerializeField] float m_speed=1f;
    Rigidbody m_rigidbody;
    [HideInInspector] public Vector3 m_movementDirection;
    Vector3 m_startPosition;

    void Start()
    {
        // Gather Components and variables that will added later
        m_rigidbody=GetComponent<Rigidbody>();
        m_startPosition=transform.position;

    }
    void FixedUpdate()
    {
        //Every Physics upadarte out of force to the mov vector*speed
        m_rigidbody.AddForce(m_movementDirection*m_speed);
        if(transform.position.y<=GameManager.RespawnHeight)
        {
            ResetPosition();
        } 
    }
    public void ResetPosition()
    {
        //vel=0 and position to 0
        
        m_rigidbody.velocity=Vector3.zero;
        m_rigidbody.angularVelocity=Vector3.zero;
        transform.position=m_startPosition;
    }
}
