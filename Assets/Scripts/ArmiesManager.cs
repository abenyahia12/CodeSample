using System.Collections.Generic;
using UnityEngine;

public class ArmiesManager : MonoBehaviour
{
    public Dictionary<ArmySide, Army> m_Armies;
    public Army m_BlueArmy;
    public Army m_RedArmy;
    public GameManager m_GameManager;
    public float m_SearchTargetInterval = 0;
    public int m_ArmiesSize;

    float cooldown = 0;
    bool IsInitialized = false;

    private void Update()
    {
        if (IsInitialized)
        {
            SearchTargetsAndBlockers();
            CheckArmiesAlive();
        }
    }

    internal void Init()
    {
        LoadArmies();
    }

    public void Activate()
    {
        ActivateArmies();
        SearchTargetsAndBlockers();
    }

    void LoadArmies()
    {
        m_Armies = new Dictionary<ArmySide, Army>();
        m_Armies.Add(ArmySide.Blue, m_BlueArmy);
        m_Armies.Add(ArmySide.Red, m_RedArmy);
    }

    void ActivateArmies()
    {
        IsInitialized = true;
        LoadArmies();
        foreach (Army army in m_Armies.Values)
        {
            army.ActivateArmy(true);
        }
    }

    private void CheckArmiesAlive()
    {
        if (m_BlueArmy.IsDefeated())
        {
            m_GameManager.GameOver(ArmySide.Red);
        }
        else if (m_RedArmy.IsDefeated())
        {
            m_GameManager.GameOver(ArmySide.Blue);
        }
    }

    void SearchTargetsAndBlockers()
    {
        Cooldown += Time.deltaTime;
        if (Cooldown > m_SearchTargetInterval)
        {               
            m_BlueArmy.UpdateUnitsTargetAndBlocker(m_RedArmy.Units, m_BlueArmy.Units);
            m_RedArmy.UpdateUnitsTargetAndBlocker(m_BlueArmy.Units, m_RedArmy.Units);
            Cooldown = 0;
        }
    }

    internal void CleanUP()
    {
        foreach (Army army in m_Armies.Values)
        {
            army.CleanArmy();
        }
        ActivateArmies();
    }

    void CleanArmy (ArmySide armySide)
    {
        m_Armies[armySide].CleanArmy();
    }

    void GenerateSingleArmy(ArmySide armySide)
    {
        m_Armies[armySide].GenerateArmy(m_ArmiesSize);
    }

    internal void ReshuffleTeam(ArmySide armySide)
    {
        CleanArmy(armySide);
        GenerateSingleArmy(armySide);
    }

    public float Cooldown { get => cooldown; set => cooldown = value; }
}
