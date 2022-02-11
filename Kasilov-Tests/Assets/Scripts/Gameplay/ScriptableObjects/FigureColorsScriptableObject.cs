using System;
using Gameplay.Models;
using UnityEngine;

namespace Gameplay.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects", fileName = "FigureColors")]
    public class FigureColorsScriptableObject : ScriptableObject, IFigureColorsScriptableObject
    {
        [SerializeField] private FigureColorModel[] figureColorModels;
        
        public Material GetColorByID(int id)
        {
            foreach (var model in figureColorModels)
            {
                if (model.ID == id)
                    return model.FigureColorMaterial;
            }

            throw new Exception($"Cant find material with id {id}");
        }
    }
}