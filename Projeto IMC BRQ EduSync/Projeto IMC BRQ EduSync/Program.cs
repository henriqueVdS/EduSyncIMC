using System;
using System.Threading;
using System.Globalization;

namespace Projeto_IMC_BRQ_EduSync
{
    internal class Program
    {
        static void Main(string[] args)
        {//declarando as váriaveis

            string nome = string.Empty;
            string sexo = string.Empty;
            string categoria = string.Empty;
            string classificacao = string.Empty;
            string riscos = string.Empty;
            string recomendacaoInicial = string.Empty;
            string tentativa = string.Empty;
            string enter = string.Empty;
            double altura;
            double peso;
            double imc;
            int idade;


            #region BOAS VINDAS DO SISTEMA
            // Dando boas vindas e apresentando o nome fictio "BRSync"
            //Após isso, orientar os comandos S ou N para iniciar a consulta de dados do usuario
            Console.WriteLine("\nSeja bem vindo(a) ao sistema de IMC da BRSync!");
            Console.WriteLine("\nVamos iniciar? pressione (S) para continuar ou (N) caso deseje sair. \n");
            string continuar = Console.ReadLine();


            //validando se o usuario realmente opinou entre as teclas que orientamos e se ele deseja continuar
            while (continuar.ToUpper() != "S" && continuar.ToUpper() != "N")
            {
                Console.Write($"Ops.. ({continuar}) não é uma opção válida. Pressione (S) para continuar ou (N) caso deseje sair. \n");
                continuar = Console.ReadLine();
            }
            if (continuar.ToUpper() == "N")
                Environment.Exit(0);

            //limpamos a tela para melhor qualidade visual e iniciamos as perguntas
            Console.Clear();
            Console.WriteLine("Otimo! vou precisar de alguns dados seus... \n");
            #endregion BOAS VINDAS DO SISTEMA

            #region METODOS OBTER INFORMACOES

            // solicita nome ao usuario e faz validação dos dados
            nome = ObterNome();

            // solicita sexo ao usuario e faz validação dos dados
            sexo = ObterSexo();

            // solicita idade ao usuario e faz validação dos dados
            idade = ObterIdade();

            // solicita altura ao usuario e faz validação dos dados
            altura = ObterAltura();

            // solicita peso ao usuario e faz validação dos dados
            peso = ObterPeso();
            #endregion

            //INFORMAÇÕES IMPORTANTES:
            #region CÁLCULO IMC
            //faz o calculo do IMC  e remove casas decimais
            imc = Math.Round(peso / Math.Pow(altura, 2), 0);
            #endregion

            #region CATEGORIA
            //Identifica em qual categoria se localiza o usuario através da sua idade
            if (idade < 12)
                categoria = "Infantil";

            else if (idade >= 12 && idade <= 20)
                categoria = "Juvenil";

            else if (idade >= 21 && idade <= 65)
                categoria = "Adulto";
            else
                categoria = "Idoso";
            #endregion CATEGORIA

            #region CLASSIFICACAO IMC
            //Classifica em que condição em relação ao seu IMC se encontra o usuario
            if (imc < 20)
                classificacao = "Abaixo do Peso Ideal";

            else if (imc >= 20 && imc <= 24)
                classificacao = "Peso Normal";

            else if (imc >= 25 && imc <= 29)
                classificacao = "Excesso de Peso";

            else if (imc >= 30 && imc <= 35)
                classificacao = "Obesidade";

            else
                classificacao = "Super Obesidade";
            #endregion CLASSIFICACAO

            #region RISCOS
            //Salvando um texto dentro de uma var para apresentar ao usuario o texto adequado aos riscos causados pelo IMC dele.
            if (imc < 20)
                riscos = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.";

            else if (imc >= 20 && imc <= 24)
                riscos = "Seu peso está ideal para suas referências.";

            else if (imc >= 25 && imc <= 29)
                riscos = "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";

            else if (imc >= 30 && imc <= 35)
                riscos = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";

            else
                riscos = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
            #endregion

            #region RECOMENDACAO INICIAL
            //Salvando um texto dentro de uma var para apresentar ao usuario o texto adequado para as recomendações médicas de acordo com o IMC dele.
            if (imc < 20)
                recomendacaoInicial = "Inclua carboidratos simples em sua dieta, além de proteínas indispensáveis para ganho de massa magra. Procure um profissional.";

            else if (imc >= 20 && imc <= 24)
                recomendacaoInicial = "Mantenha uma dieta saudável e faça seus exames periódicos.";

            else if (imc >= 25 && imc <= 29)
                recomendacaoInicial = "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante.";

            else if (imc >= 30 && imc <= 35)
                recomendacaoInicial = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista(endócrino).";

            else
                recomendacaoInicial = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista(endócrino).";
            #endregion RECOMENDACAO

            #region IMPRIMIR DIAGNOSTICO

            //primeiramente limpo a tela para imprimir somente os resultados do diagnostico
            Console.Clear();
            //imprimo dando tab para centralizar o texto
            Console.WriteLine("\n\t\t DIAGNÓSTICO PRÉVIO\n\n ");

            //Concateno strings com os valores obtidos anteriormente e salvos nas variaveis e presento ao usuario via Console.WriteLine
            //Em alguns casos uso o Math.Round para realização do arredondamento do numero para um resultado mais preciso
            //utilizo também \n para pular linha
            Console.WriteLine($" Nome:      {nome}\n " +
                              $"Sexo:      {sexo}\n " +
                              $"Idade:     {idade}\n " +
                              $"Altura:    {Math.Round(altura, 2)} m \n " +
                              $"Peso:      {Math.Round(peso, 2)} Kg \n " +
                              $"Categoria: {categoria}\n\n " +
                              $"IMC Ideal:  entre 20 a 24\n\n " +
                              $"Resultado IMC:  {imc}\n\n " +
                              $"Classificação IMC:  {classificacao}\n\n " +
                              $"Riscos:  {riscos}\n\n " +
                              $"Recomendação Inicial: {recomendacaoInicial}\n\n\n ");
            Console.ReadKey();
            #endregion IMPRIMIR DIAGNOSTICO
        }

