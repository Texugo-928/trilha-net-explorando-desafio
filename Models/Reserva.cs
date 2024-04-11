namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null || Suite.Capacidade == null)
            {
                throw new Exception("ERRO: A suite não foi previamente instanciada");
            }
            else
            {
                bool validadorCapacidade = (Suite.Capacidade >= hospedes.Length);

                if (validadorCapacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    throw new Exception("ERRO: A capacidade da suite é menor que o número de hóspedes");
                }
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;

            valor = DiasReservados * Suite.ValorDiaria;

            bool validadorDiasReservas = (DiasReservados >= 10);

            if (validadorDiasReservas)
            {
                valor *= 0.9;
            }

            return valor;
        }
    }
}
