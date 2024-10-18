using UnityEngine;

public class Scaler : MonoBehaviour
{
    public Vector3 maxScale = new Vector3(3f, 3f, 3f);
    public float scalingSpeed = 1f;
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime * scalingSpeed);
    }
}
