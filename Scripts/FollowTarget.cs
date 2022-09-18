using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] float m_retargetingSpeed=2f;
    RollingMovement m_rollingMovement;

    void Start()
    {
        //Gather Components through Inheritance
        m_rollingMovement = GetComponent<RollingMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Point target direction to the target
        Vector3 m_targetDirection=m_target.position-transform.position;
        float m_retargetSpeed=Vector3.SqrMagnitude(m_targetDirection)<0.1f?1000f:m_retargetingSpeed;

        m_rollingMovement.m_movementDirection=Vector3.Lerp(m_rollingMovement.m_movementDirection,m_targetDirection.normalized,Time.fixedDeltaTime*m_retargetSpeed);
    }
}
