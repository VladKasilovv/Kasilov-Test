using TMPro;
using UnityEngine;

namespace MainMenu
{
    public class TranslatableText : MonoBehaviour
    {
        [SerializeField] public int textID;

        [HideInInspector] public TextMeshProUGUI UIText;

        private void Awake()
        {
            UIText = GetComponent<TextMeshProUGUI>();
            TranslationController.Add(this);
        }

        private void OnEnable()
        {
            TranslationController.Update_texts();
        }

        private void OnDestroy()
        {
            TranslationController.Delete(this);
        }
    }
}
