using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstController : MonoBehaviour ,SceneController,UserAction{
    public GameObject[] areas;
    private List<GameObject> patrols;
    public UserGui userGui;
    CCActionManager actionManager;
    private List<GameObject> inChase;
    public bool is_start = false;

    public void loadResources()
    {
        actionManager = gameObject.AddComponent<CCActionManager>() as CCActionManager;
        patrols = new List<GameObject>();
        inChase = new List<GameObject>();
        foreach (var a in areas)
        {
            var p = PatrolFactory.getInstance().getPatrol();
            patrols.Add(p);
            p.transform.position = a.transform.position;
            p.GetComponent<PatrolData>().center = a.transform.position;
            
            a.GetComponent<AreaTrigger>().enter += p.GetComponent<PatrolData>().OnPlayerEnterArea;
            a.GetComponent<AreaTrigger>().exit += p.GetComponent<PatrolData>().OnPlayerExitArea;

            p.GetComponent<PatrolTrigger>().enter += patrolChase;
            p.GetComponent<PatrolTrigger>().exit += patrolOut;
        }
    }

    public void start()
    {
        foreach(var p in patrols)
        {
            p.SetActive(true);
        }
        for (int i = 0; i < areas.Length; i++)
        {
            patrols[i].transform.position = areas[i].transform.position;
            actionManager.goPatrol(patrols[i], areas[i].transform.position);
        }
    }

    public void restart()
    {
        gameObject.transform.position = Vector3.zero;
        actionManager.DestroyAll();
        for (int i=0;i<areas.Length;i++)
        {
            patrols[i].transform.position = areas[i].transform.position;
            actionManager.goPatrol(patrols[i],areas[i].transform.position);
        }
    }
    
    public void patrolChase(GameObject p)
    {
        is_start = true;
        if(p.GetComponent<PatrolData>().IsInArea)
        {
            p.GetComponent<PatrolData>().IsChasing = true;
            actionManager.patrolChase(p, gameObject);
        }
        else
        {
            inChase.Add(p);
        }
    }

    public void patrolOut(GameObject p)
    {
        if(inChase.Contains(p))
        {
            inChase.Remove(p);
        }

        if(p.GetComponent<PatrolData>().IsChasing)
        {
            p.GetComponent<PatrolData>().IsChasing = false;
            actionManager.goPatrol(p, p.GetComponent<PatrolData>().center);
        }
    }
	
	// Update is called once per frame
	void Update () {
        for(int i=0;i<inChase.Count;i++)
        {
            if(inChase[i].GetComponent<PatrolData>().IsInArea)
            {
                inChase[i].GetComponent<PatrolData>().IsChasing = true;
                actionManager.patrolChase(inChase[i], gameObject);
                inChase.RemoveAt(i);
                i -= 1;
            }
        }
	}

    void Awake()
    {
        Director director = Director.getInstance();
        director.current = this;
        userGui = gameObject.AddComponent<UserGui>() as UserGui;
        loadResources();
    }

    public void stop()
    {
        userGui.state = GameState.Fail;
        actionManager.DestroyAll();
        is_start = false;
    }

    public void win()
    {
        userGui.state = GameState.Win;
        actionManager.DestroyAll();
        is_start = false;
    }
}
