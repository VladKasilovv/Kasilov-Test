using System.Collections.Generic;
using Gameplay.Figures;
using MainMenu;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameplayInitialize : MonoBehaviour
    {
        [SerializeField] private FigureView[] figures;

        [SerializeField] private int figuresDifficultyCount;
        [SerializeField] private Transform[] figureContainers;

        private ChoiseDifficulty choiseDifficulty;
        
        private List<Transform> containersList = new List<Transform>();

        private bool onCollide;

        private void Start()
        {
            foreach (var container in figureContainers)
            {
                containersList.Add(container);
            }
            
            choiseDifficulty = new ChoiseDifficulty();
            
            SpawnObjects(choiseDifficulty.Difficulty);
        }

        private void SpawnObjects(int difficulty)
        {
            for (int i = 0; i < difficulty + figuresDifficultyCount; i++)
            {
                SpawnObject(RandomizeFigure());
            }
        }

        private void SpawnObject(IFigure figure)
        {
            var containerIndex = RandomizeContainer();
                
            Instantiate(figure.Figure, containersList[containerIndex]);
            containersList.RemoveAt(containerIndex);
        }

        private int RandomizeContainer()
        {
           var containerIndex = Random.Range(0, containersList.Count);
           return containerIndex;
        }
        
        private IFigure RandomizeFigure()
        {
            var figure = figures[Random.Range(0, figures.Length)];
            return figure;
        }
    }
}