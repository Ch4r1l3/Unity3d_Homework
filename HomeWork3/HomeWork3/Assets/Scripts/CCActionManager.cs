using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAD
{
    public class CCActionManager : SSActionManager, ISSActionCallBack
    {
        public FirstController sceneController;

        public void moveBoat(GameObject boat, Vector3 target)
        {
            CCBoatMove boatMoveToLeft = CCBoatMove.GetSSAction(target);
            this.RunAction(boat, boatMoveToLeft, this);
        }

        public void moveCharacter(GameObject obj, Vector3 dest)
        {
            CCCharacterMove characterMove = CCCharacterMove.GetSSAction(dest);
            this.RunAction(obj, characterMove, this);
        }
        

        protected new void Update()
        {
            base.Update();
        }

        public void SSActionEvent(SSAction sourse, SSActionEventType events = SSActionEventType.Completed)
        {
        }
    }
}