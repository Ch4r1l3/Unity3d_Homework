using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class CCActionManager : SSActionManager,ISSActionCallBack
    {
        public void ShootArrow(GameObject arrow)
        {
            CCShootArrow shootArrow = CCShootArrow.GetSSAction();
            this.RunAction(arrow, shootArrow, this);
        }

        public void SSActionEvent(SSAction sourse, SSActionEventType events = SSActionEventType.Completed)
        {
        }
    }

}



