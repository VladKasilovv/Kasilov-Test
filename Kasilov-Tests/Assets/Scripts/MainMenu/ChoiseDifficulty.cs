using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MainMenu
{
    public class ChoiseDifficulty : MonoBehaviour
    {
        [SerializeField] private Slider difficultySlider;
        [SerializeField] private TextMeshProUGUI difficultyText;

        private static int difficulty = 1;
        public int Difficulty => difficulty;

        private void Start()
        {
            difficultySlider.onValueChanged.AddListener((v) =>
            {
                difficultyText.text = v.ToString("0");
                difficulty = (int) difficultySlider.value;
            });
        }
    }
}

