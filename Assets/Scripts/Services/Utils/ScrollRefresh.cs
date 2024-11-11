using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UI.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRefresh : MonoBehaviour
{
    [HideInInspector] public ScrollRect ScrollRect;
    public Action<ScrollState> OnRefresh;

    private bool _isRefreshing = true;
    private float maxY = 1.05f;
    private float minY = -0.05f;

    private void Awake()
    {
        ScrollRect = GetComponent<ScrollRect>();
        On();
    }

    private void OnScroll(Vector2 position)
    {
        if (_isRefreshing) return;
        if (position.y >= maxY) OnRefresh?.Invoke(ScrollState.top);
        else if (position.y <= minY) OnRefresh?.Invoke(ScrollState.bot);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void LastPage()
    {
        maxY = 1f;
        minY = 0f;
    }

    public void NormalPage()
    {
        maxY = 1.05f;
        minY = -0.05f;
    }

    public void RefreshOn() => _isRefreshing = true;

    public void RefreshOff() => _isRefreshing = false;

    private void OnDestroy() => Off();

    public void On() => ScrollRect.onValueChanged.AddListener(OnScroll);

    public void Off() => ScrollRect.onValueChanged.RemoveListener(OnScroll);
}

public enum ScrollState
{
    top,
    bot
}