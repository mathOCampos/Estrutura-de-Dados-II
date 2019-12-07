using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAcessosFila
{
    class Program
    {
        private static Cadastro cadastro = new Cadastro();
        static void Main(string[] args)
        {
            cadastro.download();
            int opcao;
            do
            {
                mostrarMenu();
                opcao = int.Parse(Console.ReadLine());
                if (opcao > 10)
                {
                    Console.WriteLine("Opcao invalida!\n");
                }
                try
                {
                    switch (opcao)
                    {
                        case 0:
                            cadastro.upload();
                            break;
                        case 1:
                            cadastrarAmbiente();
                            break;
                        case 2:
                            consultarAmbiente();
                            break;
                        case 3:
                            excluirAmbiente();
                            break;
                        case 4:
                            cadastrarUsuario();
                            break;
                        case 5:
                            consultarUsuario();
                            break;
                        case 6:
                            excluirUsuario();
                            break;
                        case 7:
                            concederPermissao();
                            break;
                        case 8:
                            revogarPermissao();
                            break;
                        case 9:
                            registrarAcesso();
                            break;
                        case 10:
                            consultarLogs();
                            break;
                        case 11:
                            limparTela();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRO: {0}", e.ToString());
                }

            } while (opcao != 0);
        }
        private static void mostrarMenu()
        {
            Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
            Console.WriteLine("0.  Sair");
            Console.WriteLine("1.  Cadastrar ambiente ");
            Console.WriteLine("2.  Consultar ambiente ");
            Console.WriteLine("3.  Excluir ambiente");
            Console.WriteLine("4.  Cadastrar usuario");
            Console.WriteLine("5.  Consultar usuario");
            Console.WriteLine("6.  Excluir usuario");
            Console.WriteLine("7.  Conceder permissão de acesso ao usuario (informar ambiente e usuário - vincular ambiente ao usuário) ");
            Console.WriteLine("8.  Revogar permissão de acesso ao usuario (informar ambiente e usuário - desvincular ambiente ao usuário) ");
            Console.WriteLine("9.  Registrar acesso (informar o ambiente e o usuário - registrar o log respectivo)  ");
            Console.WriteLine("10. Consultar logs de acesso(informar o ambiente e listar os logs - filtrar por logs autorizados / negados / todos) ");
            Console.WriteLine("11. Limpar tela");
            Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
            Console.Write("Opção: ");
        }
        public static void cadastrarAmbiente()
        {
            Ambiente ambienteNovo = new Ambiente();
            Console.Write("Digite o id do ambiente: ");
            ambienteNovo.Id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do ambiente: ");
            ambienteNovo.Nome = Console.ReadLine();
            cadastro.adicionarAmbiente(ambienteNovo);
        }
        public static void consultarAmbiente()
        {
            Ambiente ambienteConsulta = new Ambiente();
            Console.Write("Digite o id do ambiente a ser consultado: ");
            ambienteConsulta.Id = int.Parse(Console.ReadLine());
            Ambiente ambienteConsultado = cadastro.pesquisarAmbiente(ambienteConsulta);
            if (ambienteConsultado == null)
            {
                Console.WriteLine("Ambiente nao encontrado!");
            }
            else
            {
                Console.WriteLine("Ambiente ID: {0} ", ambienteConsultado.Id);
                Console.WriteLine("Ambiente Nome: {0}", ambienteConsultado.Nome);
                Console.WriteLine("Logs Registrados: ");
                foreach (Log log in ambienteConsultado.Logs)
                {
                    Console.WriteLine(log.DtAcesso);
                    Console.WriteLine(log.Usuario.Nome);
                    Console.WriteLine(log.TipoAcesso + "\n");
                }
            }
        }

        public static void limparTela()
        {
            Console.Clear();
        }
        public static void excluirAmbiente()
        {
            Ambiente ambienteExcluir = new Ambiente();
            Console.Write("Digite o id do ambiente a ser excluido: ");
            ambienteExcluir.Id = int.Parse(Console.ReadLine());

            if (!cadastro.removerAmbiente(ambienteExcluir))            
                Console.WriteLine("Ambiente não encontrado");            
            else            
                Console.WriteLine("Ambiente Excluido");            
        }
        public static void cadastrarUsuario()
        {
            Usuario usuarioNovo = new Usuario();
            Console.Write("Digite o id do usuario: ");
            usuarioNovo.Id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do usuario: ");
            usuarioNovo.Nome = Console.ReadLine();
            cadastro.adicionarUsuario(usuarioNovo);
        }
        public static void consultarUsuario()
        {
            Usuario usuarioConsulta = new Usuario();
            Console.Write("Digite o id do usuario a ser consultado: ");
            usuarioConsulta.Id = int.Parse(Console.ReadLine());
            Usuario usuarioConsultado = cadastro.pesquisarUsuario(usuarioConsulta);
            if (usuarioConsultado == null)
            {
                Console.WriteLine("Usuario nao encontrado!");
            }
            else
            {
                Console.WriteLine("Usuario ID: {0} ", usuarioConsultado.Id);
                Console.WriteLine("Usuario Nome: {0}", usuarioConsultado.Nome);
                Console.WriteLine("Ambientes Permitidos: ");
                foreach (Ambiente ambiente in usuarioConsultado.Ambientes)
                {
                    Console.WriteLine(ambiente.Nome);
                }
            }

        }
        public static void excluirUsuario()
        {
            Usuario usuarioExcluir = new Usuario();
            Console.Write("Digite o id do usuario a ser excluido: ");
            usuarioExcluir.Id = int.Parse(Console.ReadLine());

            if (!cadastro.removerUsuario(usuarioExcluir))
                Console.WriteLine("Usuario não encontrado");            
            else            
                Console.WriteLine("Usuario Excluido");            
        }
        public static void concederPermissao()
        {
            Usuario usuarioConsulta = new Usuario();
            Ambiente ambienteConsulta = new Ambiente();

            Console.Write("Digite o id do ambiente a ser vinculado: ");
            ambienteConsulta.Id = int.Parse(Console.ReadLine());
            Ambiente ambienteConsultado = cadastro.pesquisarAmbiente(ambienteConsulta);
            Console.Write("Digite o id do usuario a ser permitido: ");
            usuarioConsulta.Id = int.Parse(Console.ReadLine());
            Usuario usuarioConsultado = cadastro.pesquisarUsuario(usuarioConsulta);

            if (usuarioConsultado.concederPermissao(ambienteConsultado))            
                Console.WriteLine("Permissao concedida");            
            else            
                Console.WriteLine("Permissao ja concedida");
        }
        public static void revogarPermissao()
        {
            Usuario usuarioConsulta = new Usuario();
            Ambiente ambienteConsulta = new Ambiente();

            Console.Write("Digite o id do usuario a ser revogado: ");
            usuarioConsulta.Id = int.Parse(Console.ReadLine());
            Usuario usuarioConsultado = cadastro.pesquisarUsuario(usuarioConsulta);

            Console.Write("Digite o id do ambiente: ");
            ambienteConsulta.Id = int.Parse(Console.ReadLine());
            Ambiente ambienteConsultado = cadastro.pesquisarAmbiente(ambienteConsulta);


            if (usuarioConsultado.revogarPermissao(ambienteConsultado))
                Console.WriteLine("Permissao revogada");       
            else            
                Console.WriteLine("Não há permissao registrada para este ambiente");            
        }
        public static void registrarAcesso()
        {
            Usuario usuarioConsulta = new Usuario();
            Ambiente ambienteConsulta = new Ambiente();

            Console.Write("Digite o id do ambiente a ser registrado: ");
            ambienteConsulta.Id = int.Parse(Console.ReadLine());
            Ambiente ambienteConsultado = cadastro.pesquisarAmbiente(ambienteConsulta);

            Console.Write("Digite o id do usuario a ser registrado: ");
            usuarioConsulta.Id = int.Parse(Console.ReadLine());
            Usuario usuarioConsultado = cadastro.pesquisarUsuario(usuarioConsulta);

                if (usuarioConsultado.Ambientes.Contains(ambienteConsultado))
                    ambienteConsultado.registrarLog(new Log(DateTime.Now, usuarioConsultado, true));
                else
                    ambienteConsultado.registrarLog(new Log(DateTime.Now, usuarioConsultado, false));
        }
        public static void consultarLogs()
        {
            Ambiente ambienteConsulta = new Ambiente();
            Console.Write("Digite o id do ambiente a ser vinculado: ");
            ambienteConsulta.Id = int.Parse(Console.ReadLine());
            Ambiente ambienteConsultado = cadastro.pesquisarAmbiente(ambienteConsulta);
            int opcao;
            do
            {
                Console.WriteLine("Deseja filtrar por: ");
                Console.WriteLine("1. Autorizados");
                Console.WriteLine("2. Negados");
                Console.WriteLine("3. Todos");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());
            } while (opcao < 1 || opcao > 3);

            switch (opcao)
            {
                case 1:
                    foreach (Log log in ambienteConsultado.Logs)
                    {
                        if (log.TipoAcesso)
                        {
                            Console.WriteLine(log.DtAcesso);
                            Console.WriteLine(log.Usuario.Nome);
                        }
                    }
                    break;
                case 2:
                    foreach (Log log in ambienteConsultado.Logs)
                    {
                        if (!log.TipoAcesso)
                        {
                            Console.WriteLine(log.DtAcesso);
                            Console.WriteLine(log.Usuario.Nome);
                        }
                    }
                    break;
                case 3:
                    foreach (Log log in ambienteConsultado.Logs)
                    {
                        Console.WriteLine(log.DtAcesso);
                        Console.WriteLine(log.Usuario.Nome);
                    }
                    break;
            }

        }
    }
}
