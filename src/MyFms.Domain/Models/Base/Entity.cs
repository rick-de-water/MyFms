namespace MyFms.Domain.Models;

public abstract class Entity<TDerived>
	where TDerived : Entity<TDerived>
{
	public Id<TDerived> Id { get; set; }
}