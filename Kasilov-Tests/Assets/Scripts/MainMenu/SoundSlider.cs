using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class SoundSlider : MonoBehaviour
    {
        [SerializeField] private Slider sliderMusic;
    
        private float _oldVolume;

        private void Awake()
        {
            _oldVolume = sliderMusic.value;
            if (!PlayerPrefs.HasKey("Volume"))
                sliderMusic.value = 1;
            else
                sliderMusic.value = PlayerPrefs.GetFloat("Volume");
        }

        private void Update()
        {
            if (_oldVolume != sliderMusic.value)
            {
                PlayerPrefs.SetFloat("Volume", sliderMusic.value);
                PlayerPrefs.Save();
                _oldVolume = sliderMusic.value;
            }
        }
    }
}
