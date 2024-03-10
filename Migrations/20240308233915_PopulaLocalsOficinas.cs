using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class PopulaLocalsOficinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Locals (Cidade, Bairro) VALUES('Santo André', 'Jardins')");
            migrationBuilder.Sql("INSERT INTO Locals (Cidade, Bairro) VALUES('São Bernardo do Campo', 'Alvarenga')");
            migrationBuilder.Sql("INSERT INTO Locals (Cidade, Bairro) VALUES('São Caetano do Sul', 'Centro')");
            migrationBuilder.Sql("INSERT INTO Locals (Cidade, Bairro) VALUES('São Paulo', 'Vila Mariana')");


            migrationBuilder.Sql("INSERT INTO Oficinas(Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Detail Garage', '(11) 91111-1111', 'detail@detail.com.br', '09511-111', 'Rua Avenida Francisco Martins', '10', '', 'Jardins', 'Santo André', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Envelopa Cars', '(11) 92222-2222', 'envelopa@envelopa.com.br', '09522-222', 'Rua João Doe', '202','', 'Alvarenga', 'São Bernardo do Campo', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Company77', '(11) 93333-3333', 'company@company.com.br', '09533-333', 'Avenida Gusmão', '350','', 'Vila Mariana', 'São Paulo', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('AutoCare', '(11) 94444-4444', 'autoCare@autoCare.com.br', '09544-444', 'Avenida Ribeiro do Vale', '230','', 'Jardins', 'Santo André', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Clean Cars', '(11) 95555-5555', 'cleancars@cleancars.com.br', '09555-555', 'Rua Joanin', '10','', 'Centro', 'São Caetano do Sul', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Guaraú Clean', '(11) 96666-6666', 'guarauclean@guarauclean.com.br', '09566-666', 'Avenida Iguaçu', '650','', 'Alvarenga', 'São Bernardo do Campo', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Rochinha ', '(11) 97777-7777', 'rochinha@rochinha.com.br', '09577-777', 'Rua Amoreira', '380','', 'Jardins', 'Santo André', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Barça LimpaCar', '(11) 98888-8888', 'company@company.com.br', '09588-888', 'Avenida Gusmão', '4580','', 'Vila Mariana', 'São Paulo', 'SP')");

            migrationBuilder.Sql("INSERT INTO Oficinas (Nome, Telefone, Email, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('Ouro Preto', '(11) 99999-9999', 'ourobranco@ourobranco.com.br', '09599-999', 'Avenida do Ourives', '860','', 'Centro', 'São Caetano do Sul', 'SP')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Locals");

            migrationBuilder.Sql("DELETE FROM Oficinas ");
        }
    }
}


