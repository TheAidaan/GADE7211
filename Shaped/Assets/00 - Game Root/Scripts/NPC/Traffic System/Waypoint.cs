using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWapoint;
    public Waypoint nextWaypoint;

    [Range(0f,5f)]
    public float width = 1f;

    public Vector3 GetPosition() // reutns random point based on waypoint width with some degree of freedom for characters when moving towards waypoint
    {
        Vector3 minBound = transform.position + transform.position + transform.right * width / 2f;
        Vector3 maxBound = transform.position - transform.right * width / 2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0, 1f));
    }

}
