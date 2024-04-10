namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JogoDaForca jogo = new JogoDaForca();
            jogo.Iniciar();
        }
    }

    public class JogoDaForca
    {
        public static string[] palavras = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAI", "ARAÇA", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU", "CARAMBOLA", "CUPUAÇU", "UVAIA", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA" };
        public string palavra;
        public char[] palavraEscondida;
        public int limite = 5;
        public int tentativaAtual = 0;

        public void Iniciar()
        {
            var random = new Random();
            int indexPalavras = random.Next(palavras.Length);
            palavra = palavras[indexPalavras];
            palavraEscondida = new char[palavra.Length];

            for (int i = 0; i < palavra.Length; i++)
            {
                palavraEscondida[i] = '_';
            }

            bool areEqual;

            do
            {
                DesenharForca();
                Console.WriteLine("\nPalavra: " + new string(palavraEscondida));
                Console.Write("\nQual é o seu chute? ");
                char letraChute = Convert.ToChar(Console.ReadLine().ToUpper());

                bool letraCorreta = false;
                for (int i = 0; i < palavra.Length; i++)
                {
                    if (letraChute == palavra[i])
                    {
                        palavraEscondida[i] = letraChute;
                        letraCorreta = true;
                    }
                }

                if (!letraCorreta)
                {
                    tentativaAtual++;
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine($"Tentativa {limite - tentativaAtual}");
                }

                Console.WriteLine(new string(palavraEscondida));
                areEqual = palavra.ToCharArray().SequenceEqual(palavraEscondida);

                if (tentativaAtual == limite)
                {
                    Console.WriteLine("Suas vidas acabaram :(");
                    break;
                }
            } while (!areEqual);
        }

        public void DesenharForca()
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
        }
    }
}