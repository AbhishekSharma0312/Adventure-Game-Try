using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance;

    [SerializeField] ProgressTracker progressTracker;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTaskCount()
    {
        progressTracker.TaskCompleted();
    }
}
