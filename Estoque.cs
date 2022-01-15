using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinalED
{
    // eu vou usar o Estoque como um "controller" geral, ele vai administrar os contratos, equipamentos e seus tipos
    internal class Estoque
    {
        private List<Contrato> contratos;
        private List<TipoEquipamento> tipos;

        public Estoque()
        {
            this.Contratos = new List<Contrato>();
            this.Tipos = new List<TipoEquipamento>();
        }

        internal List<Contrato> Contratos { get => contratos; set => contratos = value; }
        internal List<TipoEquipamento> Tipos { get => tipos; set => tipos = value; }
        public void CadastrarTipoEquipamento(string nome, float diaria)
        {
            TipoEquipamento tipoEquipamento = new TipoEquipamento(nome, diaria);
            tipos.Add(tipoEquipamento);
        }

        public void ConsultarTipoEquipamento(int id)
        {
            TipoEquipamento tipo = tipos.Find(x => x.Id == id);

            Console.WriteLine($"Tipo de equipamento: {tipo.Nome}");
            Console.WriteLine("Equipamentos desse tipo: ");
            foreach (Equipamento equipamento in tipo.Equipamentos)
            {
                Console.WriteLine($"id: {equipamento.Id}");
                Console.WriteLine($"avariado: {equipamento.Avariado}");
            }
        }

        public void CadastrarEquipamento(bool avariado, TipoEquipamento tipo)
        {
            tipo.Equipamentos.Enqueue(new Equipamento(avariado, tipo));
        }

        public void RegistrarContrato(DateTime agendamentoSaida, DateTime agendamentoRetorno, RequisicaoItem[] requisicoes)
        {
            Contratos.Add(new Contrato(agendamentoSaida, agendamentoRetorno, requisicoes));
        }

        public void ConsultarContratos()
        {
            List<Contrato> contratosNaoLiberados = Contratos.FindAll(x => x.Liberado == false);

            Console.WriteLine("Contratos:");
            Console.WriteLine("====================");
            foreach (Contrato contrato in contratosNaoLiberados)
            {
                Console.WriteLine($"id: {contrato.Id}");
                Console.WriteLine($"Agendamento saida: {contrato.AgendamentoSaida}");
                Console.WriteLine($"Agendamento retorno: {contrato.AgendamentoRetorno}");
                Console.WriteLine("\nEquipamentos requisitados:\n");

                foreach (RequisicaoItem requisicao in contrato.Requisicoes)
                {
                    Console.WriteLine($"tipo equipamento: {tipos.Find(x => x.Id == requisicao.TipoId).Nome}");
                    Console.WriteLine($"quantidade requisitada: {requisicao.Quantidade}\n");
                }

                Console.WriteLine("====================");
            }
        }

        public void LiberarContrato(int id)
        {
            Contrato contrato = Contratos.Find(x => x.Id == id);
            foreach (RequisicaoItem req in contrato.Requisicoes)
            {
                TipoEquipamento tipo = tipos.Find(x => x.Id == req.TipoId);
                for (int i = 0; i < req.Quantidade; i++)
                {
                    Equipamento equipamento = null;
                    do
                    {
                        if (equipamento != null)
                            tipo.Equipamentos.Enqueue(equipamento);

                        equipamento = tipo.Equipamentos.Dequeue();
                    } while (equipamento.Avariado);

                    contrato.addEquipamento(equipamento);
                }
            }

            contrato.Liberado = true;
        }

        public void ConsultarContratosLiberados()
        {
            List<Contrato> contratosLiberados = Contratos.FindAll(x => x.Liberado == true);

            Console.WriteLine("Contratos liberados:");
            Console.WriteLine("====================");
            foreach (Contrato contrato in contratosLiberados)
            {
                Console.WriteLine($"id: {contrato.Id}");
                Console.WriteLine($"Agendamento saida: {contrato.AgendamentoSaida}");
                Console.WriteLine($"Agendamento retorno: {contrato.AgendamentoRetorno}");
                Console.WriteLine("\nEquipamentos contratados:\n");

                foreach (Equipamento equipamento in contrato.Equipamentos)
                {
                    Console.WriteLine($"id equipamento: {equipamento.Id}");
                    Console.WriteLine($"tipo equipamento: {equipamento.Tipo.Nome}\n");
                }

                Console.WriteLine("====================");
            }
        }

        public void DevolverEquipamentosContrato(int idContrato)
        {
            double valorPagar = 0;
            List<Equipamento> equipamentos = new List<Equipamento>();
            Contrato contrato = Contratos.Find(x => x.Id == idContrato);
            while(contrato.Equipamentos.Count > 0)
            {
                equipamentos.Add(contrato.Equipamentos.Pop());
            }

            foreach(Equipamento equipamento in equipamentos)
            {
                TipoEquipamento tipo = this.tipos.Find(tipos => tipos.Id == equipamento.Tipo.Id);
                tipo.Equipamentos.Enqueue(equipamento);
                valorPagar += tipo.Diaria * Math.Floor((contrato.AgendamentoRetorno.Subtract(contrato.AgendamentoSaida).TotalDays));
            }

            Console.WriteLine("Equipamentos devolvidos com sucesso!");
            Console.WriteLine("Total a pagar: R$" + valorPagar);

            Contratos.Remove(contrato);
        }
    }
}
