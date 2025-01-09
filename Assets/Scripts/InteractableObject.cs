using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator objectAnimator;
    [SerializeField] private string objectInteractTriggerName;


    [Header("Tooltip Settings")]
    [SerializeField] private string tooltipText = "Interact";
    [SerializeField]private GameObject tooltipUI;

    [Header("Effects")]
    [SerializeField] private ParticleSystem interactionEffect;
    [SerializeField] private AudioClip interactionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HideTooltip();
    }

    public void OnInteract()
    {
        objectAnimator.SetTrigger(objectInteractTriggerName);

        GUIManager.Instance.UpdateTaskCount();

        // Trigger interaction effects
        if (interactionEffect != null)
        {
            interactionEffect.Play();
        }

        if (interactionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(interactionSound);
        }

        Debug.Log($"{gameObject.name} was interacted with!");
    }

    public void ShowTooltip()
    {
        if (tooltipUI != null)
        {

            tooltipUI.GetComponent<Tooltip>().SetToolTip();
            tooltipUI.SetActive(true);
            tooltipUI.GetComponent<Text>().text = tooltipText;
        }
    }

    public void HideTooltip()
    {
        if (tooltipUI != null)
        {
            tooltipUI.SetActive(false);
        }
    }
}
