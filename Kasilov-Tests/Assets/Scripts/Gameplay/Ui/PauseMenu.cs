using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.Ui
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private bool gameIsPaused = false;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                    Resume();
                else
                    Pause();                
            }
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            gameIsPaused = false;
        
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            gameIsPaused = true;
        
            Cursor.lockState = CursorLockMode.None;
        }

        public void ExitToMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
