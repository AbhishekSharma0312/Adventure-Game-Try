using UnityEngine;

public class FinalEventTrigger : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator finalSceneAnimator;

    [SerializeField] private string finalSceneTrigger;
    [SerializeField] private string playerCheerTrigger;

    public void TriggerFinalScene()
    {
        playerAnimator.SetTrigger(playerCheerTrigger);
        finalSceneAnimator.SetTrigger(finalSceneTrigger);
    }
}
