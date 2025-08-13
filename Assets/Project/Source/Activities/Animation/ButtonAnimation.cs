using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{
    [FormerlySerializedAs("target")]
    [Header("UI References")]
    [SerializeField] private RectTransform _target; 
    [SerializeField] private Image _background; 
    [SerializeField] private TextMeshProUGUI _text; 

    [Header("Animation Settings")]
    [SerializeField] private float _pressScale = 0.9f;
    [SerializeField] private float _animTime = 0.1f;

    [Header("Colors")]
    [SerializeField] private Color _normalBg = Color.white;
    [SerializeField] private Color _pressedBg = new Color(0.8f, 0.8f, 0.8f); 
    [SerializeField] private Color _normalText = Color.white;
    [SerializeField] private Color _pressedText = Color.gray;

    private Vector3 _originalScale;

    private void Awake()
    {
        if (_target == null)
            _target = GetComponent<RectTransform>();
        _originalScale = _target.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _target.DOScale(_originalScale * _pressScale, _animTime).SetEase(Ease.OutQuad);

        _background.DOColor(_pressedBg, _animTime);
        
        if(_text != null)
            _text.DOColor(_pressedText, _animTime);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _target.DOScale(_originalScale, _animTime).SetEase(Ease.OutBack);

        _background.DOColor(_normalBg, _animTime);
        if(_text != null)
            _text.DOColor(_normalText, _animTime);
    }

    private void OnDestroy()
    {
        DOTween.Kill(_target);
        DOTween.Kill(_background);
        _text?.DOKill();
    }
}
