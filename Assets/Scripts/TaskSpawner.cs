using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject taskItemPrefab;

    [SerializeField]
    private Exercise exercise;

    private int _currentIndex;

    private TaskItemPresenter _currentTaskItemPresenter;

    [SerializeField]
    private AudioController audioController;

    [SerializeField]
    private ScreenSwitcher manager;

    private void Start()
    {
        _currentIndex = -1;
        Next();
    }

    private TaskItemPresenter Spawn()
    {
        var item              = exercise.items[_currentIndex];
        var instance          = Instantiate(taskItemPrefab);
        var taskItemPresenter = instance.GetComponentInChildren<TaskItemPresenter>();
        taskItemPresenter.SetItem(item);

        return taskItemPresenter;
    }

    public void ReleaseOverLeft()
    {
        ReleaseItem(0);
    }

    public void ReleaseOverRight()
    {
        ReleaseItem(1);
    }

    private void ReleaseItem(int bucket)
    {
        var exerciseItem = exercise.items[_currentIndex];
        if (exerciseItem.correctAnswer == bucket)
        {
            _currentTaskItemPresenter?.AnimateDismiss();
            audioController.PlayFxGood();
            Next();
        }
        else
        {
            _currentTaskItemPresenter?.AnimateWrong();
            audioController.PlayFxWrong();
        }
    }

    private void Next()
    {
        if (_currentIndex + 1 < exercise.items.Length)
        {
            _currentIndex++;
            _currentTaskItemPresenter = Spawn();
        }
        else
        {
            manager.End();
        }
    }
}