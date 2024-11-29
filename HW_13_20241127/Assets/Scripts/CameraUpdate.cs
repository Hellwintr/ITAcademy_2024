using UnityEngine;

public class CameraUpdate: MonoBehaviour
{
    public float updateStep = 1f;
    public void MoveUp()
    {
        transform.position += new Vector3(0, updateStep, 0);
    }

}
