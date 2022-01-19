using System;


namespace AulaDotNet
{
    class Program
    {
        static void Main (String[] args)
        {   
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoDoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        System.Console.WriteLine("Informe nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome= Console.ReadLine();

                        System.Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno ++;            

                        break;

                    case "2":
                        foreach ( var al in alunos)
                        {
                            if (!string.IsNullOrEmpty(al.Nome))
                            System.Console.WriteLine($"ALUNO: {al.Nome} - NOTA: {al.Nota}");
                        }

                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos ++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                         else if(mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                         else if(mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                         else
                         {
                             conceitoGeral = Conceito.A;
                         }
                        System.Console.WriteLine($"Média Geral: {mediaGeral} - CONCEITO: {conceitoGeral}");


                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

               
                opcaoUsuario = ObterOpcaoDoUsuario();
            }
        }

        private static string ObterOpcaoDoUsuario()
        {   
            System.Console.WriteLine();
            System.Console.WriteLine("Informe a opção desejada");
            System.Console.WriteLine("1 - Inserir novo aluno");
            System.Console.WriteLine("2 - Listar alunos");
            System.Console.WriteLine("3 - Calcular a média geral");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}