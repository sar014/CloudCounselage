using System.Collections.Generic;
using UnityEngine;

public interface IPointSelector
{
    Vector3 SelectPoint(List<GameObject> points);
}