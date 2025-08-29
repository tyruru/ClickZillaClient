using TMPro;
using UnityEngine;

public class PopupWidget : MonoBehaviour
{
    [SerializeField] private PopupButtonCommand _command;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetData(string text)
    {
        _text.text = text;
    }
}
