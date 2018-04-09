using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PAD;


public class FirstController : MonoBehaviour, SceneController,UserAction
{
    readonly Vector3 water_pos = new Vector3(0, 0.5F, 0);
    readonly Vector3 boatFromPosition = new Vector3(5, 1, 0);
    readonly Vector3 boatToPosition = new Vector3(-5, 1, 0);
    BoatController boat;
    CoastController fromCoast;
    CoastController toCoast;

    MyCharacterController []characters = new MyCharacterController[6];

    UserGui userGui;
    CCActionManager actionManager;

    public void loadResources()
    {
        GameObject water = Instantiate(Resources.Load("Perfabs/Water", typeof(GameObject)), water_pos, Quaternion.identity, null) as GameObject;
        water.name = "water";
        fromCoast= new CoastController(new Vector3(9, 1, 0));
        toCoast= new CoastController(new Vector3(-9, 1, 0));
        for(int i=0;i<6;i++)
        {
            MyCharacterController mc;
            if (i<3)
                mc = new MyCharacterController(CharacterType.Devil);
            else
                mc = new MyCharacterController(CharacterType.Priest);
            characters[i] = mc;
            var _pos = fromCoast.getEmptyPosition();
            mc.setPosition(_pos);
            mc.getOnCoast(fromCoast.getGameobj(), _pos,CharacterPosition.From);
            fromCoast.addCharacter(mc);
        }
        boat = new BoatController(boatFromPosition,boatToPosition);
        userGui.state = GameState.NotWin;
        actionManager = gameObject.AddComponent<CCActionManager>() as CCActionManager;
    }

    public void moveBoat()
    {
        if (userGui.state==GameState.NotWin)
        {
            if(boat.hasPassenger())
            {
                var pos=boat.Move();
                actionManager.moveBoat(boat.getGameobj(), pos);
            }
            if (!checkGame())
                userGui.state = GameState.Fail;
        }
    }

    public void restart()
    {
        boat.reset();
        fromCoast.reset();
        toCoast.reset();
        for(int i=0;i<6;i++)
        {
            var mc = characters[i];
            var _pos = fromCoast.getEmptyPosition();
            mc.setPosition(_pos);
            mc.getOnCoast(fromCoast.getGameobj(), _pos, CharacterPosition.From);
            fromCoast.addCharacter(mc);
        }
    }

    public void characterClick(MyCharacterController c)
    {
        if (userGui.state != GameState.NotWin)
            return;
        if(c.pos==CharacterPosition.From)
        {
            if(boat.getBoatPos()==BoatState.From && boat.getEmptyIndex()!=-1)
            {
                var _pos = boat.getEmptyPosition();
                c.getOnBoat(boat.getGameobj(), _pos);
                fromCoast.removeCharacter(c);
                boat.GetOnBoat(c);
                actionManager.moveCharacter(c.getGameobj(),_pos);
            }
        }
        else if(c.pos==CharacterPosition.To)
        {
            if (boat.getBoatPos() == BoatState.To && boat.getEmptyIndex() != -1)
            {
                var _pos = boat.getEmptyPosition();
                c.getOnBoat(boat.getGameobj(), _pos);
                toCoast.removeCharacter(c);
                boat.GetOnBoat(c);
                actionManager.moveCharacter(c.getGameobj(), _pos);
            }
        }
        else
        {
            if(boat.getBoatPos()==BoatState.From)
            {
                var _pos = fromCoast.getEmptyPosition();
                c.getOnCoast(fromCoast.getGameobj(), _pos, CharacterPosition.From);
                fromCoast.addCharacter(c);
                boat.GetOffBoat(c);
                actionManager.moveCharacter(c.getGameobj(), _pos);
            }
            else
            {
                var _pos = toCoast.getEmptyPosition();
                c.getOnCoast(toCoast.getGameobj(), _pos, CharacterPosition.To);
                toCoast.addCharacter(c);
                boat.GetOffBoat(c);
                actionManager.moveCharacter(c.getGameobj(), _pos);
            }
        }
        if (toCoast.getEmptyIndex() == -1)
            userGui.state = GameState.Win;
    }

    void Awake()
    {
        Director director = Director.getInstance();
        director.current = this;
        userGui = gameObject.AddComponent<UserGui>() as UserGui;
        loadResources();
    }

    bool checkGame()
    {
        int[] num = boat.checkGame();
        int[] fromnum = fromCoast.checkGame();
        int[] tonum = toCoast.checkGame();
        if (boat.getBoatPos() == BoatState.From)
        {
            for (int i = 0; i < num.Length; i++)
                num[i] += fromnum[i];
            if (num[0] > num[1] && num[1] != 0)
                return false;
            if (tonum[0] > tonum[1] && tonum[1] != 0)
                return false;
        }
        else
        {
            for (int i = 0; i < num.Length; i++)
                num[i] += tonum[i];
            if (num[0] > num[1] && num[1] != 0)
                return false;
            if (fromnum[0] > fromnum[1] && fromnum[1] != 0)
                return false;
        }
        return true;
    }
    
}
