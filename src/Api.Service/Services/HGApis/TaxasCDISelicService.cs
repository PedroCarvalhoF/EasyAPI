using Domain.Dtos;
using Domain.Dtos.Cotacoes.TaxasCDISELIC;
using Domain.Interfaces.Services.HGApis;
using System.Diagnostics;
using System.Text.Json;

namespace Service.Services.HGApis
{
    public class TaxasCDISelicService : ITaxasCDISelicService
    {
        const string key = "0548395c";

        public async Task<ResponseDto<List<TaxasDtosHGBrasil>>> GetTaxas()
        {
            try
            {
                Stopwatch tempo = Stopwatch.StartNew();
                var _options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string url = $"https://api.hgbrasil.com/finance/taxes?key={key}";

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var dto = JsonSerializer.Deserialize<TaxasDtosHGBrasil>(result, _options);

                        tempo.Stop();

                        var responseDto = new ResponseDto<List<TaxasDtosHGBrasil>>().Retorno(new List<TaxasDtosHGBrasil>() { dto });

                        responseDto.Mensagem = $"Tempo de comunicação com HGApis: {tempo.ElapsedMilliseconds} milisegundos";
                        return responseDto;
                    }
                    else
                    {
                        return new ResponseDto<List<TaxasDtosHGBrasil>>().Erro("Não foi possivel consultar as taxas");
                    }
                }
            }
            catch (JsonException jsonEx)
            {
                // Log the error or handle it accordingly
                return new ResponseDto<List<TaxasDtosHGBrasil>>().Erro($"Erro ao desserializar o JSON: {jsonEx.Message}");
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<TaxasDtosHGBrasil>>().Erro(ex);
            }
        }
    }
}
