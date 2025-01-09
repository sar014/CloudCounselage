using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour, IPointSelector
{
    [SerializeField] List<GameObject> pointList = new List<GameObject>();

    public Vector3 SelectPoint(List<GameObject> points)
    {
        if (points.Count == 0)
        {
            Debug.Log("Point List is Empty");
            return Vector3.zero;
        }

        int RandomIndex = UnityEngine.Random.Range(0, points.Count);
        return points[RandomIndex].transform.position;
    }

    public Vector3 GetRandomPoints()
    {
        return SelectPoint(pointList);
    }

    public Transform GetTargetTransform(Vector3 targetPosition)
    {
        // Find the GameObject with the corresponding position and return its Transform
        foreach (GameObject point in pointList)
        {
            if (point.transform.position == targetPosition)
            {
                return point.transform;
            }
        }

        return null;
    }


}
