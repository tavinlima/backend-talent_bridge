<h1 align="center">Talent Bridge - Backend</h1>
<p align="center"><i>Repositorio para versionamento e documentação do backend do projeto Talent Bridge.</i></p>


##  About this project

Talent Bridge tem a proposta de ser uma plataforma de recrutamento e seleção, nesse repositório você encontra o backend da solução.

Esta API REST construída em C# com .net 9 fornece uma interface para interagir com um banco de dados SQL Server, permitindo realizar operações de criação, leitura, atualização e exclusão (CRUD) em dados relacionados a processo de seleção e recrutamento das empresas e candidatos cadastrados.

### Technologies
<div justify-content=center>
  
  ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
  ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

  ![SQLServer](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
  
  ![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
  ![Render](https://img.shields.io/badge/Render-%46E3B7.svg?style=for-the-badge&logo=render&logoColor=white)
</p>
                                                                                                  
### Development Tools

<p display="inline-block">
  <img width="48" src="https://static.wikia.nocookie.net/logopedia/images/e/ec/Microsoft_Visual_Studio_2022.svg" alt="vs-logo"/>
</p>

<h3> Pre requisites </h3>

<p>Para rodar esse projeto, você precisa ter os seguintes componentes instalados: </p>
<ul>
  <li>.Net 9</li>
  <li>Visual Studio 2022</li>
  <li>SQL Server</li>
</ul>

## Features
<h3>Funcionalidades desenvolvidas para esse projeto: </h3>

<h4>Usuários (funcionalidades compartilhadas entre candidatos e empresas)</h4>
<ul>
  <li>Listagem de todos os usuários</li>
  <li>Deletar usuário específico - exclusivo para usuários autenticados</li>
  <li>Login</li>
</ul>

<h4>Candidatos</h4>
<ul>
  <li>Cadastro de candidatos (com criptografia de senha)</li>
  <li>Atualização de dados</li>
  <li>Listagem de todos os candidatos cadastrados</li>
  <li>Busca de um candidato por CPF</li>
  <li>Cadastro de skills - exclusivo para candidatos autenticados</li>
</ul>

<h4>Empresas</h4>
<ul>
  <li>Cadastro de empresa (com criptografia de senha)</li>
  <li>Atualização de dados</li>
  <li>Listagem de todos as empresas cadastradas</li>
  <li>Busca de uma empresa por CNPJ</li>
</ul>

<h4>Vagas</h4>
<ul>
  <li>Listagem de todas as vagas</li>
</ul>

<h4>Aplicação (candidatura)</h4>
<ul>
  <li>Se candidatar - exclusivo para candidatos autenticados</li>
</ul>

## Running
### Hosting
Caso não queria clonar o repositório na sua máquina, a API pode ser facilmente acessada pelo link: https://backend-talent-bridge-kbiu.onrender.com/swagger/index.html Após acesso, pode pular direto para a sessão [Hands On](#Hands-on)

O passo a seguir não é necessário caso acesse a API pelo link, porém caso queria baixar o repositório, siga as instruções abaixo:
### Como executar:
- O primeiro passo é clonar esse repositório na sua máquina. Dê um git clone em uma pasta do seu computador e puxe todo o conteúdo do repositório.
- Comando a ser inserido: git clone https://github.com/tavinlima/backend-talent_bridge.git

![image](https://github.com/user-attachments/assets/be78ae9b-b603-46d2-9f48-2df63c1a48f0)
![image](https://github.com/user-attachments/assets/8912cec1-ccfd-4e38-8009-f8e762e286e8)


- Abra o Visual Studio na solução que se encontra na pasta 'backend-talent_bridge' -> 'TalentBridge_webAPI';
![image](https://github.com/user-attachments/assets/6cee51e0-3a5c-46db-96a6-96fbf1e93223)


- Entre na aba 'Ferramentas' -> Gerenciador de pacotes do NuGet -> Console do Gerenciador de Pacotes
![image](https://user-images.githubusercontent.com/82414372/183323078-edf24338-f249-43bf-ae87-3b72bfb1f2aa.png)

Digite o comando para criar o banco dentro da sua máquina:
- update-database


Para não sobrecarregar o processamento, feche a aplicação e a partir da barra de endereço da pasta onde se encontram os aquivos, abra o cmd e digite 'dotnet run' no console aberto.

![image](https://github.com/user-attachments/assets/93ace113-a675-45cb-bdc1-b2e5dd02c440)

![image](https://github.com/user-attachments/assets/840f571c-4aca-4b1b-a56c-4b3842501a5d)

![image](https://github.com/user-attachments/assets/1d102a14-ec81-4f22-9125-c664855cc39f)

![image](https://github.com/user-attachments/assets/708e819b-5ccf-4e34-948f-dd7d47c89de2)

Tudo Ok! Vamos ao Swagger da aplicação:
![image](https://github.com/user-attachments/assets/4be9e7cd-7b97-4c37-8eb0-a58b6e348664)

# Hands-on

- Funcionalidades de empresa:
#### Cadastra a empresa no banco de dados

```http
  POST /api/Empresa
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `CNPJ` | `string` | **Obrigatório**. CNPJ da empresa. |
| `Descricao` | `string` | **Obrigatório**. Breve descrição da empresa e/ou atividades |
| `Usuario.Nome` | `string` | **Obrigatório**. Nome da empresa |
| `Usuario.Email` | `string` | **Obrigatório**. E-mail da empresa |
| `Usuario.Senha` | `string` | **Obrigatório**. Senha para autenticação |
| `Usuario.Logradouro` | `string` | **Obrigatório**. Rua em que localiza a empresa |
| `Usuario.NumEnder` | `string` | **Obrigatório**. Número do local da empresa |
| `Usuario.Complemento` | `string` | **Opcional**. Complemento do local da empresa |
| `Usuario.Bairro` | `string` | **Obrigatório**. Bairro em que se localiza a empresa |
| `Usuario.Cidade` | `string` | **Obrigatório**. Cidade em que se localiza a empresa |
| `Usuario.UF` | `string` | **Obrigatório**. Estado em que se localiza a empresa (ex: SP) |
| `Usuario.Cep` | `string` | **Obrigatório**. CEP em que se localiza a empresa (max 8 caracteres) |
| `Usuario.Pais` | `string` | **Obrigatório**. País em que se localiza a empresa |
| `Usuario.TipoEndereco` | `string` | **Obrigatório**. Tipo de endereço da empresa (ex: condominio) |
| `Usuario.TipoContato` | `string` | **Obrigatório**. Qual o contato a ser cadastrado, ex: wahtsapp, principal etc. |
| `Usuario.NumContato` | `string` | **Obrigatório**. O número do contato ex: '11999999999' |

#### Login na aplicação
Realize o login para utilizar as outras funcionalidades do CRUD de empresas
```http
  POST /api/Login
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `email` | `string` | **Obrigatório**. E-mail cadastrado para autenticação. |
| `senha` | `string` | **Obrigatório**. Senha cadastrada para autenticação |

![image](https://github.com/user-attachments/assets/da4a4123-7f59-457f-a98b-8926b62cc3ca)

Resposta:
200: 
```bash
"$id": "1",
"tokenGerado": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InJlY3J1dGFtZW50b0B0eHRjLmNvbSIsIm5hbWUiOiJUWFQgQ3JpYcOnw7VlcyIsImp0aSI6IjEwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiZW1wcmVzYSIsInJvbGUiOiJlbXByZXNhIiwiZXhwIjoxNzM4ODkwMDk5LCJpc3MiOiJ0YWxlbnRicmlkZ2Vfd2ViYXBpIiwiYXVkIjoidGFsZW50YnJpZGdlX3dlYmFwaSJ9.ePFjWfMkKclBbCzpUgu-piM1bF2kb9HiU6x9Cr5YNyA"
```
Caso usuário inválido ou inexistente:
404:
```bash
"E-mail ou senha inválidos!"
```

Copie o token gerado e cole no campo "Authorize" presente no topo da aplicação, com isso você poderá utilizar os métodos que são necessários de autenticação de acordo com o tipo de perfil.
![image](https://github.com/user-attachments/assets/a5ddd417-cd0c-4e35-929b-c755eea417df)
![image](https://github.com/user-attachments/assets/ab517c34-3335-4095-af48-2cfc86a27547)

#### Retorna todas as empresas cadastradas no banco de dados

```http
  GET /api/Empresa/
```

```bash
  {
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "cnpj": "56789012345678",
      "idUsuario": 10,
      "descricao": "Serviços de TI",
      "avaliacao": 2.9,
      "idUsuarioNavigation": {
        "$id": "3",
        "idUsuario": 10,
        "idEndereco": 10,
        "idContato": 10,
        "nome": "TXT Criações",
        "email": "recrutamento@txtc.com",
        "senha": "criptografada",
        "fotoPerfil": null,
        "candidatos": {
          "$id": "4",
          "$values": []
        },
        "empresas": {
          "$id": "5",
          "$values": [
            {
              "$ref": "2"
            }
          ]
        },
        "idContatoNavigation": {
          "$id": "6",
          "idContato": 10,
          "tipoContato": "Telefone principal",
          "numero": "+5511976543880",
          "usuarios": {
            "$id": "7",
            "$values": [
              {
                "$ref": "3"
              }
            ]
          }
        },
        "idEnderecoNavigation": {
          "$id": "8",
          "idEndereco": 10,
          "logradouro": "Alameda Santos",
          "numero": "1254",
          "complemento": "Conjunto 701",
          "bairro": "Jardins",
          "cidade": "São Paulo",
          "estado": "SP",
          "cep": "01418200",
          "pais": "Brasil",
          "tipoEndereco": "Comercial",
          "usuarios": {
            "$id": "9",
            "$values": [
              {
                "$ref": "3"
              }
            ]
          }
        }
      },
      "vagas": {
        "$id": "10",
        "$values": []
      }
    }
  ]

```
#### Atualiza os dados da empresa no banco de dados

```http
  PUT /api/Empresa
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `CNPJ` | `string` | **Obrigatório**. CNPJ da empresa. |
| `Descricao` | `string` | **Obrigatório**. Breve descrição da empresa e/ou atividades |
| `Usuario.Nome` | `string` | **Obrigatório**. Nome da empresa |
| `Usuario.Email` | `string` | **Obrigatório**. E-mail da empresa |
| `Usuario.Senha` | `string` | **Obrigatório**. Senha para autenticação |
| `Usuario.Logradouro` | `string` | **Obrigatório**. Rua em que localiza a empresa |
| `Usuario.NumEnder` | `string` | **Obrigatório**. Número do local da empresa |
| `Usuario.Complemento` | `string` | **Opcional**. Complemento do local da empresa |
| `Usuario.Bairro` | `string` | **Obrigatório**. Bairro em que se localiza a empresa |
| `Usuario.Cidade` | `string` | **Obrigatório**. Cidade em que se localiza a empresa |
| `Usuario.UF` | `string` | **Obrigatório**. Estado em que se localiza a empresa (ex: SP) |
| `Usuario.Cep` | `string` | **Obrigatório**. CEP em que se localiza a empresa (max 8 caracteres) |
| `Usuario.Pais` | `string` | **Obrigatório**. País em que se localiza a empresa |
| `Usuario.TipoEndereco` | `string` | **Obrigatório**. Tipo de endereço da empresa (ex: condominio) |
| `Usuario.TipoContato` | `string` | **Obrigatório**. Qual o contato a ser cadastrado, ex: wahtsapp, principal etc. |
| `Usuario.NumContato` | `string` | **Obrigatório**. O número do contato ex: '11999999999' |

#### Busca uma empresa específica pelo CNPJ
```http
  GET /api/Empresa/{cnpj}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cnpj`      | `string` | **Obrigatório**. CNPJ da empresa que será listada |

```bash
  {
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "cnpj": "56789012345678",
      "idUsuario": 10,
      "descricao": "Serviços de TI",
      "avaliacao": 2.9,
      "idUsuarioNavigation": {
        "$id": "3",
        "idUsuario": 10,
        "idEndereco": 10,
        "idContato": 10,
        "nome": "TXT Criações",
        "email": "recrutamento@txtc.com",
        "senha": "criptografada",
        "fotoPerfil": null,
        "candidatos": {
          "$id": "4",
          "$values": []
        },
        "empresas": {
          "$id": "5",
          "$values": [
            {
              "$ref": "2"
            }
          ]
        },
        "idContatoNavigation": {
          "$id": "6",
          "idContato": 10,
          "tipoContato": "Telefone principal",
          "numero": "+5511976543880",
          "usuarios": {
            "$id": "7",
            "$values": [
              {
                "$ref": "3"
              }
            ]
          }
        },
        "idEnderecoNavigation": {
          "$id": "8",
          "idEndereco": 10,
          "logradouro": "Alameda Santos",
          "numero": "1254",
          "complemento": "Conjunto 701",
          "bairro": "Jardins",
          "cidade": "São Paulo",
          "estado": "SP",
          "cep": "01418200",
          "pais": "Brasil",
          "tipoEndereco": "Comercial",
          "usuarios": {
            "$id": "9",
            "$values": [
              {
                "$ref": "3"
              }
            ]
          }
        }
      },
      "vagas": {
        "$id": "10",
        "$values": []
      }
    }
  ]

```
- Funcionalidades de candidato:

#### Cadastra o candidato no banco de dados

```http
  POST /api/Candidato
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `CPF` | `string` | **Obrigatório**. CPF do candidato. |
| `Data de nascimento` | `string` | **Obrigatório**. Data de nascimento do candidato |
| `Usuario.Nome` | `string` | **Obrigatório**. Nome completo do candidato |
| `Usuario.Email` | `string` | **Obrigatório**. E-mail do candidato |
| `Usuario.Senha` | `string` | **Obrigatório**. Senha para autenticação|
| `Usuario.Logradouro` | `string` | **Obrigatório**. Rua em que localiza o candidato|
| `Usuario.NumEnder` | `string` | **Obrigatório**. Número do local do candidato|
| `Usuario.Complemento` | `string` | **Opcional**. Complemento do local do candidato |
| `Usuario.Bairro` | `string` | **Obrigatório**. Bairro em que se localiza o candidato |
| `Usuario.Cidade` | `string` | **Obrigatório**. Cidade em que se localiza o candidato |
| `Usuario.UF` | `string` | **Obrigatório**. Estado em que se localiza o candidato (ex: SP) |
| `Usuario.Cep` | `string` | **Obrigatório**. CEP em que se localiza o candidato (max 8 caracteres) |
| `Usuario.Pais` | `string` | **Obrigatório**. País em que se localiza a empresa |
| `Usuario.TipoEndereco` | `string` | **Obrigatório**. Tipo de endereço do candidato (ex: condominio) |
| `Usuario.TipoContato` | `string` | **Obrigatório**. Qual o contato a ser cadastrado, ex: wahtsapp, principal etc. |
| `Usuario.NumContato` | `string` | **Obrigatório**. O número do contato ex: '11999999999' |

#### Login na aplicação
Realize o login para utilizar as outras funcionalidades do CRUD de candidato
```http
  POST /api/Login
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `email` | `string` | **Obrigatório**. E-mail cadastrado para autenticação. |
| `senha` | `string` | **Obrigatório**. Senha cadastrada para autenticação |

![image](https://github.com/user-attachments/assets/da4a4123-7f59-457f-a98b-8926b62cc3ca)

Resposta:
200: 
```bash
"$id": "1",
"tokenGerado": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InJlY3J1dGFtZW50b0B0eHRjLmNvbSIsIm5hbWUiOiJUWFQgQ3JpYcOnw7VlcyIsImp0aSI6IjEwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiZW1wcmVzYSIsInJvbGUiOiJlbXByZXNhIiwiZXhwIjoxNzM4ODkwMDk5LCJpc3MiOiJ0YWxlbnRicmlkZ2Vfd2ViYXBpIiwiYXVkIjoidGFsZW50YnJpZGdlX3dlYmFwaSJ9.ePFjWfMkKclBbCzpUgu-piM1bF2kb9HiU6x9Cr5YNyA"
```
Caso usuário inválido ou inexistente:
404:
```bash
"E-mail ou senha inválidos!"
```

Copie o token gerado e cole no campo "Authorize" presente no topo da aplicação, com isso você poderá utilizar os métodos que são necessários de autenticação de acordo com o tipo de perfil.
![image](https://github.com/user-attachments/assets/a5ddd417-cd0c-4e35-929b-c755eea417df)
![image](https://github.com/user-attachments/assets/ab517c34-3335-4095-af48-2cfc86a27547)

#### Retorna todas os candidatos cadastrados no banco de dados

```http
  GET /api/Candidato/
```

```bash
  {
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "idUsuario": 22,
      "cpf": "23456789012",
      "dataNascimento": "1992-04-10",
      "aplicacos": {
        "$id": "3",
        "$values": []
      },
      "certificacaos": {
        "$id": "4",
        "$values": []
      },
      "escolaridades": {
        "$id": "5",
        "$values": []
      },
      "experiencia": {
        "$id": "6",
        "$values": []
      },
      "idUsuarioNavigation": {
        "$id": "7",
        "idUsuario": 22,
        "idEndereco": 5,
        "idContato": 5,
        "nome": "Roberto Costa",
        "email": "roberto.costa@email.com",
        "senha": "123",
        "fotoPerfil": null,
        "candidatos": {
          "$id": "8",
          "$values": [
            {
              "$ref": "2"
            }
          ]
        },
        "empresas": {
          "$id": "9",
          "$values": []
        },
        "idContatoNavigation": {
          "$id": "10",
          "idContato": 5,
          "tipoContato": "Residencial",
          "numero": "+5528999999999",
          "usuarios": {
            "$id": "11",
            "$values": [
              {
                "$ref": "7"
              }
            ]
          }
        },
        "idEnderecoNavigation": {
          "$id": "12",
          "idEndereco": 5,
          "logradouro": "Avenida Paulista",
          "numero": "1000",
          "complemento": "Sala 1204",
          "bairro": "Bela Vista",
          "cidade": "São Paulo",
          "estado": "SP",
          "cep": "01310100",
          "pais": "Brasil",
          "tipoEndereco": "Comercial",
          "usuarios": {
            "$id": "13",
            "$values": [
              {
                "$ref": "7"
              }
            ]
          }
        }
      },
      "idiomas": {
        "$id": "14",
        "$values": []
      },
      "projetos": {
        "$id": "15",
        "$values": []
      },
      "skills": {
        "$id": "16",
        "$values": []
      }
    }
  ]
}

```
#### Atualiza os dados do candidato no banco de dados

```http
  PUT /api/Candidato
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `CPF` | `string` | **Obrigatório**. CPF do candidato. |
| `Data de nascimento` | `string` | **Obrigatório**. Data de nascimento do candidato |
| `Usuario.Nome` | `string` | **Obrigatório**. Nome completo do candidato |
| `Usuario.Email` | `string` | **Obrigatório**. E-mail do candidato |
| `Usuario.Senha` | `string` | **Obrigatório**. Senha para autenticação|
| `Usuario.Logradouro` | `string` | **Obrigatório**. Rua em que localiza o candidato|
| `Usuario.NumEnder` | `string` | **Obrigatório**. Número do local do candidato|
| `Usuario.Complemento` | `string` | **Opcional**. Complemento do local do candidato |
| `Usuario.Bairro` | `string` | **Obrigatório**. Bairro em que se localiza o candidato |
| `Usuario.Cidade` | `string` | **Obrigatório**. Cidade em que se localiza o candidato |
| `Usuario.UF` | `string` | **Obrigatório**. Estado em que se localiza o candidato (ex: SP) |
| `Usuario.Cep` | `string` | **Obrigatório**. CEP em que se localiza o candidato (max 8 caracteres) |
| `Usuario.Pais` | `string` | **Obrigatório**. País em que se localiza a empresa |
| `Usuario.TipoEndereco` | `string` | **Obrigatório**. Tipo de endereço do candidato (ex: condominio) |
| `Usuario.TipoContato` | `string` | **Obrigatório**. Qual o contato a ser cadastrado, ex: wahtsapp, principal etc. |
| `Usuario.NumContato` | `string` | **Obrigatório**. O número do contato ex: '11999999999' |

#### Busca um candidato específico pelo CPF
```http
  GET /api/Candidato/{cpf}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cpf`      | `string` | **Obrigatório**. CPF do candidato que será listada |

```bash
  {
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "idUsuario": 22,
      "cpf": "23456789012",
      "dataNascimento": "1992-04-10",
      "aplicacos": {
        "$id": "3",
        "$values": []
      },
      "certificacaos": {
        "$id": "4",
        "$values": []
      },
      "escolaridades": {
        "$id": "5",
        "$values": []
      },
      "experiencia": {
        "$id": "6",
        "$values": []
      },
      "idUsuarioNavigation": {
        "$id": "7",
        "idUsuario": 22,
        "idEndereco": 5,
        "idContato": 5,
        "nome": "Roberto Costa",
        "email": "roberto.costa@email.com",
        "senha": "123",
        "fotoPerfil": null,
        "candidatos": {
          "$id": "8",
          "$values": [
            {
              "$ref": "2"
            }
          ]
        },
        "empresas": {
          "$id": "9",
          "$values": []
        },
        "idContatoNavigation": {
          "$id": "10",
          "idContato": 5,
          "tipoContato": "Residencial",
          "numero": "+5528999999999",
          "usuarios": {
            "$id": "11",
            "$values": [
              {
                "$ref": "7"
              }
            ]
          }
        },
        "idEnderecoNavigation": {
          "$id": "12",
          "idEndereco": 5,
          "logradouro": "Avenida Paulista",
          "numero": "1000",
          "complemento": "Sala 1204",
          "bairro": "Bela Vista",
          "cidade": "São Paulo",
          "estado": "SP",
          "cep": "01310100",
          "pais": "Brasil",
          "tipoEndereco": "Comercial",
          "usuarios": {
            "$id": "13",
            "$values": [
              {
                "$ref": "7"
              }
            ]
          }
        }
      },
      "idiomas": {
        "$id": "14",
        "$values": []
      },
      "projetos": {
        "$id": "15",
        "$values": []
      },
      "skills": {
        "$id": "16",
        "$values": []
      }
    }
  ]
}

```

#### Excluir um usuário do banco de dados (tanto candidatos quanto empresas)

```http
  DELETE /api/Usuarios
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `email` | `string` | **Obrigatório**. E-mail do candidato |

Caso o usuário exista:

Response 200:
```bash
Usuário excluído com sucesso!
```
