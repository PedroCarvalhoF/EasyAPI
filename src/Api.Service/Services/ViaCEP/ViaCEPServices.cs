using Domain.Dtos;
using Domain.Dtos.ViaCEP;
using Domain.Interfaces.Services.ViaCEP;
using System.Text.Json;

namespace Service.Services.ViaCEP
{
    public class ViaCEPServices : IViaCepService
    {
        public async Task<ResponseDto<List<ViaCEPDto>>> BuscarCEP(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Throw if not a success code.

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var endereco = JsonSerializer.Deserialize<ViaCEPDto>(responseBody, options);

                    return new ResponseDto<List<ViaCEPDto>>().Retorno(new List<ViaCEPDto> { endereco });
                }
                catch (HttpRequestException ex)
                {
                    return new ResponseDto<List<ViaCEPDto>>().Erro(ex);
                }
                catch (Exception ex)
                {
                    return new ResponseDto<List<ViaCEPDto>>().Erro(ex);
                }

            }
        }
    }
}
