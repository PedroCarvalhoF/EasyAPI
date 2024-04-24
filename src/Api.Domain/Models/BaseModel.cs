namespace Api.Domain.Models
{
    public class BaseModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value == Guid.Empty ? Guid.NewGuid() : value; }
        }
        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set
            {
                _createAt = (value <= DateTime.MinValue) ? DateTime.Now : value;
            }
        }
        public bool Habilitado { get; set; }
    }
}
