<h3>This Project Contains a DataBase</h3>
<h2>Create DataBase</h2>

CREATE TABLE Login(
Id UNIQUEIDENTIFIER PRIMARY KEY,
Email VARCHAR(100)  NOT NULL,
Password VARCHAR(50)  NOT NULL,
Role VARCHAR(15)  NOT NULL,
StateCode BIT NOT NULL,
CreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
ModifiedOn DATETIME NOT NULL
)

CREATE TABLE Usuario (
Id UNIQUEIDENTIFIER PRIMARY KEY,
Login_id UNIQUEIDENTIFIER  NOT NULL UNIQUE REFERENCES Login(id) ON DELETE CASCADE,
Nome VARCHAR(150) NOT NULL,
Cpf CHAR(11) UNIQUE,
Data_nascimento DATE,
Telefone VARCHAR(20),
Cidade VARCHAR(100),
Estado CHAR(2),
Curriculo_url VARCHAR(500),
Resumo NVARCHAR(MAX),
CreatedOn DATETIME2 NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Empresa (
    Id          UNIQUEIDENTIFIER PRIMARY KEY,
    Login_id    UNIQUEIDENTIFIER NOT NULL UNIQUE REFERENCES Login(id) ON DELETE CASCADE,
    Nome        VARCHAR(200)  NOT NULL,
    Cnpj        CHAR(14)      UNIQUE,
    Setor       VARCHAR(100),
    Cidade      VARCHAR(100),
    Estado      CHAR(2),
    Site        VARCHAR(300),
    Descricao   NVARCHAR(MAX),
    Logo_url    VARCHAR(500),
    CreatedOn  DATETIME2     NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Categoria (
    id     UNIQUEIDENTIFIER PRIMARY KEY,
    nome   VARCHAR(100) NOT NULL UNIQUE,
    slug   VARCHAR(100) NOT NULL UNIQUE,
    icone  VARCHAR(100)
);

CREATE TABLE Vaga (
    Id              UNIQUEIDENTIFIER PRIMARY KEY,
    Empresa_id      UNIQUEIDENTIFIER  NOT NULL REFERENCES Empresa(id) ON DELETE CASCADE,
    Categoria_id    UNIQUEIDENTIFIER   REFERENCES Categoria(id) ON DELETE SET NULL,
    Titulo          VARCHAR(200)   NOT NULL,
    Descricao       NVARCHAR(MAX)  NOT NULL,
    Tipo_contrato   VARCHAR(30)    NOT NULL,
    Modalidade      VARCHAR(20)    NOT NULL,
    Salario_min     DECIMAL(10,2),
    Salario_max     DECIMAL(10,2),
    Cidade          VARCHAR(100),
    Estado          CHAR(2),
    Ativa           BIT            NOT NULL DEFAULT 1,
    ExpiraOn       DATETIME2,
    CreatedOn      DATETIME2      NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Candidatura (
    Id                 UNIQUEIDENTIFIER PRIMARY KEY,
    Usuario_id         UNIQUEIDENTIFIER  NOT NULL REFERENCES Usuario(id),
    Vaga_id            UNIQUEIDENTIFIER  NOT NULL REFERENCES Vaga(id),
    Status             VARCHAR(30)    NOT NULL DEFAULT 'pendente',
    Carta_apresentacao NVARCHAR(MAX),
    CreatedOn         DATETIME2      NOT NULL DEFAULT GETDATE(),
    UpdatedOn         DATETIME2      NOT NULL DEFAULT GETDATE(),
    UNIQUE (usuario_id, vaga_id)  
);


