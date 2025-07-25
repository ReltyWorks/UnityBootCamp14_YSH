using UnityEngine;

public enum Test1 {
    Perspective,
    Orthographic,
}

public enum Test2 {
    Vertical,
    Horizontal,
}

public class FekeCamera : MonoBehaviour
{
    public Test1 Projection;
    public Test2 FieldOfViewAxis;
    public float FieldOfView = 0;
    public float ClippingPlanesNear = 0;
    public float ClippingPlanesFar = 0;
    public bool PhysicalCamera = false;
}
