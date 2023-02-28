using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PopupSystem : MonoBehaviour
{
    [SerializeField] private bool _animate = true;

    private const int AnimationTime = 2;
    private List<Popup> _popups;
    private Queue<Popup> _popupQueue;
  
    private void Awake()
    {
        _popupQueue = new Queue<Popup>();
        _popups = GetComponentsInChildren<Popup>().ToList();
        _popups.ForEach(p => _popupQueue.Enqueue(p));
    }

    public async UniTask LoadPopups()
    {
        while (_popupQueue.Count > 0)
        {
            await UniTask.WaitUntil(() => _animate);
        
            var popup = _popupQueue.Dequeue();
            popup.Show();
            await UniTask.Delay(TimeSpan.FromSeconds(AnimationTime), true);
            popup.Hide();
            _popupQueue.Enqueue(popup);   
        }
    }

    public void AddToQueue(Popup popup) => 
        _popupQueue?.Enqueue(popup);

    public void ShowAllPopups()
    {
        _animate = false;
        _popups = GetComponentsInChildren<Popup>().ToList();
        _popups.ForEach(p => p.Show());
    }
}