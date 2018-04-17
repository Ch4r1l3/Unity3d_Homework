using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public enum GameState { Start, Running, Fail ,Win};
    public class UserGui : MonoBehaviour
    {
        public GameState state { get; set; }
        public int score,round,hitGround;
        private UserAction action;
        GUIStyle style;
        GUIStyle textstyle;
        GUIStyle buttonStyle;
        float nextFireTime;
        public float fireRate = 0.25f;
        public float fireSpeed = 500f;
        public GameObject bullet;
        void Start()
        {
            action = Director.getInstance().current as UserAction;
            bullet = Instantiate(Resources.Load("Perfabs/Bullet", typeof(GameObject)), new Vector3(-10,-6,0), Quaternion.identity, null) as GameObject;
            style = new GUIStyle();
            style.fontSize = 40;
            style.alignment = TextAnchor.MiddleCenter;

            textstyle = new GUIStyle();
            textstyle.fontSize = 20;
            textstyle.alignment = TextAnchor.MiddleCenter;

            buttonStyle = new GUIStyle("button");
            buttonStyle.fontSize = 30;
            state = GameState.Start;
            score = 0;
            hitGround = 0;
            nextFireTime = 0;
            round = 1;
        }

        public void restart()
        {
            score = 0;
            round = 1;
            hitGround = 0;
        }

        void OnGUI()
        {
            if (state==GameState.Start)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Start", buttonStyle))
                {
                    state = GameState.Running;
                    action.restart();
                }
            }
            else if (state == GameState.Fail)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    state = GameState.Running;
                    action.restart();
                    restart();
                }
            }
            else if (state == GameState.Win)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    state = GameState.Running;
                    action.restart();
                    restart();
                }
            }
            else
            {
                GUI.Label(new Rect(26, 30, 100, 50), "Score: "+score, textstyle);
                GUI.Label(new Rect(30, 60, 100, 50), "Round: " + round, textstyle);
                GUI.Label(new Rect(47, 90, 100, 50), "HitGround: " + hitGround, textstyle);
            }
        }


        void Update()
        {
            if (state==GameState.Running&& Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
            {
                nextFireTime = Time.time + fireRate;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //bullet.rigidbody.velocity = Vector3.zero;                     
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody>().AddForce(ray.direction * fireSpeed, ForceMode.Impulse);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Disk")
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}