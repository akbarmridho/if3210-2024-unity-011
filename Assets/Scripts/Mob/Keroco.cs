using UnityEngine;

public class Keroco : Mob
{
    protected override string AttackAnimationMovement => "AttackMovement";

    protected override int MaxHealth => 50;
    protected override int InitialHealth => 50;
    
    protected override int AttackDamage => 10;

    protected override float TimeBetweenAttack => 0.5f;

    protected override void OnDamaged(int prevHealth, int currentHealth)
    {
        // todo
    }

    protected override void OnDeath()
    {
        //
    }


    void Update()
    {
        base.Update();
    }
}