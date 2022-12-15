create table arquivo (
	id SERIAL primary key, 
	guid uuid,
	datacadastro date,
	dataatualizacao date,
	versaoatual int
)

create table conteudoarquivo (
	id SERIAL primary key, 
	guid uuid,
	datacadastro date,
	dataatualizacao date,
	conteudo bytea,
	hash bytea,
	hashalgoritimo int,
	nome varchar,
	tipo varchar,
	tamanho int
)

create table versaoarquivo (
	id SERIAL primary key, 
	guid uuid,
	datacadastro date,
	dataatualizacao date,
	numeroversao int,
	idarquivo int,
	idconteudoarquivo int,
	constraint fk_versao_arquivo foreign key (idarquivo) references arquivo (id),
	constraint fk_versao_conteudoarquivo foreign key (idconteudoarquivo) references conteudoarquivo (id)
)
