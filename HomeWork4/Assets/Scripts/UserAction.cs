using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public interface UserAction
    {
        void start();
        void fire();
        void restart();
    }
}
