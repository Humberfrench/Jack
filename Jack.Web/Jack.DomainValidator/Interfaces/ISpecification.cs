﻿namespace Jack.DomainValidator.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entidade);
    }
}
