public abstract class Building : Entity
{
    public override void EntityDeath()
    {
        Destroy(gameObject);
    }
}
