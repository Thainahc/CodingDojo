/*
Padrão de nomenclatura dos objetos do banco de dados

Nome do banco:
    • Todas as letras em minúsculo
    • Palavras devem ser separadas por “_” (underline)
    • Não pode ultrapassar 30 caracteres
    • Evitar abreviações
    • Evitar preposições
    • Não usar acentuação nem caracteres especiais
    • Deve refletir o propósito da aplicação. Sempre que possível, será o próprio nome da aplicação.
    • Caso a aplicação tenha mais de um banco de dados, serão todos iniciados pelo mesmo prefixo (geralmente o nome da aplicação ou do banco de dados principal) seguido de "_" (underline) e outros termos que identifiquem o propósito de cada banco de dados na aplicação.

Nome da tabela:
    • Todas as letras em minúsculo
    • Palavras devem ser separadas por “_” (underline)
    • Não pode ultrapassar 30 caracteres
    • Evitar abreviações
    • Evitar preposições
    • Não usar acentuação nem caracteres especiais
    • Usar palavras no singular
    • Deve ser intuitivo e refletir exatamente o que ela irá armazenar

Nome da coluna:
    • Todas as letras em minúsculo
    • Palavras devem ser separadas por “_” (underline)
    • Não pode ultrapassar 30 caracteres
    • Evitar abreviações, a não ser que o termo realmente exista no mundo real. Ex: cep, cpf, cnpj.
    • Evitar preposições
    • Não usar acentuação nem caracteres especiais
    • Usar palavras no singular
    • Deve ser intuitivo e refletir exatamente o que ela irá armazenar
    • Colunas que armazenam identificadores "id" devem ter o nome da tabela seguido de "_id" 

Nome do índice:
    • Todas as letras em minúsculo
    • Palavras devem ser separadas por “_” (underline)
    • Não pode ultrapassar 30 caracteres
    • Evitar abreviações
    • Evitar preposições
    • Não usar acentuação nem caracteres especiais
    • No caso de chave primária: “cp_”+<nome da tabela>
    • No caso de chave única: “un_”+<nome da tabela>+”_”+<número sequencial>
    • No caso de chave estrangeira: “ce_”+<nome da tabela>+”_”+<número sequencial>
    • No caso de outras chaves: "ix_"+<nome da tabela>+”_”+<número sequencial>

Valores DEFAULT:
    • integer: 0
    • decimal: 0
    • char: ''
    • varchar: ''
    • date: '1900-01-01'
    • time: '00:00:00'
    • datetime: '1900-01-01 00:00:00'

MÁSCARAS:
    • Não gravar máscaras

Regras gerais para criação dos objetos no banco de dados
    • Não criar as restrições de relacionamentos entre as tabelas. O banco de dados é somente para armazenamento.
    • Todas as colunas devem ser NOT NULL e com valores DEFAULT definido.
    • Não utilize tipo "double", utilize o tipo "decimal"
    • Colunas do tipo "boolean" são colunas do tipo numérico, que receberão 1 ou 0, portanto utilize o tipo "tyneint(1)"
    • Colunas que recebem números devem ser SEMPRE do tipo numérico, nunca do tipo caractere.
    • Todas as exclusões de registros são "exclusões lógicas". Portanto em toda tabela PAI, e somente nela, que houver, na aplicação, exclusão comandada pelo usuário, deverá haver uma coluna para registrar a exclusão do registro.
*/

CREATE DATABASE IF NOT EXISTS `sommuscodingdojo`;
USE `sommuscodingdojo`;

CREATE TABLE IF NOT EXISTS `pessoa`(
	`pessoa_id` int(11) AUTO_INCREMENT,
	`nome` char(50) NOT NULL DEFAULT '',
	`cpf` char(11) NOT NULL DEFAULT '',
	CONSTRAINT `cp_pessoa` PRIMARY KEY(`pessoa_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;