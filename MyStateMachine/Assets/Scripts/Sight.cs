using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float SightRadius;
    public bool targetInSight = false;

    public float distance;
    private Vector3[] edges;
    public List<Vector3> rayDirPoints;
    public int height;
    public int width;
    void Update()
    {
        GetRayDirPoints();
        targetInSight = isTargetnSight();
    }
    private void GetRayDirPoints()
    {
        rayDirPoints = new List<Vector3>();

        Vector3 Point = transform.position + transform.forward * distance;
        for (int x = -width; x <= width; x++)
        {
            for (int y = -height; y <= height; y++)
            {
                //Vector3 newPOint = transform.position;
                rayDirPoints.Add(new Vector3(x, y, 0));
            }
        }
        for (int i = 0; i < rayDirPoints.Count; i++)
        {
            Matrix4x4 rot = Matrix4x4.Rotate(transform.rotation);
            rayDirPoints[i] = rot * rayDirPoints[i];
            rayDirPoints[i] += Point;
        }
    }
    public bool isTargetnSight()
    {
        for(int i = 0; i< rayDirPoints.Count; i++)
        {
            RaycastHit hit;
            Vector3 direction = rayDirPoints[i] - transform.position;
            float distance = direction.magnitude;
            Physics.Raycast(transform.position, direction.normalized, out hit, distance);
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<Target>())
                    return true;
            }
        }
        return false;
        
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        for( int i = 0; i < rayDirPoints.Count; i++)
        {
            Gizmos.DrawSphere(rayDirPoints[i], 0.1f);
        }
    }
}
