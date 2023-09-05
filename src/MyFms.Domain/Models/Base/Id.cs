﻿namespace MyFms.Domain.Models;

public record struct Id<TEntity>(long Value) : IComparable<Id<TEntity>>, IComparable
	where TEntity : Entity<TEntity>
{
	public int CompareTo(Id<TEntity> other) => Value.CompareTo(other.Value);

	public int CompareTo(object? obj)
	{
		if (obj is Id<TEntity> other)
		{
			return CompareTo(other);
		}

		return 1;
	}

	public override string ToString() => Value.ToString();
}