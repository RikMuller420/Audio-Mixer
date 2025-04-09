using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundToggleMuter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _masterVolumeSlider;

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
        float volume = GetDbFromNormalizedValue(_isMusicOn ? _masterVolumeSlider.value : Constants.MuteNormalizedSoundValue);
        _mixer.audioMixer.SetFloat(AudioGroup.MasterVolume.ToString(), volume);
        _buttonText.text = _isMusicOn ? _buttonTextWhenSoundOn : _buttonTextWhenSoundOff;
    }

    private float GetDbFromNormalizedValue(float sliderValue)
    {
        return Mathf.Log10(sliderValue) * Constants.LogToDbRatio;
    }
}
