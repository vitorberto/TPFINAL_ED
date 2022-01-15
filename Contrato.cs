using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinalED
{
    internal class Contrato
    {
        private static int count = 0;
        private int id;
        private bool liberado = false;
        private DateTime agendamentoSaida;
        private DateTime agendamentoRetorno;
        private Stack<Equipamento> equipamentos = new Stack<Equipamento>();
        private List<RequisicaoItem> requisicoes = new List<RequisicaoItem>();

        public Contrato(DateTime agendamentoSaida, DateTime agendamentoRetorno, RequisicaoItem[] requisicoes)
        {
            Id = Count++;
            AgendamentoSaida = agendamentoSaida;
            AgendamentoRetorno = agendamentoRetorno;
            Requisicoes.AddRange(requisicoes);
        }

        public static int Count { get => count; set => count = value; }
        public int Id { get => id; set => id = value; }
        public DateTime AgendamentoSaida { get => agendamentoSaida; set => agendamentoSaida = value; }
        public DateTime AgendamentoRetorno { get => agendamentoRetorno; set => agendamentoRetorno = value; }
        public bool Liberado { get => liberado; set => liberado = value; }
        internal Stack<Equipamento> Equipamentos { get => equipamentos; set => equipamentos = value; }
        internal List<RequisicaoItem> Requisicoes { get => requisicoes; set => requisicoes = value; }

        public void addEquipamento(Equipamento equipamento)
        {
            Equipamentos.Push(equipamento);
        }
    }
}
