namespace PracticaFinal.SalasCine.Domain.Entities
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}