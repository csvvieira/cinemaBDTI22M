using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTI22M
{
    class ControlMenu
    {
        private ControlFilme controleFilme;
        private ControlSala controleSala;
        private ControlSessao controleSessao;
        private ControlFidelidade controleFidelidade;
        private ControlCliente controleCliente;
        private ControlPromocao controlePromocao;
        private ControlIngresso controleIngresso;
        private int opcaoPrincipal;
        private int opcaoGeral;

        public ControlMenu()
        {
            controleFilme = new ControlFilme();
            controleSala = new ControlSala();
            controleSessao = new ControlSessao();
            controleFidelidade = new ControlFidelidade();
            controleCliente = new ControlCliente();
            controlePromocao = new ControlPromocao();
            controleIngresso = new ControlIngresso();
        }//Fim do construtor

        //Métodos GETs e SETs
        public int ModificarOpcaoPrincipal
        {
            get { return opcaoPrincipal; }
            set { opcaoPrincipal = value; }
        }//Fim do método

        public int ModificarOpcaoGeral
        {
            get { return opcaoGeral; }
            set { opcaoGeral = value; }
        }//Fim do método

        //Exibir o menu
        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n MENU PRINCIPAL \n\n"        +
                              "Escolha uma das opções abaixo: " +
                              "\n0. Sair"                       +
                              "\n1. Filme"                      +
                              "\n2. Sala"                       +
                              "\n3. Sessão"                     +
                              "\n4. Cartão Fidelidade"          +
                              "\n5. Cliente"                    +
                              "\n6. Promoção"                   +
                              "\n7. Ingresso");
            ModificarOpcaoPrincipal = Convert.ToInt32(Console.ReadLine());
        }//Fim do método

        public void ExecutarMenuPrincipal()
        {
            //Executar o menu
            do
            {
                MostrarMenu();
                switch (ModificarOpcaoPrincipal)
                {
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    case 1:
                        Console.WriteLine("Filme");
                        ExecutarFilme();
                        break;
                    case 2:
                        Console.WriteLine("Sala");
                        ExecutarSala();
                        break;
                    case 3:
                        Console.WriteLine("Sessão");
                        ExecutarSessao();
                        break;
                    case 4:
                        Console.WriteLine("Cartão Fidelidade");
                        ExecutarFidelidade();
                        break;
                    case 5:
                        Console.WriteLine("Cliente");
                        ExecutarCliente();
                        break;
                    case 6:
                        Console.WriteLine("Promoção");
                        ExecutarPromocao();
                        break;
                    case 7:
                        Console.WriteLine("Ingresso");
                        ExecutarIngresso();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoPrincipal != 0);//Fim do do-while
        }//Fim do método

        public void MenuGeral()
        {
            Console.WriteLine("\n\nEscolha uma das ações do CRUD" +
                              "\n0. Voltar ao menu anterior"      +
                              "\n1. Cadastrar"                    +
                              "\n2. Consultar"                    +
                              "\n3. Consultar por Código"         +
                              "\n4. Atualizar"                    +
                              "\n5. Excluir");
            ModificarOpcaoGeral = Convert.ToInt32(Console.ReadLine());
        }//Fim do método

        public void ExecutarFilme()
        {
            do
            {
                Console.WriteLine("\n\nMENU FILME\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Filme");
                        //Dados
                        Console.WriteLine("\nInforme o Título do filme: ");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("\nInforme o Gênero do filme: ");
                        string genero = Console.ReadLine();
                        //Chamar o filme
                        this.controleFilme = new ControlFilme(titulo, genero);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Filme");
                        this.controleFilme.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Filme por Código");
                        this.controleFilme.ConsultaPorCodigoFilme();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Filme");
                        this.controleFilme.AtualizarFilme();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Filme");
                        this.controleFilme.ExcluirFilme();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método

        public void ExecutarSala()
        {
            do
            {
                Console.WriteLine("\n\nMENU SALA\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Sala");
                        //Dados
                        Console.WriteLine("\nInforme a capacidade da sala: ");
                        int capacidade = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme os recursos da sala: ");
                        string recursos = Console.ReadLine();
                        //Chamar o filme
                        this.controleSala = new ControlSala(capacidade, recursos);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Sala");
                        this.controleSala.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Sala por Código");
                        this.controleSala.ConsultaPorCodigoSala();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Sala");
                        this.controleSala.AtualizarSala();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Sala");
                        this.controleSala.ExcluirSala();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método

        public void ExecutarSessao()
        {
            do
            {
                Console.WriteLine("\n\nMENU SESSÃO\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Sessão");
                        //Dados
                        Console.WriteLine("\nInforme o horário da Sessão: ");
                        DateTime horario = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme o código da sala: ");
                        int codigoSala = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o código do filme: ");
                        int codigoFilme = Convert.ToInt32(Console.ReadLine());
                        //Chamar o filme
                        this.controleSessao = new ControlSessao(horario, codigoSala, codigoFilme);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Sessão");
                        this.controleSessao.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Sessão por Código");
                        this.controleSessao.ConsultaPorCodigoSessao();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Sessão");
                        this.controleSessao.AtualizarSessao();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Sessão");
                        this.controleSessao.ExcluirSessao();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método

        public void ExecutarFidelidade()
        {
            do
            {
                Console.WriteLine("\n\nMENU CARTÃO FIDELIDADE\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Fidelidade");
                        //Dados
                        Console.WriteLine("\nInforme a quantidade de compras: ");
                        int quantidadeDeCompras = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o número de pontos: ");
                        int pontos = Convert.ToInt32(Console.ReadLine());
                        //Chamar o filme
                        this.controleFidelidade = new ControlFidelidade(quantidadeDeCompras, pontos);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Fidelidade");
                        this.controleFidelidade.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Fidelidade por Código");
                        this.controleFidelidade.ConsultaPorCodigoFidelidade();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Fidelidade");
                        this.controleFidelidade.AtualizarFidelidade();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Fidelidade");
                        this.controleFidelidade.ExcluirFidelidade();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método

        public void ExecutarCliente()
        {
            do
            {
                Console.WriteLine("\n\nMENU CLIENTE\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Cliente");
                        //Dados
                        Console.WriteLine("\nInforme o nome do Cliente: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("\nInforme o CPF do Cliente: ");
                        long CPF = Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("\nInforme o email do Cliente: ");
                        string email = Console.ReadLine();

                        Console.WriteLine("\nInforme a data de nascimento do Cliente: ");
                        DateTime dtNascimento = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme o telefone do Cliente: ");
                        string telefone = Console.ReadLine();

                        Console.WriteLine("\nInforme o código do cartão fidelidade do Cliente: ");
                        int codigoFidelidade = Convert.ToInt32(Console.ReadLine());
                        //Chamar o filme
                        this.controleCliente = new ControlCliente(nome, CPF, email, dtNascimento, telefone, codigoFidelidade);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Cliente");
                        this.controleCliente.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Cliente por Código");
                        this.controleCliente.ConsultaPorCodigoCliente();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Cliente");
                        this.controleCliente.AtualizarCliente();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Cliente");
                        this.controleCliente.ExcluirCliente();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método

        public void ExecutarPromocao()
        {
            do
            {
                Console.WriteLine("\n\nMENU PROMOÇÃO\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Promoção");
                        //Dados
                        Console.WriteLine("\nInforme a data da Promoção: ");
                        DateTime dataPromocao = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme o horário do Promoção: ");
                        DateTime horario = Convert.ToDateTime(Console.ReadLine());
                        //Chamar o filme
                        this.controlePromocao = new ControlPromocao(dataPromocao, horario);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Promoção");
                        this.controlePromocao.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Promoção por Código");
                        this.controlePromocao.ConsultaPorCodigoPromocao();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Promoção");
                        this.controlePromocao.AtualizarPromocao();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Promoção");
                        this.controlePromocao.ExcluirPromocao();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método

        public void ExecutarIngresso()
        {
            do
            {
                Console.WriteLine("\n\nMENU Ingresso\n\n");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar Ingresso");
                        //Dados
                        Console.WriteLine("\nInforme a data do Ingresso: ");
                        DateTime dataIngresso = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme o assento do Ingresso: ");
                        string assento = Console.ReadLine();

                        Console.WriteLine("\nInforme o valor do Ingresso: ");
                        double valor = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("\nInforme o código do cliente: ");
                        int codigoCliente = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o código da sessão: ");
                        int codigoSessao = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o código da promoção: ");
                        int codigoPromocao = Convert.ToInt32(Console.ReadLine());
                        //Chamar o filme
                        this.controleIngresso = new ControlIngresso(dataIngresso, assento, valor, codigoCliente, codigoSessao, codigoPromocao);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Ingresso");
                        this.controleIngresso.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Ingresso por Código");
                        this.controleIngresso.ConsultaPorCodigoIngresso();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Ingresso");
                        this.controleIngresso.AtualizarIngresso();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir Ingresso");
                        this.controleIngresso.ExcluirIngresso();
                 break;
                    default:
                        Console.WriteLine("Opcão Inválida!!!");
                        break;
                }//Fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim do do-while
        }//Fim do método
    }//Fim da classe
}//Fim do projeto
