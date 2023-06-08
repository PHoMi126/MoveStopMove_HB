public class EnemyController : CharacterController
{
    public override void Dead()
    {
        base.Dead();
        Destroy(gameObject);
    }
}