using System;
using Dominio;
using System.Collections.Generic;

namespace BomDiaBrasil.Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Comentario c = new Comentario();
            c.Id = 1;
            List<Profissao> p = new List<Profissao>();
            p.Add(new Profissao
            {
                Id = 1,
                Descricao = "Reporter"
            });
            Empregado e = new Empregado(1, "Márcio", "Abrantes", p);
            Console.WriteLine("Nome do reporter: " + e.NomeCompleto);
            Console.WriteLine("Idade: " + e.Idade != null ? "não existe idade" : e.Idade.Value.ToString("dd/MM/yy"));
            Console.WriteLine("Cpf: " + e.Cpf);

            Console.WriteLine("Descricao da Profissao: " + e.Profissao[0].Descricao);
            Console.ReadKey();

        }
    }
}
