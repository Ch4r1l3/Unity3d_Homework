using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserAction
{
    void start();
    void restart();
    void stop();
    void win();
}