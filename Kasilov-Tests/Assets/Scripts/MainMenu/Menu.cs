using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Dropdown dropdownResolution;
    
        private Resolution[] _resolutions;
    
        private void Start()
        {
            // Resolution
            dropdownResolution.ClearOptions();
            _resolutions = Screen.resolutions;

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
        
            for (int i = 0; i < _resolutions.Length; i++)
            {
                string option = _resolutions[i].width + " x " + _resolutions[i].height + 
                                " @ " + _resolutions[i].refreshRate + "hz";
                options.Add(option);

                if (_resolutions[i].width == Screen.currentResolution.width && 
                    _resolutions[i].height == Screen.currentResolution.height)
                    currentResolutionIndex = i;
            }
        
            dropdownResolution.AddOptions(options);
            dropdownResolution.value = currentResolutionIndex;
            dropdownResolution.RefreshShownValue();
        }
    
        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void NewGame()
        {
            SceneManager.LoadScene("MainGame");
        }

        public void ExitGame()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
