namespace Domain.Dtos
{
    public class RequestResult
    {
        public bool Status { get; set; }
        public int StatusCode { get; private set; }
        public string? Message { get; private set; }
        public DtoUserClaims? DtoUserClaims { get; private set; }
        public object? Data { get; private set; }

        public RequestResult Ok(object? data = null)
        {
            this.Status = true;
            this.StatusCode = 200;
            this.Message = "Requisição realizada com sucesso.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResult BadRequest(string detalhes, object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Message = $"Falha ao realizar a requisição. Detalhes: {detalhes}.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResult BadCreate(object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Message = $"Falha ao realizar a requisição. Não foi possível realizar o cadastro.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResult IsNullOrCountZero()
        {
            this.Status = false;
            this.StatusCode = 200;
            this.Message = $"Nenhum resultado encontrado.";
            this.Data = new List<string>();
            return this;
        }
        public void SetUsersDetails(DtoUserClaims dto)
        {
            this.DtoUserClaims = new DtoUserClaims(dto.UserMasterId, dto.UserId, dto.UserName);
        }

        public RequestResult EntidadeInvalida(object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Message = $"Falha ao realizar a requisição. Detalhes: Entidade não foi validada.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResult BadUpdate(object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Message = $"Falha ao realizar a requisição. Não foi possível realizar alteração.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }
    }
}