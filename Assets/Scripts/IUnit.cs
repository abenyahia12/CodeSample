public interface IUnit
{
    float ATK { get; set; }
    float AtkTimer { get; set; }
    float AtkRange { get; set; }
    float ATKSPD { get; set; }
    float HP { get; set; }
    float SPEED { get; set; }

    void GetHit(float dmg);

    void Init(UnitSize size, UnitShape shape, UnitColor color);

    bool IsDead();
}