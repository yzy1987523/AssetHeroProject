using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// AI有多种行为可选，但是满足某些条件时会更趋向于选择指定的行为：
/// 即行为的初始权重相同，但是会随着外界的改变而改变
/// </summary>

public class EnemyActor : MonoBehaviour
{
    #region Parameters
    EnemyInfo enemyInfo;
    #endregion
    #region Properties
    #endregion
    #region Private Methods 

    #region base
    float[] GetOrgWeights()
    {
        var _weights = new float[enemyInfo.baseActionTypeList.Count];
        for (var i = 0; i < _weights.Length; i++)
        {
            _weights[i] = 100;
        }
        return _weights;
    }
    int GetNextAction()
    {
        var _weights = GetOrgWeights();
        FindSomething(_weights);
        MeetSomething(_weights);        
        return NormalTool.GetRandomIndex(_weights, UnityEngine.Random.value);
    }
    void Action(int _index)
    {       
        if (_index < enemyInfo.baseActionTypeList.Count)
        {
            var _type = (BaseActionType)_index;
            switch (_type)
            {
                case BaseActionType.Move:
                    Move();
                    break;
                case BaseActionType.Rot90:
                    Rot(90);
                    break;
                case BaseActionType.Rot180:
                    Rot(180);
                    break;
                case BaseActionType.Jump:
                    Jump();
                    break;
            }
        }
        else if(_index < enemyInfo.intermediateActionTypeList.Count)
        {
            var _type = (IntermediateActionType)_index;
            switch (_type)
            {
                case IntermediateActionType.Jump:
                    Jump();
                    break;
                case IntermediateActionType.LookAt:
                    LookAt();
                    break;
            }
        }
        else
        {
            var _type = (AdvancedActionType)_index;
            switch (_type)
            {
                case AdvancedActionType.Attack:
                    Attack();
                    break;
                case AdvancedActionType.RunAway:
                    RunAway();
                    break;
            }

        }

    }
    #endregion


    //在检测范围内发现了什么东西:某个行为的权重增加
    void FindSomething(float[] _weights)
    {
    }
    //触碰到了什么东西:某个行为的权重增加
   void MeetSomething(float[] _weights)
    {
        
    }
    void Move()
    {

    }
    void Rot(float _angle)
    {

    }
    void Jump() { }
    void Attack() { }
    void LookAt() { }
    void RunAway() { }
    #endregion
    #region Utility Methods
    public void Create(EnemyInfo _enemyInfo,Vector3 _pos)
    {

    }
    #endregion
}
