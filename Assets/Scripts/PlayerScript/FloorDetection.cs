using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    #region Expose
    [SerializeField] private Transform[] _rayOrigins;
    [SerializeField] private float _rayLenght;
    [SerializeField] private LayerMask _groundMask;
    #endregion

    #region Unity Life Cycle
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        foreach (Transform origin in _rayOrigins)
        {
            Gizmos.DrawRay(origin.position, Vector3.down * _rayLenght);
        }
    }
    #endregion

    #region methods
    public Vector3 AverageHeight()
    {
        int hitCount = 0;
        Vector3 combinedPosition = Vector3.zero;
        RaycastHit hit;
        foreach (Transform origin in _rayOrigins)
        {
            if (Physics.Raycast(origin.position, Vector3.down, out hit, _rayLenght, _groundMask))
            {
                hitCount++;
                //hit.point : La position dans le world où le Raycast a touché le collider
                combinedPosition += hit.point;
            }
        }
        Vector3 averagePosition = Vector3.zero;
        if (hitCount > 0)
        {
            averagePosition = combinedPosition / hitCount;
        }
        return averagePosition;
    }
    #endregion
}
