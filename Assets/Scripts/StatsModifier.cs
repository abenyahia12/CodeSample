using System;
using UnityEngine;

public enum ModifierType
{
    HP,
    ATK
}

[Serializable]
public struct Modifier
{
    public ModifierType type;    //if we add HP , check it, if we add attack uncheck it
    public float modifierValue;     //if we remove , make the value negative , if we add, make it positive
}

[CreateAssetMenu(menuName = "My Assets/StatsModifier")]
[Serializable]
public class StatsModifier : ScriptableObject
{
    public UnitSizeCharacteristic m_SizeCharacteristic;
    public UnitShapeCharacteristic m_ShapeCharacteristic;
    public UnitColorCharacteristic m_ColorCharacteristic;
    [Space]
    public float m_BasicAtkDmg;
    public float m_BasicHP;
    public float m_BasicAtkRange;
    public float m_MinSpeedInterpolationValue;
    public float m_MAXSpeedInterpolationValue;
    public float m_MinATKSPDInterpolationValue;
    public float m_MAXATKSPDInterpolationValue;
    public float minHPADD = 0f;
    public float maxHPADD = 0f;
    public float minATKADD = 0f;
    public float maxATKADD = 0f;

    [Serializable]
    public struct UnitShapeCharacteristic
    {
        public Modifier[] Modifier1;
        public Modifier[] Modifier2;
    }

    [Serializable]
    public struct UnitSizeCharacteristic
    {
        public Modifier[] Modifier;
    }

    [Serializable]
    public struct UnitColorCharacteristic
    {
        public ModifierArray[] ModifierArray;
    }

    [Serializable]
    public struct ModifierArray
    {
        public Modifier[] Modifier;
    }

}
