using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ResourcesProvider;
using UnityEngine;
using UnityEngine.Networking;

public class LevelInstaller : MonoBehaviour
{
    [SerializeField] private List<ResourceData> _resourceData;
    [SerializeField] private Canvas _popupCanvas;
    [SerializeField] private PopupSystem _popupSystem;
    private ResourceProvider _resourcesProvider;
    private List<UniTask> _tasks;

    async void Start()
    {
        _popupCanvas.enabled = false;
        _tasks = new List<UniTask>();
        _resourcesProvider = new ResourceProvider();
        //LoadResources();
        //await UniTask.WhenAll(_tasks);
        _popupCanvas.enabled = true;
        _popupSystem.LoadPopups();
    }

    private void LoadResources()
    {
        foreach (var resource in _resourceData)
            _tasks.Add(_resourcesProvider.LoadTextureAsync(resource, UnityWebRequestTexture.GetTexture(resource.Url)));
    }
}