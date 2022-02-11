using UnityEngine;
using UnityEngine.Audio;

namespace MainMenu
{
    public class VolumeValue : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private AudioSource audioSrc;

        private void Start()
        {
            audioSrc.volume = 0.5f;
        }

        private void Update()
        {
            audioSrc.volume = PlayerPrefs.GetFloat("Volume");
        }

        private void SetVolume(float volume)
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        }
    }
}
