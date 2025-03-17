namespace kingMe.cs
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnListarPartidas = new System.Windows.Forms.Button();
            this.lstListarPartidas = new System.Windows.Forms.ListBox();
            this.lblNomePartida = new System.Windows.Forms.Label();
            this.txtNomePartida = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeGrupo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.txtNomePartidaEntrar = new System.Windows.Forms.TextBox();
            this.lblNomePartidaEntrar = new System.Windows.Forms.Label();
            this.txtSenhaEntrar = new System.Windows.Forms.TextBox();
            this.lblSenhaEntrar = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lstJogadores = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblNomeGrupo = new System.Windows.Forms.Label();
            this.pnlCriarPartida = new System.Windows.Forms.Panel();
            this.chkPermissaoIniciar = new System.Windows.Forms.CheckBox();
            this.pnlEntrarPartida = new System.Windows.Forms.Panel();
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnComoJogar = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.pnlMenuInicial = new System.Windows.Forms.Panel();
            this.pnlEscolhaJogar = new System.Windows.Forms.Panel();
            this.btnCriarUmaPartida = new System.Windows.Forms.Button();
            this.btnEntrarNasPartidas = new System.Windows.Forms.Button();
            this.pnlLobby = new System.Windows.Forms.Panel();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.pnlPartida = new System.Windows.Forms.Panel();
            this.lblSetor = new System.Windows.Forms.Label();
            this.txtSetor = new System.Windows.Forms.TextBox();
            this.btnColocarPersonagem = new System.Windows.Forms.Button();
            this.txtPersonagem = new System.Windows.Forms.TextBox();
            this.lstNomePersonagens = new System.Windows.Forms.ListBox();
            this.lblPersonagem = new System.Windows.Forms.Label();
            this.btnVerificarVez = new System.Windows.Forms.Button();
            this.lstTabuleiro = new System.Windows.Forms.ListBox();
            this.lstCartas = new System.Windows.Forms.ListBox();
            this.btnListarCartas = new System.Windows.Forms.Button();
            this.lblSenhaJogador = new System.Windows.Forms.Label();
            this.lblIdJogador = new System.Windows.Forms.Label();
            this.lblIdDaVez = new System.Windows.Forms.Label();
            this.lblNomeDaVez = new System.Windows.Forms.Label();
            this.pnlCriarPartida.SuspendLayout();
            this.pnlEntrarPartida.SuspendLayout();
            this.pnlMenuInicial.SuspendLayout();
            this.pnlEscolhaJogar.SuspendLayout();
            this.pnlLobby.SuspendLayout();
            this.pnlPartida.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(999, 527);
            this.lblVersao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(49, 16);
            this.lblVersao.TabIndex = 1;
            this.lblVersao.Text = "versão";
            // 
            // btnListarPartidas
            // 
            this.btnListarPartidas.Location = new System.Drawing.Point(405, 107);
            this.btnListarPartidas.Margin = new System.Windows.Forms.Padding(4);
            this.btnListarPartidas.Name = "btnListarPartidas";
            this.btnListarPartidas.Size = new System.Drawing.Size(112, 28);
            this.btnListarPartidas.TabIndex = 2;
            this.btnListarPartidas.Text = "Listar partidas";
            this.btnListarPartidas.UseVisualStyleBackColor = true;
            this.btnListarPartidas.Click += new System.EventHandler(this.btnListarPartidas_Click);
            // 
            // lstListarPartidas
            // 
            this.lstListarPartidas.FormattingEnabled = true;
            this.lstListarPartidas.ItemHeight = 16;
            this.lstListarPartidas.Location = new System.Drawing.Point(239, 143);
            this.lstListarPartidas.Margin = new System.Windows.Forms.Padding(4);
            this.lstListarPartidas.Name = "lstListarPartidas";
            this.lstListarPartidas.Size = new System.Drawing.Size(277, 260);
            this.lstListarPartidas.TabIndex = 4;
            this.lstListarPartidas.SelectedIndexChanged += new System.EventHandler(this.lstListarPartidas_SelectedIndexChanged);
            // 
            // lblNomePartida
            // 
            this.lblNomePartida.AutoSize = true;
            this.lblNomePartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePartida.Location = new System.Drawing.Point(448, 65);
            this.lblNomePartida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomePartida.Name = "lblNomePartida";
            this.lblNomePartida.Size = new System.Drawing.Size(147, 22);
            this.lblNomePartida.TabIndex = 5;
            this.lblNomePartida.Text = "Nome da partida:";
            // 
            // txtNomePartida
            // 
            this.txtNomePartida.Location = new System.Drawing.Point(452, 90);
            this.txtNomePartida.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomePartida.Name = "txtNomePartida";
            this.txtNomePartida.Size = new System.Drawing.Size(165, 22);
            this.txtNomePartida.TabIndex = 6;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(452, 160);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(165, 22);
            this.txtSenha.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Senha:";
            // 
            // txtNomeGrupo
            // 
            this.txtNomeGrupo.Location = new System.Drawing.Point(452, 239);
            this.txtNomeGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeGrupo.Name = "txtNomeGrupo";
            this.txtNomeGrupo.Size = new System.Drawing.Size(165, 22);
            this.txtNomeGrupo.TabIndex = 10;
            this.txtNomeGrupo.Text = "Escudeiros de Londres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome do grupo:";
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(452, 396);
            this.btnCriarPartida.Margin = new System.Windows.Forms.Padding(4);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(192, 103);
            this.btnCriarPartida.TabIndex = 11;
            this.btnCriarPartida.Text = "Criar";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // txtNomePartidaEntrar
            // 
            this.txtNomePartidaEntrar.Location = new System.Drawing.Point(589, 122);
            this.txtNomePartidaEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomePartidaEntrar.Name = "txtNomePartidaEntrar";
            this.txtNomePartidaEntrar.Size = new System.Drawing.Size(165, 22);
            this.txtNomePartidaEntrar.TabIndex = 13;
            // 
            // lblNomePartidaEntrar
            // 
            this.lblNomePartidaEntrar.AutoSize = true;
            this.lblNomePartidaEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePartidaEntrar.Location = new System.Drawing.Point(585, 97);
            this.lblNomePartidaEntrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomePartidaEntrar.Name = "lblNomePartidaEntrar";
            this.lblNomePartidaEntrar.Size = new System.Drawing.Size(147, 22);
            this.lblNomePartidaEntrar.TabIndex = 12;
            this.lblNomePartidaEntrar.Text = "Nome da partida:";
            // 
            // txtSenhaEntrar
            // 
            this.txtSenhaEntrar.Location = new System.Drawing.Point(589, 192);
            this.txtSenhaEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenhaEntrar.Name = "txtSenhaEntrar";
            this.txtSenhaEntrar.Size = new System.Drawing.Size(165, 22);
            this.txtSenhaEntrar.TabIndex = 15;
            // 
            // lblSenhaEntrar
            // 
            this.lblSenhaEntrar.AutoSize = true;
            this.lblSenhaEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaEntrar.Location = new System.Drawing.Point(585, 164);
            this.lblSenhaEntrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenhaEntrar.Name = "lblSenhaEntrar";
            this.lblSenhaEntrar.Size = new System.Drawing.Size(67, 22);
            this.lblSenhaEntrar.TabIndex = 14;
            this.lblSenhaEntrar.Text = "Senha:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(589, 266);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(165, 22);
            this.txtUsername.TabIndex = 17;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(601, 241);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(97, 22);
            this.lblUsername.TabIndex = 16;
            this.lblUsername.Text = "Username:";
            // 
            // lstJogadores
            // 
            this.lstJogadores.FormattingEnabled = true;
            this.lstJogadores.ItemHeight = 16;
            this.lstJogadores.Location = new System.Drawing.Point(435, 143);
            this.lstJogadores.Margin = new System.Windows.Forms.Padding(4);
            this.lstJogadores.Name = "lstJogadores";
            this.lstJogadores.Size = new System.Drawing.Size(212, 260);
            this.lstJogadores.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Jogadores";
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(589, 306);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(197, 103);
            this.btnEntrar.TabIndex = 21;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lblNomeGrupo
            // 
            this.lblNomeGrupo.AutoSize = true;
            this.lblNomeGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeGrupo.Location = new System.Drawing.Point(429, 11);
            this.lblNomeGrupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeGrupo.Name = "lblNomeGrupo";
            this.lblNomeGrupo.Size = new System.Drawing.Size(233, 25);
            this.lblNomeGrupo.TabIndex = 22;
            this.lblNomeGrupo.Text = "Escudeiros de Londres";
            // 
            // pnlCriarPartida
            // 
            this.pnlCriarPartida.Controls.Add(this.chkPermissaoIniciar);
            this.pnlCriarPartida.Controls.Add(this.txtNomeGrupo);
            this.pnlCriarPartida.Controls.Add(this.btnCriarPartida);
            this.pnlCriarPartida.Controls.Add(this.label2);
            this.pnlCriarPartida.Controls.Add(this.txtSenha);
            this.pnlCriarPartida.Controls.Add(this.label1);
            this.pnlCriarPartida.Controls.Add(this.txtNomePartida);
            this.pnlCriarPartida.Controls.Add(this.lblNomePartida);
            this.pnlCriarPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCriarPartida.Location = new System.Drawing.Point(0, 0);
            this.pnlCriarPartida.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCriarPartida.Name = "pnlCriarPartida";
            this.pnlCriarPartida.Size = new System.Drawing.Size(1067, 554);
            this.pnlCriarPartida.TabIndex = 23;
            // 
            // chkPermissaoIniciar
            // 
            this.chkPermissaoIniciar.AutoSize = true;
            this.chkPermissaoIniciar.Location = new System.Drawing.Point(452, 271);
            this.chkPermissaoIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.chkPermissaoIniciar.Name = "chkPermissaoIniciar";
            this.chkPermissaoIniciar.Size = new System.Drawing.Size(209, 20);
            this.chkPermissaoIniciar.TabIndex = 14;
            this.chkPermissaoIniciar.Text = "Todos podem iniciar a partida";
            this.chkPermissaoIniciar.UseVisualStyleBackColor = true;
            // 
            // pnlEntrarPartida
            // 
            this.pnlEntrarPartida.Controls.Add(this.lstListarPartidas);
            this.pnlEntrarPartida.Controls.Add(this.btnListarPartidas);
            this.pnlEntrarPartida.Controls.Add(this.btnEntrar);
            this.pnlEntrarPartida.Controls.Add(this.label3);
            this.pnlEntrarPartida.Controls.Add(this.txtUsername);
            this.pnlEntrarPartida.Controls.Add(this.lblUsername);
            this.pnlEntrarPartida.Controls.Add(this.txtNomePartidaEntrar);
            this.pnlEntrarPartida.Controls.Add(this.lblNomePartidaEntrar);
            this.pnlEntrarPartida.Controls.Add(this.lblSenhaEntrar);
            this.pnlEntrarPartida.Controls.Add(this.txtSenhaEntrar);
            this.pnlEntrarPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntrarPartida.Location = new System.Drawing.Point(0, 0);
            this.pnlEntrarPartida.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEntrarPartida.Name = "pnlEntrarPartida";
            this.pnlEntrarPartida.Size = new System.Drawing.Size(1067, 554);
            this.pnlEntrarPartida.TabIndex = 12;
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(27, 303);
            this.btnJogar.Margin = new System.Windows.Forms.Padding(4);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(300, 100);
            this.btnJogar.TabIndex = 22;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click_1);
            // 
            // btnComoJogar
            // 
            this.btnComoJogar.Location = new System.Drawing.Point(352, 303);
            this.btnComoJogar.Margin = new System.Windows.Forms.Padding(4);
            this.btnComoJogar.Name = "btnComoJogar";
            this.btnComoJogar.Size = new System.Drawing.Size(300, 100);
            this.btnComoJogar.TabIndex = 23;
            this.btnComoJogar.Text = "Como jogar";
            this.btnComoJogar.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.Location = new System.Drawing.Point(27, 421);
            this.btnConfiguracoes.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(300, 100);
            this.btnConfiguracoes.TabIndex = 24;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(352, 421);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(300, 100);
            this.btnSair.TabIndex = 25;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // pnlMenuInicial
            // 
            this.pnlMenuInicial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMenuInicial.BackgroundImage")));
            this.pnlMenuInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMenuInicial.Controls.Add(this.btnSair);
            this.pnlMenuInicial.Controls.Add(this.btnConfiguracoes);
            this.pnlMenuInicial.Controls.Add(this.btnComoJogar);
            this.pnlMenuInicial.Controls.Add(this.btnJogar);
            this.pnlMenuInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuInicial.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuInicial.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenuInicial.Name = "pnlMenuInicial";
            this.pnlMenuInicial.Size = new System.Drawing.Size(1067, 554);
            this.pnlMenuInicial.TabIndex = 26;
            // 
            // pnlEscolhaJogar
            // 
            this.pnlEscolhaJogar.Controls.Add(this.btnCriarUmaPartida);
            this.pnlEscolhaJogar.Controls.Add(this.btnEntrarNasPartidas);
            this.pnlEscolhaJogar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEscolhaJogar.Location = new System.Drawing.Point(0, 0);
            this.pnlEscolhaJogar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEscolhaJogar.Name = "pnlEscolhaJogar";
            this.pnlEscolhaJogar.Size = new System.Drawing.Size(1067, 554);
            this.pnlEscolhaJogar.TabIndex = 28;
            // 
            // btnCriarUmaPartida
            // 
            this.btnCriarUmaPartida.Location = new System.Drawing.Point(497, 167);
            this.btnCriarUmaPartida.Margin = new System.Windows.Forms.Padding(4);
            this.btnCriarUmaPartida.Name = "btnCriarUmaPartida";
            this.btnCriarUmaPartida.Size = new System.Drawing.Size(173, 156);
            this.btnCriarUmaPartida.TabIndex = 1;
            this.btnCriarUmaPartida.Text = "Criar partida";
            this.btnCriarUmaPartida.UseVisualStyleBackColor = true;
            this.btnCriarUmaPartida.Click += new System.EventHandler(this.btnCriarUmaPartida_Click);
            // 
            // btnEntrarNasPartidas
            // 
            this.btnEntrarNasPartidas.Location = new System.Drawing.Point(292, 165);
            this.btnEntrarNasPartidas.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrarNasPartidas.Name = "btnEntrarNasPartidas";
            this.btnEntrarNasPartidas.Size = new System.Drawing.Size(197, 160);
            this.btnEntrarNasPartidas.TabIndex = 0;
            this.btnEntrarNasPartidas.Text = "Entrar na partida";
            this.btnEntrarNasPartidas.UseVisualStyleBackColor = true;
            this.btnEntrarNasPartidas.Click += new System.EventHandler(this.btnEntrarNasPartidas_Click);
            // 
            // pnlLobby
            // 
            this.pnlLobby.CausesValidation = false;
            this.pnlLobby.Controls.Add(this.btnIniciar);
            this.pnlLobby.Controls.Add(this.lstJogadores);
            this.pnlLobby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLobby.Location = new System.Drawing.Point(0, 0);
            this.pnlLobby.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLobby.Name = "pnlLobby";
            this.pnlLobby.Size = new System.Drawing.Size(1067, 554);
            this.pnlLobby.TabIndex = 22;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(693, 343);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(159, 60);
            this.btnIniciar.TabIndex = 20;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // pnlPartida
            // 
            this.pnlPartida.Controls.Add(this.lblNomeDaVez);
            this.pnlPartida.Controls.Add(this.lblIdDaVez);
            this.pnlPartida.Controls.Add(this.lblSetor);
            this.pnlPartida.Controls.Add(this.txtSetor);
            this.pnlPartida.Controls.Add(this.btnColocarPersonagem);
            this.pnlPartida.Controls.Add(this.txtPersonagem);
            this.pnlPartida.Controls.Add(this.lstNomePersonagens);
            this.pnlPartida.Controls.Add(this.lblPersonagem);
            this.pnlPartida.Controls.Add(this.btnVerificarVez);
            this.pnlPartida.Controls.Add(this.lstTabuleiro);
            this.pnlPartida.Controls.Add(this.lstCartas);
            this.pnlPartida.Controls.Add(this.btnListarCartas);
            this.pnlPartida.Controls.Add(this.lblSenhaJogador);
            this.pnlPartida.Controls.Add(this.lblIdJogador);
            this.pnlPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPartida.Location = new System.Drawing.Point(0, 0);
            this.pnlPartida.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPartida.Name = "pnlPartida";
            this.pnlPartida.Size = new System.Drawing.Size(1067, 554);
            this.pnlPartida.TabIndex = 15;
            this.pnlPartida.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPartida_Paint);
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(427, 166);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(39, 16);
            this.lblSetor.TabIndex = 13;
            this.lblSetor.Text = "Setor";
            // 
            // txtSetor
            // 
            this.txtSetor.Location = new System.Drawing.Point(430, 187);
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(125, 22);
            this.txtSetor.TabIndex = 12;
            // 
            // btnColocarPersonagem
            // 
            this.btnColocarPersonagem.Location = new System.Drawing.Point(571, 192);
            this.btnColocarPersonagem.Name = "btnColocarPersonagem";
            this.btnColocarPersonagem.Size = new System.Drawing.Size(99, 73);
            this.btnColocarPersonagem.TabIndex = 11;
            this.btnColocarPersonagem.Text = "Colocar Personagem";
            this.btnColocarPersonagem.UseVisualStyleBackColor = true;
            this.btnColocarPersonagem.Click += new System.EventHandler(this.btnColocarPersonagem_Click);
            // 
            // txtPersonagem
            // 
            this.txtPersonagem.Location = new System.Drawing.Point(431, 252);
            this.txtPersonagem.Name = "txtPersonagem";
            this.txtPersonagem.Size = new System.Drawing.Size(124, 22);
            this.txtPersonagem.TabIndex = 10;
            // 
            // lstNomePersonagens
            // 
            this.lstNomePersonagens.FormattingEnabled = true;
            this.lstNomePersonagens.ItemHeight = 16;
            this.lstNomePersonagens.Location = new System.Drawing.Point(751, 85);
            this.lstNomePersonagens.Name = "lstNomePersonagens";
            this.lstNomePersonagens.Size = new System.Drawing.Size(165, 276);
            this.lstNomePersonagens.TabIndex = 8;
            this.lstNomePersonagens.SelectedIndexChanged += new System.EventHandler(this.lstNomePersonagens_SelectedIndexChanged);
            // 
            // lblPersonagem
            // 
            this.lblPersonagem.AutoSize = true;
            this.lblPersonagem.Location = new System.Drawing.Point(432, 234);
            this.lblPersonagem.Name = "lblPersonagem";
            this.lblPersonagem.Size = new System.Drawing.Size(85, 16);
            this.lblPersonagem.TabIndex = 7;
            this.lblPersonagem.Text = "Personagem";
            // 
            // btnVerificarVez
            // 
            this.btnVerificarVez.AccessibleName = "VerificarVez";
            this.btnVerificarVez.Location = new System.Drawing.Point(204, 37);
            this.btnVerificarVez.Name = "btnVerificarVez";
            this.btnVerificarVez.Size = new System.Drawing.Size(105, 27);
            this.btnVerificarVez.TabIndex = 5;
            this.btnVerificarVez.Text = "Verificar a vez";
            this.btnVerificarVez.UseVisualStyleBackColor = true;
            this.btnVerificarVez.Click += new System.EventHandler(this.btnVerificarVez_Click);
            // 
            // lstTabuleiro
            // 
            this.lstTabuleiro.FormattingEnabled = true;
            this.lstTabuleiro.ItemHeight = 16;
            this.lstTabuleiro.Location = new System.Drawing.Point(431, 306);
            this.lstTabuleiro.Name = "lstTabuleiro";
            this.lstTabuleiro.Size = new System.Drawing.Size(221, 196);
            this.lstTabuleiro.TabIndex = 4;
            // 
            // lstCartas
            // 
            this.lstCartas.FormattingEnabled = true;
            this.lstCartas.ItemHeight = 16;
            this.lstCartas.Location = new System.Drawing.Point(4, 342);
            this.lstCartas.Margin = new System.Windows.Forms.Padding(4);
            this.lstCartas.Name = "lstCartas";
            this.lstCartas.Size = new System.Drawing.Size(289, 196);
            this.lstCartas.TabIndex = 3;
            // 
            // btnListarCartas
            // 
            this.btnListarCartas.Location = new System.Drawing.Point(119, 305);
            this.btnListarCartas.Margin = new System.Windows.Forms.Padding(4);
            this.btnListarCartas.Name = "btnListarCartas";
            this.btnListarCartas.Size = new System.Drawing.Size(176, 30);
            this.btnListarCartas.TabIndex = 2;
            this.btnListarCartas.Text = "Listar cartas";
            this.btnListarCartas.UseVisualStyleBackColor = true;
            this.btnListarCartas.Click += new System.EventHandler(this.btnListarCartas_Click);
            // 
            // lblSenhaJogador
            // 
            this.lblSenhaJogador.AutoSize = true;
            this.lblSenhaJogador.Location = new System.Drawing.Point(47, 102);
            this.lblSenhaJogador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenhaJogador.Name = "lblSenhaJogador";
            this.lblSenhaJogador.Size = new System.Drawing.Size(52, 16);
            this.lblSenhaJogador.TabIndex = 1;
            this.lblSenhaJogador.Text = "Senha: ";
            // 
            // lblIdJogador
            // 
            this.lblIdJogador.AutoSize = true;
            this.lblIdJogador.Location = new System.Drawing.Point(47, 75);
            this.lblIdJogador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdJogador.Name = "lblIdJogador";
            this.lblIdJogador.Size = new System.Drawing.Size(24, 16);
            this.lblIdJogador.TabIndex = 0;
            this.lblIdJogador.Text = "Id: ";
            // 
            // lblIdDaVez
            // 
            this.lblIdDaVez.AutoSize = true;
            this.lblIdDaVez.Location = new System.Drawing.Point(327, 42);
            this.lblIdDaVez.Name = "lblIdDaVez";
            this.lblIdDaVez.Size = new System.Drawing.Size(117, 16);
            this.lblIdDaVez.TabIndex = 14;
            this.lblIdDaVez.Text = "Id jogador da vez: ";
            // 
            // lblNomeDaVez
            // 
            this.lblNomeDaVez.AutoSize = true;
            this.lblNomeDaVez.Location = new System.Drawing.Point(510, 42);
            this.lblNomeDaVez.Name = "lblNomeDaVez";
            this.lblNomeDaVez.Size = new System.Drawing.Size(107, 16);
            this.lblNomeDaVez.TabIndex = 15;
            this.lblNomeDaVez.Text = "Jogador da vez: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlPartida);
            this.Controls.Add(this.pnlEntrarPartida);
            this.Controls.Add(this.pnlLobby);
            this.Controls.Add(this.pnlMenuInicial);
            this.Controls.Add(this.lblNomeGrupo);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.pnlCriarPartida);
            this.Controls.Add(this.pnlEscolhaJogar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCriarPartida.ResumeLayout(false);
            this.pnlCriarPartida.PerformLayout();
            this.pnlEntrarPartida.ResumeLayout(false);
            this.pnlEntrarPartida.PerformLayout();
            this.pnlMenuInicial.ResumeLayout(false);
            this.pnlEscolhaJogar.ResumeLayout(false);
            this.pnlLobby.ResumeLayout(false);
            this.pnlPartida.ResumeLayout(false);
            this.pnlPartida.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnListarPartidas;
        private System.Windows.Forms.ListBox lstListarPartidas;
        private System.Windows.Forms.Label lblNomePartida;
        private System.Windows.Forms.TextBox txtNomePartida;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCriarPartida;
        private System.Windows.Forms.TextBox txtNomePartidaEntrar;
        private System.Windows.Forms.Label lblNomePartidaEntrar;
        private System.Windows.Forms.TextBox txtSenhaEntrar;
        private System.Windows.Forms.Label lblSenhaEntrar;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ListBox lstJogadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblNomeGrupo;
        private System.Windows.Forms.Panel pnlCriarPartida;
        private System.Windows.Forms.Panel pnlEntrarPartida;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnComoJogar;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Panel pnlMenuInicial;
        private System.Windows.Forms.Panel pnlEscolhaJogar;
        private System.Windows.Forms.Button btnCriarUmaPartida;
        private System.Windows.Forms.Button btnEntrarNasPartidas;
        private System.Windows.Forms.Panel pnlLobby;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.CheckBox chkPermissaoIniciar;
        private System.Windows.Forms.Panel pnlPartida;
        private System.Windows.Forms.Label lblSenhaJogador;
        private System.Windows.Forms.Label lblIdJogador;
        private System.Windows.Forms.Button btnListarCartas;
        private System.Windows.Forms.ListBox lstCartas;
        private System.Windows.Forms.Button btnVerificarVez;
        private System.Windows.Forms.ListBox lstTabuleiro;
        private System.Windows.Forms.Label lblPersonagem;
        private System.Windows.Forms.TextBox txtPersonagem;
        private System.Windows.Forms.ListBox lstNomePersonagens;
        private System.Windows.Forms.Button btnColocarPersonagem;
        private System.Windows.Forms.TextBox txtSetor;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.Label lblNomeDaVez;
        private System.Windows.Forms.Label lblIdDaVez;
    }
}

