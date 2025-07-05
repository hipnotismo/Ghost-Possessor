using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateList : MonoBehaviour
{
    public abstract List<BaseState> Initialize(FiniteStateMachine machine,PlayerController2 player);
}
