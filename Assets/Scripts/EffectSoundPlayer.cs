using UnityEngine;
using UnityEngine.UI;

public class EffectSoundPlayer : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayEffect);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayEffect);
    }

    private void PlayEffect()
    {
        _audioSource.Play();
    }
}
