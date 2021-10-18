namespace Epm.Autogeneradores.PreRegistro.Domain.Entities
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}