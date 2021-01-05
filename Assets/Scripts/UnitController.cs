using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{

    public enum UnitState
    {
        Idle,
        Spacing,
        Chasing,
        Attacking
    }

    public Unit m_Unit;
    public UnitView m_UnitView;

    Unit target;
    Unit closeAlly;
    UnitState unitState;
    bool IsInitialized = false;

    void Update()
    {
        if (IsInitialized)
        {
            CheckState();
            DoAction();
        }
    }

    public void ActivateUnitController(bool activation)
    {
        IsInitialized = activation;
    }

    void ChaseUnit()
    {
        //this is to get the direction on the same plane
        Vector3 direction = target.transform.position - transform.position;
        Vector3 directionNormalized = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
        // move towards target
        transform.position += directionNormalized * m_Unit.SPEED * Time.deltaTime;
    }
    void GetPersonalSpace()
    {
        //this is to get the direction on the same plane
        Vector3 direction = transform.position-closeAlly.transform.position;
        Vector3 directionNormalized = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
        // move away from closeAlly
        transform.position += directionNormalized * m_Unit.SPEED* Time.deltaTime;
    }

    void Attack(Unit target)
    {        
        //this is here for the unit to attack every ATKSPD value of time
        if (m_Unit.AtkTimer > m_Unit.ATKSPD)
        {
            target.GetHit(m_Unit.ATK);
            if (m_UnitView)
            {
                m_UnitView.DrawAttackLine(transform.position, target.transform.position);
            }
            m_Unit.AtkTimer = 0;
        }
        
    }

    public Unit GetClosest(List<Unit> units)
    {
        Unit closestUnit = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Unit u in units)
        {
            if (u!=m_Unit)
            { 
                Vector3 directionToTarget = u.transform.position - currentPosition;
                float distance = directionToTarget.sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestUnit = u;
                }
            }
        }
        return closestUnit;
    }

    private void DoAction()
    {
        m_Unit.AtkTimer += Time.deltaTime;
        switch (unitState)
        {
            case UnitState.Idle:
                break;
            case UnitState.Spacing:
                GetPersonalSpace();
                break;
            case UnitState.Chasing:
                ChaseUnit();
                break;
            case UnitState.Attacking:
                Attack(Target);
                break;
            default:
                break;
        }    
    }

    private void CheckState()
    {
        if(!Target)
        {
            unitState = UnitState.Idle;
        }
        else
        {
            if (CheckCloseAllyDistance())
            {
                unitState = UnitState.Spacing;
            }
            else if (CheckCloseTargetDistance())
            {
                unitState = UnitState.Chasing;
            }
            else
            {
                unitState = UnitState.Attacking;
            }
        }
    }

    bool CheckCloseAllyDistance()
    {
        if (CloseAlly==null)
        {
            return false;
        }

        return Vector3.Distance(CloseAlly.transform.position, transform.position) <= (m_Unit.transform.localScale.x + CloseAlly.transform.localScale.x);
    }

    bool CheckCloseTargetDistance()
    {
        return (Vector3.Distance(Target.transform.position, transform.position) > m_Unit.AtkRange);
    }
    public Unit Target { get => target; set => target = value; }
    public Unit CloseAlly { get => closeAlly; set => closeAlly = value; }
}
