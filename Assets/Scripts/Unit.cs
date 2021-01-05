using UnityEngine;

public enum UnitSize
{
    Big,
    Small
}

public enum UnitShape
{
    Cube,
    Sphere
}

public enum UnitColor
{
    BLUE,
    YELLOW,
    GREEN,
    RED
}

public class Unit : MonoBehaviour, IUnit
{
    public GameObject m_UnitGO;
    public UnitController m_UnitController;
    public UnitView m_UnitView;
    public UnitSize m_Size;
    public UnitShape m_Shape;
    public UnitColor m_Color;

    private float m_ATK;
    private float m_HP;
    private float m_SPEED;
    private float m_ATKSPD;
    private float atkCooldown = 0f;
    private float atkRange = 0f;

    public void Init(UnitSize size, UnitShape shape, UnitColor color)
    {
        m_UnitGO = gameObject;
        m_Size = size;
        m_Shape = shape;
        m_Color = color;
    }

    public bool IsDead()
    {
        return HP < 0;
    }

    public void GetHit(float dmg)
    {
        HP -= dmg;
    }

    public float ATK { get => m_ATK; set => m_ATK = value; }
    public float HP { get => m_HP; set => m_HP = value; }
    public float SPEED { get => m_SPEED; set => m_SPEED = value; }
    public float ATKSPD { get => m_ATKSPD; set => m_ATKSPD = value; }
    public float AtkTimer { get => atkCooldown; set => atkCooldown = value; }
    public float AtkRange { get => atkRange; set => atkRange = value; }
}
