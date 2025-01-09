using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator playerAnimatorController;

    private NavMeshAgent navMeshAgent;
    private bool isMoving;
    private Vector3 targetPosition;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                targetPosition = hit.point;
                navMeshAgent.SetDestination(targetPosition); // Move player to clicked position
                isMoving = true;
                playerAnimatorController.SetBool("IsWalking", true);
            }
        }

        if(isMoving)
        {
            if(Vector3.Distance(targetPosition,transform.position) <= 0.1f)
            {
                isMoving = false;
                playerAnimatorController.SetBool("IsWalking", false);
            }
        }
        

    }
}
