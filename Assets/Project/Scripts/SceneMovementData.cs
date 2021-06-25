using System;
using UnityEngine;

namespace Project
{
    [Serializable]
    [CreateAssetMenu(fileName = "SceneMovementData", menuName = "CreateSceneMovementData")]
    public class SceneMovementData : ScriptableObject
    {
        public enum SceneType
        {
            StartGame,
            FirstRuins,
            FirstRuinsToVillage
        }

        [SerializeField] private SceneType sceneType;

        public void OnEnable()
        {
            sceneType = SceneType.StartGame;
        }

        public void SetSceneType(SceneType scene)
        {
            sceneType = scene;
        }

        public SceneType GetSceneType()
        {
            return sceneType;
        }
    }
}