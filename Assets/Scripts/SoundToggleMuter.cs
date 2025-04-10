using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleMuter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private AudioListener _listener;

    private bool _isMusicOn = true;
    private string _buttonTextWhenSoundOn = "Выкл звук";
    private string _buttonTextWhenSoundOff = "Вкл звук";

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleMuteSoundOption);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMuteSoundOption);
    }

    private void ToggleMuteSoundOption()
    {
        _isMusicOn = !_isMusicOn;
        _listener.enabled = _isMusicOn;
        _buttonText.text = _isMusicOn ? _buttonTextWhenSoundOn : _buttonTextWhenSoundOff;
    }

}
