﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasReclame.Helpers
{
    public static class PreencheDados
    {
        public static List<string> Categorias ()
        {
            List<string> categorias = new List<string>()
            {
                "Acessibilidade", "Água e esgoto", "Alagamento", "Árvore", "Bem público", "Buraco", "Ciclovia", "Comércio", "Educação", "Energia", "Iluminação", "Lixo", "Mato", "Obra", "Pedestre", "Pichação", "Poluição do ar", "Poluição sonora", "Poluição visual", "Queimada", "Saúde", "Segurança", "Social", "Transporte", "Trânsito"
            };

            return categorias;
        }

        public static List<string> Bairros ()
        {
            List<string> bairros = new List<string>()
            {
                "Aberta dos Morros", "Agronomia", "Anchieta", "Arquipélago", "Auxiliadora", "Azenha", "Bela Vista", "Belém Novo", "Belém Velho", "Boa Vista", "Bom Fim", "Bom Jesus", "Camaquã", "Campo Novo", "Cascata", "Cavalhada", "Cel. Aparício Borges", "Centro Histórico", "Chácara das Pedras", "Chapéu do Sol", "Cidade Baixa", "Costa e Silva", "Cristal", "Cristo Redentor", "Espírito Santo", "Extrema", "Farrapos", "Farroupilha", "Floresta", "Glória", "Guarujá", "Higienópolis", "Hípica", "Humaitá", "Independência", "Ipanema", "Jardim Botânico", "Jardim Carvalho", "Jardim Do Salso", "Jardim Floresta", "Jardim Isabel", "Jardim Itu-Sabará", "Jardim Leopoldina", "Jardim Lindóia", "Jardim São Pedro", "Lageado", "Lami", "Lomba do Pinheiro", "Mário Quintana", "Medianeira", "Menino Deus", "Moinhos De Vento", "Mont' Serrat", "Morro Santana", "Navegantes", "Nonoai", "Parque Santa Fé", "Partenon", "Passo Da Areia", "Passo Das Pedras", "Pedra Redonda", "Petrópolis", "Pitinga", "Ponta Grossa", "Praia De Belas", "Restinga", "Rio Branco", "Rubem Berta", "Santa Cecília", "Santa Maria Goretti", "Santa Rosa De Lima", "Santa Tereza", "Santana", "Santo Antônio", "São Caetano", "São Geraldo", "São João", "São Sebastião", "Sarandi", "Serraria", "Sétimo Céu", "Teresópolis", "Três Figueiras", "Tristeza", "Vila Assunção", "Vila Conceição", "Vila Ipiranga", "Vila Jardim", "Vila João Pessoa", "Vila Nova", "Vila São José"
            };

            return bairros;
        }

    }
}
 