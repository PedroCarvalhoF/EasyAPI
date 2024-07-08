using Easy.Services.DTOs.UserClaims;

namespace Easy.Services.DTOs
{
    public class RequestResultForUpdate
    {
        public bool Status { get; set; }
        public int StatusCode { get; private set; }
        public string? Mensagem { get; private set; }
        public DtoUserClaims? DtoUserClaims { get; private set; }
        public object? Data { get; private set; }

        public RequestResultForUpdate Ok(object? data = null)
        {
            this.Status = true;
            this.StatusCode = 200;
            this.Mensagem = "Requisição realizada com sucesso.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResultForUpdate Ok(string? detalhes, object? data = null)
        {
            this.Status = true;
            this.StatusCode = 200;
            this.Mensagem = $"Requisição realizada com sucesso.{detalhes}";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResultForUpdate BadRequest(object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Mensagem = $"Falha ao realizar a requisição.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

        public RequestResultForUpdate BadRequest(string detalhes, object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Mensagem = $"Falha ao realizar a requisição. Detalhes: {detalhes}.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }


        public RequestResultForUpdate IsNullOrCountZero()
        {
            this.Status = false;
            this.StatusCode = 200;
            this.Mensagem = $"Nenhum resultado encontrado.";
            this.Data = new List<string>();
            return this;
        }
        public void SetUsersDetails(DtoUserClaims dto)
        {
            this.DtoUserClaims = new DtoUserClaims(dto.UserMasterId, dto.UserId, dto.UserName);
        }

        public RequestResultForUpdate EntidadeInvalida(object? data = null)
        {
            this.Status = false;
            this.StatusCode = 400;
            this.Mensagem = $"Falha ao realizar a requisição. Detalhes: Entidade não foi validada.";
            if (data == null)
                this.Data = new List<string>();
            else
                this.Data = data;
            return this;
        }

    }
}