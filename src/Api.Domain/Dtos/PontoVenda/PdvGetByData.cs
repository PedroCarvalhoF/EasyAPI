using Domain.ExceptionsPersonalizadas;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PontoVendaDtos
{
    public class PdvGetByData
    {
        private bool filtrar_data = false;

        public PdvGetByData(DateTime dataInicial, DateTime dataFinal)
        {
            if (dataFinal < dataInicial)
            {
                throw new ModelsExceptions("A data final não pode ser menor que a data inicial.");
            }

            filtrar_data = true;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/9999", ErrorMessage = "A data final não pode ser menor que a data inicial.")]
        public DateTime DataFinal { get; set; }
    }
}
