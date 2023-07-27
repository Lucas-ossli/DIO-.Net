
using System.Text;
using System.IO;

namespace StringReaderProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            stringReader();
        }


        public static void stringReader()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Caracteres na primeira linhan para ler");
            sb.AppendLine("E a segunda linha");
            sb.AppendLine("e o fim");


            using (var sr = new StringReader(sb.ToString()))
            {
                var buffer = new char[10];
                do
                {
                    var pos = sr.Read(buffer);
                    Console.WriteLine($"{string.Join("", buffer)}");
                    
                } while (0 >= buffer.Length);

            }

        }

        public static void Edicao()
        {
            var textReaderText = @"Lorem Ipsum é simplesmente uma simulação de texto da 
                                    indústria tipográfica e de impressos, e vem sendo 
                                    utilizado desde o século XVI, quando um impressor 
                                    desconhecido pegou uma bandeja de tipos e os embaralhou
                                     para fazer um livro de modelos de tipos. Lorem Ipsum 
                                     sobreviveu não só a cinco séculos, como também ao salto 
                                     para a editoração eletrônica, permanecendo essencialmente 
                                     inalterado. Se popularizou na década de 60, quando a Letraset 
                                     lançou decalques contendo passagens de Lorem Ipsum, 
                                     e mais recentemente quando passou a ser integrado a softwares 
                                     de editoração eletrônica como Aldus PageMaker.";

            string linha, paragrafo = null;

            var sr = new StringReader(textReaderText);
            while(true)
            {
                linha = sr.ReadLine();
                if(linha != null)
                {
                    paragrafo += linha + " ";
                }
                else
                {
                    paragrafo += "\n";
                    break;
                }
            }

            Console.WriteLine($"Texto Modificado: {paragrafo}");


            int charLido;
            char charConvertido;
            var sw = new StringWriter();
            sr = new StringReader(paragrafo);

            while(true)
            {
                charLido = sr.Read();
                if(charLido == -1) break;

                charConvertido = Convert.ToChar(charLido);

                if(charLido == '.')
                {
                    sw.Write("\n\n");

                    sr.Read();
                    sr.Read();
                }else
                {
                    sw.Write(charConvertido);
                }
            }

        }
    }
}
