using DG.Tweening;
using PopupButtons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Popup : MonoBehaviour
{
    [SerializeField] private string _titleText;
    [SerializeField] private string _contentText;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _content;
    [SerializeField] private Button _button;
    [SerializeField] private ButtonType _buttonType;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _container;
    private PopupButton _popupButton;
    private ButtonsFactory _buttonsFactory;
    Vector3 _offScreenLeftPosition;
    Vector3 _offScreenRightPosition;
    private const float SlideDuration = 1f;

    public void Construct(string titleText, string contentText, int sortOrder, ButtonType buttonType)
    {
        _titleText = titleText;
        _contentText = contentText;
        _buttonType = buttonType;
        _canvas.sortingOrder = sortOrder;
        _canvas.enabled = false;
    }

    private void Awake()
    {
        _offScreenLeftPosition = new Vector3(-Screen.width, 0, 0);
        _offScreenRightPosition = new Vector3(Screen.width, 0, 0);
        _canvas.enabled = false;
        _buttonsFactory = new ButtonsFactory();
        _popupButton =  _buttonsFactory.CreateButton(this, _buttonType);
        _button.onClick.AddListener(_popupButton.Execute);
        _title.text = _titleText;
        _content.text = _contentText;
    }

    public void Show()
    {
        _container.localPosition = _offScreenLeftPosition;
        _canvas.enabled = true;
        _container.DOLocalMove(Vector3.zero, SlideDuration);
    }

    public void Hide()
    {
        _container.DOLocalMove(_offScreenRightPosition, SlideDuration)
            .OnComplete(() => _canvas.enabled = false);
    }
}