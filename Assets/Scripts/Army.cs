using System.Collections.Generic;
using UnityEngine;

public enum ArmySide
{
    Blue,
    Red
}

public class Army : MonoBehaviour
{
    public UnitFactory m_UnitFactory;
    public ArmySide m_Side;
    public Material m_ArmyAttackMaterial;
    public List<Transform> m_ArmyPositions;

    List<Unit> m_Units;
    bool IsInitialized = false;

    private void Update()
    {
        if (IsInitialized)
        {
            CheckDeadUnitsAndClean();
        }
    }

    public void ActivateArmy(bool activation)
    {
        IsInitialized = activation;
        foreach (Unit item in m_Units)
        {
            item.m_UnitController.ActivateUnitController(activation);
        }
    }

    public void GenerateArmy(int size)
    {
        m_Units = new List<Unit>();
        for (int i = 0; i < size; i++)
        {
            Unit u = m_UnitFactory.Create();
            m_Units.Add(u);
            //Setup
            u.m_UnitView.SetLineRendererMaterial(m_ArmyAttackMaterial);
            u.m_UnitGO.transform.SetParent(this.transform);
            //Randomize position
            int rand = Random.Range(0, m_ArmyPositions.Count - 1);
            Vector3 randomPositiom = m_ArmyPositions[rand].position + (Vector3)Random.insideUnitCircle * 3;
            //making them all on the same plane
            randomPositiom.y = 0;
            u.m_UnitGO.transform.position = randomPositiom;
        }
        //Just so we can understand what our army is composed of
        DebugArmy();
    }

    void DebugArmy()
    {
        string Debugtext = gameObject.name + " is composed of : \n";
        foreach (Unit item in m_Units)
        {
            Debugtext += " A " + item.m_Size + " " + item.m_Color + " " + item.m_Shape + "\t";
        }
        Debug.Log(Debugtext);
    }

    private void CheckDeadUnitsAndClean()
    {
        List<Unit> unitsToDelete = new List<Unit>();
        foreach (Unit unit in m_Units)
        {
            if (unit.IsDead())
            {
                unitsToDelete.Add(unit);
            }
        }
        foreach (Unit unit in unitsToDelete)
        {
            m_Units.Remove(unit);
            Destroy(unit.gameObject);
        }
    }

    public bool IsDefeated()
    {
        return m_Units.Count == 0;
    }

    public void UpdateUnitsTargetAndBlocker(List<Unit> enemies, List<Unit> allies)
    {
        foreach (Unit unit in m_Units)
        {
            unit.m_UnitController.Target = unit.m_UnitController.GetClosest(enemies);
            unit.m_UnitController.CloseAlly = unit.m_UnitController.GetClosest(allies);
        }
    }

    public void CleanArmy()
    {
        if (m_Units == null)
            return;
      
        if (m_Units.Count == 0)
            return;

        foreach (Unit unit in m_Units)
        {
            Destroy(unit.gameObject);
        }
        m_Units.Clear();
    }

    public List<Unit> Units { get => m_Units; set => m_Units = value; }
}
