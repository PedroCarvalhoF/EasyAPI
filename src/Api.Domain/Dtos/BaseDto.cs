namespace Api.Domain.Dtos
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        //public DateTime CreateAt { get; set; }
        //public DateTime UpdateAt { get; set; }
        public bool Habilitado { get; set; }
    }
}
