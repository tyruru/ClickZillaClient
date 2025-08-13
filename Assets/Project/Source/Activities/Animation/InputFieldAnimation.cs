using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldAnimation : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private RectTransform _inputFiedlRectTransform;   
    [SerializeField] private Image _background;       
    [SerializeField] private Image _outline;          

    [Header("Animation Settings")]
    [SerializeField] private float _focusScale = 1.05f;
    [SerializeField] private float _animTime = 0.15f;

    [Header("Colors")]
    [SerializeField] private Color _normalBg = Color.white;
    [SerializeField] private Color _focusBg = new Color(0.95f, 0.95f, 1f);
    [SerializeField] private Color _normalOutline = Color.gray;
    [SerializeField] private Color _focusOutline = Color.blue;

    private TMP_InputField _inputField;
    private Vector3 _originalScale;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        if (_inputFiedlRectTransform == null) 
            _inputFiedlRectTransform = GetComponent<RectTransform>();
        
        _originalScale = _inputFiedlRectTransform.localScale;

        _inputField.onSelect.AddListener(OnFocus);
        _inputField.onDeselect.AddListener(OnUnfocus);
    }

    private void OnFocus(string _)
    {
        _inputFiedlRectTransform.DOScale(_originalScale * _focusScale, _animTime).SetEase(Ease.OutQuad);

        if (_background != null)
            _background.DOColor(_focusBg, _animTime);

        if (_outline != null)
            _outline.DOColor(_focusOutline, _animTime);
    }

    private void OnUnfocus(string _)
    {
        _inputFiedlRectTransform.DOScale(_originalScale, _animTime).SetEase(Ease.OutBack);
       
        if (_background != null)
            _background.DOColor(_normalBg, _animTime);
        
        if (_outline != null)
            _outline.DOColor(_normalOutline, _animTime);
    }

    private void OnDestroy()
    {
        _inputFiedlRectTransform.DOKill();
        _background?.DOKill();
        _outline?.DOKill();
    }
}
