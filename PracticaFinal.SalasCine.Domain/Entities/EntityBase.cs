namespace Epm.Autogeneradores.PreRegistro.Domain.Entities
{
    public class EntityBase<T> : DomainEntity, IEntityBase<T>
    {
        public virtual T Id { get; set; }
    }
}