using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyChaseState : EnemyState
{
    public Vector2 k;
    public Rigidbody2D rb;
    public EnemyChaseState(Enemy enemy, MobData mob, UnityEngine.Transform player) : base(enemy, mob, player)
    {
    }
    public override void Enter()
    {
        Debug.Log($"{mob.mobName} has entered Chase State.");
        rb = enemy.GetComponent<Rigidbody2D>();
    }
    public override void Update()
    {
        if (!enemy.CanSeePlayer())
        {
            enemy.ChangeState(new EnemyIdleState(enemy, mob, player));
        }
        float direction = player.position.x - enemy.transform.position.x;
        direction = Mathf.Sign(direction);
        Flip(direction);
        float moveX = direction * mob.speed;
        if(enemy.HasObstacle(direction) && enemy.IsGrounded())
        {
            enemy.rb.linearVelocity = new Vector2(0, enemy.rb.linearVelocity.y);
            if (!enemy.CeilingAbove())
            {
                float obstacleHeight = enemy.GetObstacleHeight(direction);
                if (obstacleHeight <= mob.jumpPower)
                {
                        enemy.rb.linearVelocity = new Vector2(enemy.rb.linearVelocity.x, mob.jumpPower);
                }
                else
                {

                }
            }
        }
        enemy.rb.linearVelocity = new Vector2(mob.speed * direction, enemy.rb.linearVelocity.y);
    }
    public void Flip(float dir)
    {
        if (dir > 0) enemy.transform.localScale = new Vector3(1, 1, 1);
        else if (dir < 0) enemy.transform.localScale = new Vector3(-1, 1, 1);
    }
}
