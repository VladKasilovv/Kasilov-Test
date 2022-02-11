using UnityEngine;

namespace Gameplay.Figures
{
    public class FigureContainersView : MonoBehaviour
    {
        [SerializeField] private Transform[] figureContainers;

        public Transform[] FigureContainers => figureContainers;
    }
}