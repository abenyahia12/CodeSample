using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{

    [SerializeField] GameObject m_UnitPrefab;
    [SerializeField] StatsModifier m_StatsSO;
    [SerializeField] Material[] m_materials;
    [SerializeField] Mesh[] m_meshes;
    [SerializeField] float[] m_scales = { 1, 2 };

    public Unit Create()
    {
        GameObject unitGO = Instantiate(UnitPrefab);
        Unit u = unitGO.GetComponent<Unit>();
        //randomizing unit configuration
        int randomSize=UnityEngine.Random.Range(0, Enum.GetValues(typeof(UnitSize)).Length);
        int randomShape = UnityEngine.Random.Range(0, Enum.GetValues(typeof(UnitShape)).Length); 
        int randomColor = UnityEngine.Random.Range(0, Enum.GetValues(typeof(UnitColor)).Length); 
        u.Init((UnitSize)randomSize, (UnitShape)randomShape, (UnitColor)randomColor);
        ConfigureUnit(u);
        return u;
    }

    private void ConfigureUnit(Unit unit)
    {
        SetUnitView(unit, unit.m_UnitView);
        SetUnitStats(unit);
    }

    private void SetUnitStats(Unit unit)
    {
        //First Get the basic charecteristics
        unit.ATK = StatsSO.m_BasicAtkDmg;
        unit.HP = StatsSO.m_BasicHP;
        unit.AtkRange = StatsSO.m_BasicAtkRange;
        
        ApplySizeModifier(unit);
        ApplyShapeModifier(unit);
        ApplyColorModifier(unit);

        //After changing HP and Attack we can now interpolate and calculate speed and atk speed
        float currentHP = unit.HP;
        float currentATK = unit.ATK;
        float minHpRange = StatsSO.minHPADD + StatsSO.m_BasicHP;
        float maxHpRange = StatsSO.maxHPADD + StatsSO.m_BasicHP;
        float minSpeedRange = StatsSO.m_MinSpeedInterpolationValue;
        float maxSpeedRange = StatsSO.m_MAXSpeedInterpolationValue;
        float minATKRange = StatsSO.minATKADD + StatsSO.m_BasicAtkDmg;
        float maxATKRange = StatsSO.maxATKADD + StatsSO.m_BasicAtkDmg;
        float minATKSPDRange = StatsSO.m_MinATKSPDInterpolationValue;
        float maxATKSPDRange = StatsSO.m_MAXATKSPDInterpolationValue;
        unit.SPEED = MathUtils.Interpolate(currentHP, minHpRange, maxHpRange, minSpeedRange, maxSpeedRange);
        unit.ATKSPD = MathUtils.Interpolate(currentATK, minATKRange, maxATKRange, minATKSPDRange, maxATKSPDRange);
    }

    private void SetUnitView(Unit sunit, UnitView unitView)
    {
        unitView.Set(Meshes[(int)sunit.m_Shape], Materials[(int)sunit.m_Color], Scales[(int)sunit.m_Size]);
    }

    void ApplySizeModifier(Unit unit)
    {
        ApplyModifier(StatsSO.m_SizeCharacteristic.Modifier[(int)unit.m_Size], unit);
    }

    void ApplyShapeModifier(Unit unit)
    {
        ApplyModifier(StatsSO.m_ShapeCharacteristic.Modifier1[(int)unit.m_Shape], unit);
        ApplyModifier(StatsSO.m_ShapeCharacteristic.Modifier2[(int)unit.m_Shape], unit);
    }

    void ApplyColorModifier(Unit unit)
    {
        //access directly the right modifier by checking the (int)unit.m_Shape for rows and (int)unit.m_Color for columns
        ApplyModifier(StatsSO.m_ColorCharacteristic.ModifierArray[(int)unit.m_Shape].Modifier[(int)unit.m_Color], unit);
    }

    void ApplyModifier(Modifier modifier, Unit unit)
    {
        if (modifier.type== ModifierType.HP)
        {
            unit.HP += modifier.modifierValue;
        }
        else if (modifier.type == ModifierType.ATK)
        {
            unit.ATK += modifier.modifierValue;
        }
        //possibility to add more modifiers here
    }

    public float[] Scales { get => m_scales; set => m_scales = value; }
    public Mesh[] Meshes { get => m_meshes; set => m_meshes = value; }
    public Material[] Materials { get => m_materials; set => m_materials = value; }
    public StatsModifier StatsSO { get => m_StatsSO; set => m_StatsSO = value; }
    public GameObject UnitPrefab { get => m_UnitPrefab; set => m_UnitPrefab = value; }
}
