using UnityEngine;

namespace Gameplay.Figures
{
    public class FigureView : MonoBehaviour, IFigure
    {
        [SerializeField] private GameObject currentFigure;

        public GameObject Figure => currentFigure;
    }
}