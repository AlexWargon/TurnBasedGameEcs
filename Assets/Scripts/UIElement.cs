using System;
using DG.Tweening;
using UnityEngine;

public abstract class UIElement : MonoBehaviour {
    protected bool Active => gameObject.activeInHierarchy;
    public virtual void Show(Action callback = null) {
        if(Active) return;
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, 0.15f).OnComplete(() => {
            callback?.Invoke();
        });
    }
    public virtual void Hide(Action callback = null) {
        if(!Active) return;
        transform.DOScale(Vector3.zero, 0.15f).OnComplete(() => {
            callback?.Invoke();
            gameObject.SetActive(false);
        });
    }
}