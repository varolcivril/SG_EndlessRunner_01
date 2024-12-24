using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryGizmo : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 5f;
    [SerializeField] private float _objectRadius = 1f;
    [SerializeField] private Transform _followTarget = null;

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _objectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }

    public void OnDrawGizmosSelected()
    {
        if (_followTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _followTarget.position);
        }
    }
}
