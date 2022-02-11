using UnityEngine;

namespace Gameplay.ScriptableObjects
{
    public interface IFigureColorsScriptableObject
    {
        Material GetColorByID(int id);
    }
}