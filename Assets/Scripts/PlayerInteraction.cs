using UnityEditor;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRange = 2.0f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject toolTip;
    [SerializeField] private Animator playerAnimator;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleHover();
        HandleInteraction();
    }

    private void HandleHover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            interactable?.ShowTooltip();
        }
        else
        {
            // Hide tooltip if no object is being hovered
            if(toolTip.activeInHierarchy)
            {
                toolTip.SetActive(false);
            }
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, interactableLayer))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if(Vector3.Distance(hit.collider.transform.position, transform.position) <= 1f)
                {
                    interactable?.OnInteract();
                    playerAnimator.SetBool("IsWalking", false);
                    playerAnimator.SetTrigger("IsInteracting");
                }
            }
        }
    }
}
