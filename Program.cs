using System;

namespace AtividadeFinalED
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estoque estoque = new Estoque();
            // criando tipos de equipamentos
            for (int i = 0; i < 5; i++)
            {
                string nome = "tipo" + i;
                float diaria = (float)((float)i + 0.5 * i);
                estoque.CadastrarTipoEquipamento(nome, diaria);
            }

            // cadastrando equipamentos
            foreach (TipoEquipamento tipo in estoque.Tipos)
            {
                for(int j = 0; j < 5; j++)
                {
                    estoque.CadastrarEquipamento(false, tipo);
                }
            }

            estoque.ConsultarTipoEquipamento(1);
            
            DateTime agendamentoSaida = DateTime.Now;
            DateTime agendamentoRetorno = DateTime.Now.AddDays(1);
            RequisicaoItem[] requisicoes = new RequisicaoItem[2];
            requisicoes[0] = new RequisicaoItem(2, 4);
            requisicoes[1] = new RequisicaoItem(4, 1);

            estoque.RegistrarContrato(agendamentoSaida, agendamentoRetorno, requisicoes);

            estoque.ConsultarContratos();

            estoque.LiberarContrato(0);

            estoque.ConsultarContratosLiberados();

            estoque.DevolverEquipamentosContrato(0);

            estoque.ConsultarContratosLiberados();

            estoque.ConsultarContratos();
        }
    }
}
