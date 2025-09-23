using UnityEngine;
using Zenject;

public class PopupForm : MonoBehaviour
{
    [SerializeField] private PopupWidget _popupWidget;
    [SerializeField] private Transform _container;
    
    private PopupManager _popupManager;
    
    [Inject]
    public void Construct(PopupManager popupManager)
    {
        _popupManager = popupManager;
    }

    public void Initialize()
    {
        _container.gameObject.SetActive(false);
        foreach (var command in _popupManager.Storage)
        {
            var obj = Instantiate(_popupWidget, _container, false);
            obj.GetComponent<PopupButtonCommand>().Initialize(command);
            obj.SetData(command.Message);
        }
    }

    [ContextMenu("Show")]
    public void Show()
    {
        _container.gameObject.SetActive(true);
    }

    [ContextMenu("Hide")]
    public void Hide()
    {
        
        _container.gameObject.SetActive(false);
    }
}