        static double ObterAltura()
        {
            // solicita altura ao usuario e faz validação dos dados

            //crio um booleano para ser usado no TryParse e verificiar se a conversão de string para Double funciona.
            bool converteu = false;
            //var para salvar altura convertida e limpo a tela para aparição de futura nova pergunta
            double altura = 0;
            Console.Clear();
            //Pedindo altura do usuario e o orientando quanto a virgula
            //obtendo altura e substituindo espaço e ponto por virgula
            //Tentando converter para double
            Console.Write("\nMe diga sua altura em metros utilizando virgula(,) para separar as medidas. Exemplo (1,70): ");
            string respostaDaAltura = Console.ReadLine().Replace(".", ",").Replace(" ", ",");
            converteu = Double.TryParse(respostaDaAltura, out altura);

            //validando se converteu e se altura é valida
            //Caso não, solicita novamente no while
            while (!converteu || altura <= 0)
            {
                Console.Write("Essa altura é invalida! tente novamente utilizando a virgula (,) para separar as medidas. Exemplo (1,70): ");
                respostaDaAltura = Console.ReadLine().Replace(".", ",").Replace(" ", ",");
                converteu = Double.TryParse(respostaDaAltura, out altura);
            }

            return altura;
        }

        static int ObterIdade()
        {
            // solicita idade ao usuario e faz validação dos dados

            //crio um booleano para ser usado no TryParse e verificiar se a conversão de string para int funciona.
            bool converteu = false;
            //var para salvar idade convertida e limpo a tela para aparição de futura nova pergunta
            int idade = 0;
            Console.Clear();
            //**Pega idade e tenta converter para int
            Console.Write("\nQuantos anos você tem?: ");
            string respostaDaIdade = Console.ReadLine();
            converteu = Int32.TryParse(respostaDaIdade, out idade);

            //Verifica se converteu para int e idade é valida
            //Caso não seja informa o usuário e tenta novamente
            while (!converteu || (idade <= 0 || idade > 150))
            {
                Console.Write("Idade inválida! Por favor, tente novamente: ");
                respostaDaIdade = Console.ReadLine();
                converteu = Int32.TryParse(respostaDaIdade, out idade);
            }

            return idade;
        }

        static string ObterSexo()
        {
            // solicita sexo ao usuario e faz validação dos dados

            // Crio uma var para salvar o sexo informado pelo usuario e limpo a tela para aparição de futura nova pergunta
            string sexo;
            Console.Clear();
            Console.Write("\nAgora preciso que voce me diga o seu sexo (digite M para Masculino e F para Feminino): ");
            // Recebe o valor informado pelo usuario
            sexo = Console.ReadLine();

            //utilizo toUpper para deixar em maiusculo a letra digitada pelo usuario para facilitar a validação.
            //verifica através do while se o usuario realmente utilizou as opçoes validas, caso nao, orienta e solicita novamente
            while (sexo.ToUpper() != "F" && sexo.ToUpper() != "M")
            {
                Console.Write("Desculpe, dessa forma não consigo entender, tente novamente com as opções M ou F, de acordo com o seu sexo: ");
                sexo = Console.ReadLine();
            }

            if (sexo.ToUpper() == "M")
                sexo = "Masculino";
            else
                sexo = "Feminino";
            return sexo;
        }

        static string ObterNome()
        {
            // solicita nome ao usuario e faz validação dos dados

            // Crio uma var para salvar o nome informado pelo usuario e limpo a tela para aparição de futura nova pergunta
            string nome;
            Console.Clear();

            Console.Write("\nQual o seu nome? digite a seguir: ");
            // salva o nome informado
            nome = Console.ReadLine();

            //valida se não deixou em branco, caso sim, solicita novamente
            while (string.IsNullOrEmpty(nome))
            {
                Console.Write("Ops! este não é um nome. Por favor, utilize seu nome real: ");
                nome = Console.ReadLine();
            }

            return nome;
        }

        static double ObterPeso()
        {
            // solicita peso ao usuario e faz validação dos dados

            //var para salvar tentativa de conversao através do TryParse e var peso para salvar o valor convertido para double
            //limpo a tela novamente para a proxima pergunta
            bool converteu = false;
            double peso = 0;
            Console.Clear();
            // Pedindo peso do usuario e o orientando quanto a virgula
            //obtendo peso e substituindo espaço e ponto por virgula
            //Tentando converter para double
            Console.Write("\nDiga o seu peso em Kg utilizando virgula(,) para separar as medidas. Exemplo (70,00): ");
            string respostaDoPeso = Console.ReadLine().Replace(".", ",").Replace(" ", ",");
            converteu = Double.TryParse(respostaDoPeso, out peso);

            //validando se converteu e se o peso esta de acordo com a tabela do exercício
            //Caso não, solicita novamente no while
            while (!converteu || peso <= 0)
            {
                Console.Write("Esse peso é invalido! tente novamente utilizando a virgula (,) para separar as medidas. Exemplo (70,00): ");
                respostaDoPeso = Console.ReadLine().Replace(".", ",").Replace(" ", ",");
                converteu = Double.TryParse(respostaDoPeso, out peso);
            }
            return peso;
        }

    }
}