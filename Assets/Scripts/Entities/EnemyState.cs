using UnityEngine;

public abstract class EnemyState
{
    protected Enemy enemy;
    protected MobData mob;
    protected Transform player;
    protected EnemyState(Enemy enemy, MobData mob, Transform player)
    {
        this.enemy = enemy;
        this.mob = mob;
        this.player = player;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
