using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MainMenu
{
    public class TranslationController : MonoBehaviour
    {
        private static int LanguageId;
        private static List<TranslatableText> listId = new List<TranslatableText>();

        #region ВЕСЬ ТЕКСТ [двухмерный массив]

        private static string[,] LineText =
        {
            #region Английский

            {
                "New Game", // 0
                "Options", // 1
                "Reference", // 2
                "Continue", // 3
                "Quit", // 4
                "Yes", // 5
                "No", // 6
                "Russian", // 7
                "English", // 8
                "Change language", // 9
                "Music volume", // 10
                "Graphics quality", // 11
                "Screen resolution", // 12
                "Apply", // 13
                "Back", // 14
                "Forward", // 15
                "Back", // 16
                "Left", // 17
                "Right", // 18
                "Interaction", // 19
                "Jump",// 20
                "Are you shure ?", // 21
                "Start", // 22
                "Select difficulty level", // 23
                "Press E to interact", // 24
                "Color", // 25
                "Animation" // 26
            },

            #endregion

            #region Русский

            {
                "Новая игра", // 0
                "Опции", // 1
                "Справка", // 2
                "Продолжить", // 3
                "Выход", // 4
                "Да", // 5
                "Нет", // 6
                "Русский", // 7
                "Английский", // 8
                "Сменить язык", // 9
                "Громкость музыки", // 10
                "Качество графики", // 11
                "Разрешение экрана", // 12
                "Применить", // 13
                "Назад", // 14
                "Идти вперед", // 15
                "Идти назад", // 16
                "Идти влево", // 17
                "Идти вправо", // 18
                "Взаимодействие", // 19
                "Прыжок", // 20
                "Вы уверены ?", // 21
                "Играть", // 22
                "Выберите уровень сложности ?", // 23
                "Нажмите Е для взаимодействия", // 24
                "Окрас", // 25
                "Анимация" // 26
            },

            #endregion
        };
        #endregion

        static public void Select_language(int id)
        {
            LanguageId = id;
            Update_texts();
        }

        static public string Get_text(int textKey)
        {
            return LineText[LanguageId, textKey];
        }

        static public void Add(TranslatableText idtext)
        {
            listId.Add(idtext);
        }

        static public void Delete(TranslatableText idtext)
        {
            listId.Remove(idtext);
        }

        static public void Update_texts()
        {
            for (int i = 0; i < listId.Count; i++)
            {
                listId[i].UIText.text = LineText[LanguageId, listId[i].textID];
            
                if (PlayerPrefs.GetInt("Language") == 1)
                    listId[i].UIText.font = Resources.Load<TMP_FontAsset>("RobotoMono-VariableFont_wght SDF");
                else
                    listId[i].UIText.font = Resources.Load<TMP_FontAsset>("RobotoMono-VariableFont_wght SDF");
            }
        }
    }
}
