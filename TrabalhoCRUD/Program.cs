using System.Security.Cryptography;
using System.Text.Json;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace TrabalhoCRUD
{
    internal class Program
    {
        static List<string> RetornarProdutos()
        {

            List<string> times = new List<string>();
            while (true)
            {
                Console.WriteLine("Digite um time ou zero para parar");
                string time = Console.ReadLine();
                if (time == "0")
                {
                    break;
                }
                else
                {
                    times.Add(time);
                }

            }
            return times;
        }
        static int RegistrarArquivos(List<string> times)
        {
            string json = JsonSerializer.Serialize(times);
            Console.WriteLine(json);

            StreamWriter criarArquivo;
            string caminhoPercorrer = "C:\\Users\\sanli\\OneDrive - SENAC-SC\\Documentos\\Projetos\\TrabalhoCRUD\\BancoCRUD\\SanliTimes.txt";

            criarArquivo = File.CreateText(caminhoPercorrer);


            criarArquivo.WriteLine(json);
            criarArquivo.Close();
            return 0;
        }
        static List<string> DescerealizarArquivos()
        {
            
            string jsonRetorno = File.ReadAllText("C:\\Users\\sanli\\OneDrive - SENAC-SC\\Documentos\\Projetos\\TrabalhoCRUD\\BancoCRUD\\SanliTimes.txt");
            List<string> abrirTimes = JsonSerializer.Deserialize<List<string>>(jsonRetorno);

            for (int i = 0; i < abrirTimes.Count; i++)
            {


                Console.WriteLine($"{i} - {(abrirTimes[i])}");

            }
            Console.WriteLine();
            return abrirTimes;
        }
        static int LerArquivos()
        {


            
            StreamReader lerArquivo;
            string Caminho = "C:\\Users\\sanli\\OneDrive - SENAC-SC\\Documentos\\Projetos\\TrabalhoCRUD\\BancoCRUD\\SanliTimes.txt";
            lerArquivo = File.OpenText(Caminho);
            string linha = lerArquivo.ReadLine();
            Console.WriteLine(linha);
            lerArquivo.Close();
            return 0;
            
        }
        static int DeletarAquivo()
        {



                string Caminho = "C:\\Users\\sanli\\OneDrive - SENAC-SC\\Documentos\\Projetos\\TrabalhoCRUD\\BancoCRUD\\SanliTimes.txt";
                StreamReader lerArquivo;

                lerArquivo = File.OpenText(Caminho);
                lerArquivo.Close();
                File.Delete(Caminho);
                Console.WriteLine("Arquivo Deletado");
                return 0;
            
        }
        static List<string> EditarTimes(List<string> editaveis)
        {

            while (true)
            {
                Console.WriteLine("Digite qual o numero do produto que deseja editar, -1 para sair ou qualquer outro numero para adicionar mais produtos");
                int qTimes = Convert.ToInt32(Console.ReadLine());
                if (qTimes == -1)
                {
                    break;
                }
                else if (qTimes < editaveis.Count())
                {
                    Console.WriteLine("Digite o novo produto");
                    string novo = Console.ReadLine();
                    editaveis[qTimes] = novo;
                }
                else
                {
                    Console.WriteLine("Digite o novo produto");
                    string novo = Console.ReadLine();
                    editaveis.Add(novo);
                }
                for (int i = 0; i < editaveis.Count(); i++)
                {
                    Console.WriteLine($"{i} - {editaveis[i]}");
                }

            }
            return editaveis;
        }
        
        static void Main(string[] args)
        {
            try
            {


                int selecao = 1;

                while (selecao != 4)
                {
                    Console.WriteLine("O que deseja fazer com o arquivo?");
                    Console.WriteLine("0 - Criar o arquivo");
                    Console.WriteLine("1 - Ler o arquivo");
                    Console.WriteLine("2 - Deletar o arquivo");
                    Console.WriteLine("3 - Editar o arquivo");
                    Console.WriteLine("4 - Sair do console");
                    selecao = Convert.ToInt32(Console.ReadLine());

                    switch (selecao)
                    {

                        case 0:
                            Console.WriteLine("Criando um arquivo");
                            //Criando uma lista \/ 
                            List<string> produtos = RetornarProdutos();
                            //Criando um arquivo \/
                            RegistrarArquivos(produtos);
                            break;

                        case 1:
                            try
                            {

                                //Lendo o Arquivo \/
                                LerArquivos();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Arquivo não pode ser lido, pois não foi criado ou o caminho da pasta esta incorreto");
                                break;
                            }
                        case 2:
                            try
                            {
                                //Deletando arquivo \/
                                DeletarAquivo();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Arquivo não pode ser deletado, pois não foi criado ou o caminho da pasta esta incorreto");
                                break;
                            }
                        case 3:
                            try
                            {
                                //Tranformando em lista novamente\/
                                List<string> editaveis = DescerealizarArquivos();
                                //Editando a lista \/
                                List<string> editado = EditarTimes(editaveis);
                                RegistrarArquivos(editado);
                                break;
                            }
                        
                            catch
                            {
                                Console.WriteLine("Arquivo não pode ser editado, pois não foi criado ou o caminho da pasta esta incorreto");
                                break;
                            }
                        case > 4:
                            Console.WriteLine("DIGITE OUTRO NÚMERO");
                            break;
                    }
                    Console.WriteLine("Digite qualquer tecla");
                    Console.ReadKey();
                    Console.Clear();
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Digite somente números");
            }
     }
    }
}


