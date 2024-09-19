using System;
using System.IO;

namespace TextEditor
{

    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("O que deseja fazer? ");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            Console.Write("Opção: ");
            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

 
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo: ");
            string path = Console.ReadLine(); // Passamos o caminho em qual o arquivo está.

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu(); // Para sempre voltar ao Menu após finalizar a função.
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair): ");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); // Verifica qual foi a tecla digitada.
            // se for o "Esc" ele termina o texto.
            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo: ");
            var path = Console.ReadLine(); // Para determinar o caminho para salvar.
            
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine("Arquivo salvo");
            Console.ReadLine();
            Menu();
        }
    }   
}