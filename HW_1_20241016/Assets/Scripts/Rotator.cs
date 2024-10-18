using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(50f, 0f, 0f);   //rotation around X
    //public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f); //rotation around Y
    //public Vector3 rotationSpeed = new Vector3(0f, 0f, 50f); //rotation around Z
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
