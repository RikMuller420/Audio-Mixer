using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudionGroupVolumeTuner : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioGroup _audioGroup;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeAudioGroupVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeAudioGroupVolume);
    }

    private void ChangeAudioGroupVolume(float value)
    {
        float mixerVolume = Mathf.Log10(value) * Constants.LogToDbRatio;
        _mixer.audioMixer.SetFloat(_audioGroup.ToString(), mixerVolume);
    }
}
