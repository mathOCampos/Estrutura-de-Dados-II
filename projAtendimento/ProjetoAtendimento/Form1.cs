using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoAtendimento
{
    public partial class Form1 : Form
    {
        
        Senhas senhas = new Senhas();
        Guiches guiches = new Guiches();

        Button btnGerarSenha = new Button();
        ListBox listBoxSenhas = new ListBox();
        Button btnListarSenhas = new Button();

        Label lblQtdeGuichesLabel = new Label();
        Label lblQtdeGuiches = new Label();
        Button btnAdicionar = new Button();

        Label lblGuiche = new Label();
        TextBox txtGuiche = new TextBox();
        Button btnChamarAtendimento = new Button();
        ListBox listBoxAtendimentos = new ListBox();
        Button btnListarAtendimentos = new Button();

        public void IniciarComponentes()
        {
            Width = 720;
            Height = 300;

            btnGerarSenha.Parent = this;
            btnGerarSenha.Top = 10;
            btnGerarSenha.Left = 10;
            btnGerarSenha.Name = "btnGerarSenha";
            btnGerarSenha.Text = "Gerar";
            btnGerarSenha.Click += new EventHandler(btnGerarSenhaClicked);

            listBoxSenhas.Parent = this;
            listBoxSenhas.Width = 250;
            listBoxSenhas.Top = 50;
            listBoxSenhas.Left = 10;
            listBoxSenhas.Name = "listBoxSenhas";

            btnListarSenhas.Parent = this;
            btnListarSenhas.Top = 210;
            btnListarSenhas.Left = 10;
            btnListarSenhas.Name = "btnListarSenhas";
            btnListarSenhas.Text = "Listar senhas";
            btnListarSenhas.Click += new EventHandler(btnListarSenhasClicked);

            lblQtdeGuichesLabel.Parent = this;
            lblQtdeGuichesLabel.Width = 100;
            lblQtdeGuichesLabel.Top = 110;
            lblQtdeGuichesLabel.Left = 300;
            lblQtdeGuichesLabel.Name = "lblQtdeGuichesLabel";
            lblQtdeGuichesLabel.Text = "Qtde guichês";

            lblQtdeGuiches.Parent = this;
            lblQtdeGuiches.Width = 100;
            lblQtdeGuiches.Top = 160;
            lblQtdeGuiches.Left = 310;
            lblQtdeGuiches.Name = "lblQtdeGuiches";
            lblQtdeGuiches.Text = guiches.ListaGuiches.Count.ToString();

            btnAdicionar.Parent = this;
            btnAdicionar.Top = 210;
            btnAdicionar.Left = 300;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Click += new EventHandler(btnAdicionarClicked);

            lblGuiche.Parent = this;
            lblGuiche.Width = 50;
            lblGuiche.Top = 10;
            lblGuiche.Left = 410;
            lblGuiche.Name = "lblGuiche";
            lblGuiche.Text = "Guiche:";

            txtGuiche.Parent = this;
            txtGuiche.Width = 50;
            txtGuiche.Top = 10;
            txtGuiche.Left = 465;
            txtGuiche.Name = "txtGuiche";

            btnChamarAtendimento.Parent = this;
            btnChamarAtendimento.Top = 10;
            btnChamarAtendimento.Left = 585;
            btnChamarAtendimento.Name = "btnChamarAtendimento";
            btnChamarAtendimento.Text = "Chamar";
            btnChamarAtendimento.Click += new EventHandler(btnChamarAtendimentoClicked);

            listBoxAtendimentos.Parent = this;
            listBoxAtendimentos.Width = 250;
            listBoxAtendimentos.Top = 50;
            listBoxAtendimentos.Left = 410;
            listBoxAtendimentos.Name = "listBoxAtendimentos";

            btnListarAtendimentos.Parent = this;
            btnListarAtendimentos.Top = 210;
            btnListarAtendimentos.Left = 510;
            btnListarAtendimentos.Name = "btnListarAtendimentos";
            btnListarAtendimentos.Text = "Listar Atendimentos";
            btnListarAtendimentos.Click += new EventHandler(btnListarAtendimentosClicked);
        }
        public Form1()
        {
            InitializeComponent();
            IniciarComponentes();
        }

        //botões
        public void btnGerarSenhaClicked(object sender, EventArgs e)
        {
            senhas.gerar();
        }

        public void btnListarSenhasClicked(object sender, EventArgs e)
        {
            listBoxSenhas.Items.Clear();

            foreach (Senha senha in senhas.FilaSenhas)
            {
                listBoxSenhas.Items.Add(senha.dadosParciais());
            }
        }

        public void btnAdicionarClicked(object sender, EventArgs e)
        {
            guiches.adicionar(new Guiche());
            lblQtdeGuiches.Text = guiches.ListaGuiches.Count.ToString();
        }

        public void btnChamarAtendimentoClicked(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(txtGuiche.Text) - 1;
                if (!guiches.ListaGuiches[index].chamar(senhas.FilaSenhas))
                    MessageBox.Show("Não há senhas.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Revise a numeração do Guichê");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Guichê inexistente");
            }
        }

        public void btnListarAtendimentosClicked(object sender, EventArgs e)
        {
            listBoxAtendimentos.Items.Clear();

            try
            {
                int index = int.Parse(txtGuiche.Text) - 1;
                foreach (Senha senha in guiches.ListaGuiches[index].Atendimentos)
                {
                    listBoxAtendimentos.Items.Add(senha.dadosCompletos());
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Revise a numeração do Guichê");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Guichê inexistente");
            }
        }
    }
}
