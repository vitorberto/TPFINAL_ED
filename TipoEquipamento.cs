using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinalED
{
    internal class TipoEquipamento
    {
        public static int count = 0;
        private int id;
        private string nome;
        private float diaria;
        private Queue<Equipamento> equipamentos = new Queue<Equipamento>();

        public TipoEquipamento(string nome, float diaria)
        {
            this.Id = count++;
            this.Nome = nome;
            this.Diaria = diaria;
        }

        public float Diaria { get => diaria; set => diaria = value; }
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Queue<Equipamento> Equipamentos { get => equipamentos; set => equipamentos = value; }
    }
}
