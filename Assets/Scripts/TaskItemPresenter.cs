using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class TaskItemPresenter : MonoBehaviour
{
    private TaskItem _item;

    private SpriteRenderer _spriteRenderer;

    private Animator _animator;

    /// <summary>
    /// This one is called before an actual Start
    /// </summary>
    public void SetItem(TaskItem item)
    {
        _item = item;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator       = GetComponent<Animator>();

        if (_item is null)
        {
            throw new InvalidOperationException("No item is set to TaskItemPresenter");
        }

        _spriteRenderer.color = new Color(_item.colorR, _item.colorG, _item.colorB);
    }

    public void AnimateDismiss()
    {
        _animator.SetTrigger("dismiss");
    }

    public void AnimateWrong()
    {
        _animator.SetTrigger("wrong");
    }

    public void OnDismissAnimationEnded()
    {
        Destroy(transform.parent.gameObject);
    }

    public void OnWrongAnimationEnded()
    {
        transform.parent.position = Vector3.zero;
    }
}