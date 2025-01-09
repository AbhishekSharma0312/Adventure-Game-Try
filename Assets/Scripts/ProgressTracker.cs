using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    [Header("Progress UI")]
    [SerializeField] private Text progressText;

    [Header("Final Event")]
    [SerializeField] private FinalEventTrigger finalAnimation;

    private int totalTasks = 3;
    private int completedTasks = 0;

    public void TaskCompleted()
    {
        completedTasks++;
        UpdateProgress();

        if (completedTasks >= totalTasks)
        {
            TriggerFinalEvent();
        }
    }

    private void UpdateProgress()
    {
        if (progressText != null)
        {
            progressText.text = $"{completedTasks}/{totalTasks} tasks completed";
        }
    }

    private void TriggerFinalEvent()
    {
        if (finalAnimation != null)
        {
            finalAnimation.TriggerFinalScene();
        }

        Debug.Log("All tasks completed! Final event triggered.");
    }
}

