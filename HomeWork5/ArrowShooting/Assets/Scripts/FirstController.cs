using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public enum GameState { Start, Running, Fail, Win };
    public class FirstController : MonoBehaviour, SceneController, UserAction
    {
        UserGui userGui;
        public GameState gameState;
        private SceneController scene;
        private CCActionManager actionManager;
        public GameObject ArrowOnBow;
        public Transform mainCamera;
        public Camera secondCam;

        void Awake()
        {
            Director director = Director.getInstance();
            director.current = this;
            userGui = gameObject.AddComponent<UserGui>() as UserGui;
            mainCamera = gameObject.transform.parent;
            loadResources();
        }

        public void loadResources()
        {
            actionManager = gameObject.AddComponent<CCActionManager>() as CCActionManager;
            gameState = GameState.Start;
        }

        public void restart()
        {

        }

        void Start()
        {

        }
        
        void Update()
        {
        }

        public void shootArrow()
        {
            var arrow = Instantiate(ArrowOnBow,mainCamera);
            actionManager.ShootArrow(arrow);
        }
    }

}
