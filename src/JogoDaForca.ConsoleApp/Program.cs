namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static string[] palavras = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAI", "ARAÇA", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU", "CARAMBOLA", "CUPUAÇU", "UVAIA", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA" };

        static void Main(string[] args)
        {
            var random = new Random();
            int indexPalavras = random.Next(palavras.Length);
            int limite = 5;
            int tentativaAtual = 0;
            Console.WriteLine($"Palavra aleatória: {palavras[indexPalavras]}");
            char[] charArray = palavras[indexPalavras].ToCharArray();
            char[] palavraEscondida = new char[charArray.Length];
         
            Console.WriteLine(palavraEscondida);
            bool areEqual;

            for (int i = 0; i < charArray.Length; i++)
                {
                    palavraEscondida[i] = '_';
                }
            do
            {
                string cabeca = tentativaAtual >= 1 ? " o " : " ";
                string peitoral = tentativaAtual >= 2 ? "x" : " ";
                string bracoEsquerdo = tentativaAtual >= 3 ? "/" : " ";
                string bracoDireito = tentativaAtual >= 3 ? @"\" : " ";
                string barriga = tentativaAtual >= 4 ? " x " : " ";
                string pernaEsquerda = tentativaAtual >= 5 ? "/" : " ";
                string pernaDireita = tentativaAtual >= 5 ? @" \" : " ";

                Console.WriteLine(" -----------        ");
                Console.WriteLine(" |/        |        ");
                Console.WriteLine(" |        {0}       ", cabeca);
                Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, peitoral, bracoDireito);
                Console.WriteLine(" |        {0} ", barriga);
                Console.WriteLine(" |        {0}{1}       ", pernaEsquerda, pernaDireita);
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine("_|____");

                Console.Write("\nQual o seu chute? ");
                char letraChute = Convert.ToChar(Console.ReadLine().ToUpper());

                bool letraCorreta = false;
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (letraChute == charArray[i])
                    {
                        palavraEscondida[i] = letraChute;
                        letraCorreta = true;
                    }
                }

                if (letraCorreta == false)
                {
                    tentativaAtual++;
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine($"Tentativa {limite - tentativaAtual}");

                    
                }

                Console.WriteLine(palavraEscondida);
                areEqual = charArray.SequenceEqual(palavraEscondida);

                if (tentativaAtual == limite)
                {
                    Console.WriteLine("Suas vidas acabaram :(");
                    break;
                }
            } while (areEqual == false);

            Console.ReadLine();
        }
    }
}
