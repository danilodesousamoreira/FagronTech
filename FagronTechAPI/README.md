[FagronTech] - API - { .net } 
===================

API restful para cadastro de clientes.

-------------

Especificações Técnicas
-------------
- **Back-End**: .NET core 3.1

- **Porta default https**: 5001

- **Porta default http**: 5000

- **Swagger**: https://localhost:5001/index.html

- **Conteiner**: Instalar Docker caso não tenha um servidor de banco de dados para importação do script

- **Banco**: SQL SERVER, pasta src/Extras tem script de importação do modelo

------------

## Usando o Docker
### Criando a imagem da aplicação
```
$ docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu
```
Para mais detalhes veja o link:
https://hub.docker.com/_/microsoft-mssql-server

## Observações
### Caso utilize outro servidor diferente de localhost, entre no arquivo appsettings.json e mude as configurações da ConnectionStrings para suas credenciais.

**Desenvolvedor**
  Danilo de Sousa Moreira