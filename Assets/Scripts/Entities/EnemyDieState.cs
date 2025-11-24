using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(Enemy enemy) : base(enemy, null, null)
    {
    }
    public override void Enter()
    {
        Debug.Log($"{enemy.name} has entered Die State.");
        enemy.SendMessage("Die");
        enemy.Die();
    }
    public override void Update()
    {
      
    }
    public override void Exit()
    {
       
    }
}
