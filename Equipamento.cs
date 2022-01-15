using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinalED
{
    internal class Equipamento
    {
        private static int count = 0;
        private int id;
        private bool avariado;
        private TipoEquipamento tipo;

        public Equipamento(bool avariado, TipoEquipamento tipo)
        {
            Id = count++;
            Avariado = avariado;
            Tipo = tipo;
        }

        public static int Count { get => count; set => count = value; }
        public int Id { get => id; set => id = value; }
        public bool Avariado { get => avariado; set => avariado = value; }
        internal TipoEquipamento Tipo { get => tipo; set => tipo = value; }
    }
}
