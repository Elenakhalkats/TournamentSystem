namespace TournamentSystem.Application.Primitive;

[Serializable]
public abstract class Entity<TId>
{
    public virtual TId Id { get; set; }
}
