using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void SetToolTip()
    {
        Vector3 mousePosition = Input.mousePosition;
        transform.position = mousePosition + offset;
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        transform.position = mousePosition + offset;
    }
}

