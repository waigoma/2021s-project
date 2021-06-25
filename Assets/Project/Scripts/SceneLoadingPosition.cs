using System;
using UnityEngine;

namespace Project
{
    public class SceneLoadingPosition : MonoBehaviour
    {
        [SerializeField] private SceneMovementData sceneMovementData = null;

        private void Start()
        {
            if (sceneMovementData.GetSceneType() == SceneMovementData.SceneType.StartGame)
            {
                var initialPosition = GameObject.Find("InitialPosition").transform;
                transform.position = initialPosition.position;
                transform.rotation = initialPosition.rotation;
            }
            else if (sceneMovementData.GetSceneType() == SceneMovementData.SceneType.FirstRuins)
            {
                var initialPosition = GameObject.Find("InitialPosition").transform;
                transform.position = initialPosition.position;
                transform.rotation = initialPosition.rotation;      
            }
            else if (sceneMovementData.GetSceneType() == SceneMovementData.SceneType.FirstRuinsToVillage)
            {
                var initialPosition = GameObject.Find("InitialPositionFirstRuinsToFirstVillage").transform;
                transform.position = initialPosition.position;
                transform.rotation = initialPosition.rotation;
            }
        }
    }
}