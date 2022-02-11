using UnityEngine;

namespace MainMenu
{
    public class InitializeMainMenu : MonoBehaviour
    {
        private void Start()
        {
            if (PlayerPrefs.HasKey("Language") == false)
            {
                if (Application.systemLanguage == SystemLanguage.Russian) 
                    PlayerPrefs.SetInt("Language", 1);
                else 
                    PlayerPrefs.SetInt("Language", 0);
            }

            TranslationController.Select_language(PlayerPrefs.GetInt("Language"));
        }

        public void Language_change(int languageID)
        {
            PlayerPrefs.SetInt("Language", languageID);
            TranslationController.Select_language(PlayerPrefs.GetInt("Language"));
        }
    }
}
