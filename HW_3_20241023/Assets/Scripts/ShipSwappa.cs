using System.Xml.Serialization;
using UnityEngine;

public class ShipSwappa : MonoBehaviour
{
    public GameObject[] ships;
    public Material[] materials;
    private int _activeShipIndex = 0;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    void Start()
    {
        _originalPosition = ships[0].transform.position;
        _originalRotation = ships[0].transform.rotation;
        for (int i = 0; i< ships.Length;i++)
        {
            ships[i].SetActive(i==_activeShipIndex);
        }
    }
    public void NextShip()
    {
        ships[_activeShipIndex].SetActive(false);        
        _activeShipIndex = (_activeShipIndex+1)%ships.Length;
        ResetActiveShipPosRot();
        ships[_activeShipIndex].SetActive(true);
    }
    public void PreviousShip()
    {
        ships[_activeShipIndex].SetActive(false);        
        _activeShipIndex = (_activeShipIndex - 1 + ships.Length) % ships.Length;
        ResetActiveShipPosRot();
        ships[_activeShipIndex].SetActive(true);
    }
    public void SelectMaterial(int materialindex)
    {
        MeshRenderer activeShipRenderer = ships[_activeShipIndex].GetComponent<MeshRenderer>();
        activeShipRenderer.material = materials[materialindex];
    }

    void Update()
    {
        TouchHandler();
    }
    private void TouchHandler()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                Transform activeShip = ships[_activeShipIndex].transform;
                float rotationSpeed = 0.2f;
                activeShip.Rotate(Vector3.up,-touch.deltaPosition.x * rotationSpeed,Space.World);
                activeShip.Rotate(Vector3.right,touch.deltaPosition.y * rotationSpeed, Space.World);
            }
        }
    }
    private void ResetActiveShipPosRot()
    {
        Transform activeShip = ships[_activeShipIndex].transform;
        activeShip.position = _originalPosition;
        activeShip.rotation = _originalRotation;
    }
}
