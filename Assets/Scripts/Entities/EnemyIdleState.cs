using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, MobData mob, Transform player) : base(enemy, mob, player)
    {
    }
    public override void Enter()
    {
       Debug.Log($"{mob.mobName} has entered Idle State.");
    }
    public override void Update()
    {
        if(enemy.CanSeePlayer())
        {
            enemy.ChangeState(new EnemyChaseState(enemy, mob, player));
        }
    }
    public override void Exit()
    {
        // Cleanup logic when exiting idle state can be added here
    }
}
