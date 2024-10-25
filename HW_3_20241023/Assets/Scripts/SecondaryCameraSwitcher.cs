using UnityEngine;

public class SecondaryCameraSwitcher: MonoBehaviour
{
    public Transform targetPoint; 
    public Vector3 viewTop = new Vector3(0, 20, 0);
    public Vector3 viewBottom = new Vector3(0, -20, 0);
    public Vector3 viewFront = new Vector3(0, 0, -20);
    public Vector3 viewLeft = new Vector3(-20, 0, 0);

    private void MoveCamera(Vector3 offset)
    {
        if (targetPoint != null)
        {
            transform.position = targetPoint.position + offset;
            transform.LookAt(targetPoint);
        }
    }
    public void SetTopView()
    {
        MoveCamera(viewTop);
    }

    public void SetBottomView()
    {
        MoveCamera(viewBottom);
    }

    public void SetFrontView()
    {
        MoveCamera(viewFront);
    }

    public void SetLeftView()
    {
        MoveCamera(viewLeft);
    }
    
}
