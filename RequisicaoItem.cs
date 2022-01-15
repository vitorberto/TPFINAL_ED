using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinalED
{
    internal class RequisicaoItem
    {
        private int tipoId;
        private int quantidade;

        public RequisicaoItem(int tipoId, int quantidade)
        {
            this.TipoId = tipoId;
            this.Quantidade = quantidade;
        }

        public int Quantidade { get => quantidade; set => quantidade = value; }
        public int TipoId { get => tipoId; set => tipoId = value; }
    }
}
