using UnityEngine;

public static class Utilities
{
    public static bool IsNearTarget(Transform transformA, Transform transformB, float threshold)
    {
        Vector3 offset = transformB.position - transformA.position;

        return offset.sqrMagnitude < threshold * threshold;
    }
}