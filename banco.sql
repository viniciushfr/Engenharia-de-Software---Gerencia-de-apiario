Create Table Cliente (
	idCliente int identity(1,1),
	nomeUsuario varchar(100) not null,
	cpf varchar(20) not null,
	tipoUsuario  bit not null,
	telefone varchar(30) not null,
	nome varchar(100) not null,
	cidade varchar(100)not null,
	estado varchar(100)not null,
	idade int not null,
	
	constraint pkCliente primary key(idCliente)
	
);

Create Table Administrador(
	idAdministrador int identity(1,1),
	nomeUsuario varchar(100) not null,
	cpf varchar(20) not null,
	tipoUsuario  bit not null,
	telefone varchar(30) not null,
	nome varchar(100) not null,
	
	constraint pkAdministrador primary key(idAdministrador)
);

Create Table Atendimento(
	idAtendimento int identity(1,1),
	id Cliente int not null,
	assunto varchar(100) not null,
	mensagem varchar(255)not null,
	situacao varchar(100)not null,
	dataAtendimento datetime not null,
	
	constraint pkAtendimento primary key(idAtendimento),
	foreign key(idCliente) references Cliente(idCliente)
	
);

Create Table Apiario(
	idApiario int identity(1,1),
	idCliente int not null,
	localizacao varchar(255) not null,
	quantasVezes int not null,
	hora time not null,
	
	constraint pkApiario primary key(idApiario),
	foreign key(idCliente) references Cliente(idCliente)
);

Create Table DadosApiario(
	idDados int identity(1,1),
	idApiario int not null,
	temperatura varchar(100) not null,
	umidade vachar(100),
	dataDadosApiario datetime not null,
	
	constraint pkDadosApiario primary key(idDados),
	foreign key(idApiario) references Apiario(idApiario)
	
);

Create Table Caixa(
	idCaixa int identity(1,1),
	situacao varchar(255) not null,
	conexao bit not null,
	constraint pkCaixa primary key(idCaixa)
	
);

Create Table DadosCaixa(
	idDadosCaixa int identity(1,1),
	idCaixa int not null,
	peso float not null,
	fluxoAbelhas double not null,
	dataDadosCaixa datetime not null,
	
	constraint pkDadosCaixa primary key(idDadosCaixa),
	foreign key(idCaixa) references (idCaixa)
	
);