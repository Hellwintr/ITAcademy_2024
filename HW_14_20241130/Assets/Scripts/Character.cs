using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Character : MonoBehaviour
{
    private NavMeshAgent agent;
    private MouseInput mouseInput;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mouseInput = new MouseInput();
        mouseInput.Gameplay.LMBC.started+=LMBCOnstarted;
        mouseInput.Enable();
    }
    void LMBCOnstarted(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
