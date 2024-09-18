using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Biblioteca> Bibliotecas { get; set; }

    public virtual DbSet<Devolucao> Devolucaos { get; set; }

    public virtual DbSet<Doacao> Doacaos { get; set; }

    public virtual DbSet<Editora> Editoras { get; set; }

    public virtual DbSet<Emprestimo> Emprestimos { get; set; }

    public virtual DbSet<Itemacervo> Itemacervos { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Situacaoitemacervo> Situacaoitemacervos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("autor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");

            entity.HasMany(d => d.IdLivros).WithMany(p => p.IdAutors)
                .UsingEntity<Dictionary<string, object>>(
                    "Autorlivro",
                    r => r.HasOne<Livro>().WithMany()
                        .HasForeignKey("IdLivro")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_AutorLivro_Livro1"),
                    l => l.HasOne<Autor>().WithMany()
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_AutorLivro_Autor1"),
                    j =>
                    {
                        j.HasKey("IdAutor", "IdLivro").HasName("PRIMARY");
                        j.ToTable("autorlivro");
                        j.HasIndex(new[] { "IdAutor" }, "fk_AutorLivro_Autor1_idx");
                        j.HasIndex(new[] { "IdLivro" }, "fk_AutorLivro_Livro1_idx");
                        j.IndexerProperty<uint>("IdAutor").HasColumnName("idAutor");
                        j.IndexerProperty<uint>("IdLivro").HasColumnName("idLivro");
                    });
        });

        modelBuilder.Entity<Biblioteca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biblioteca");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Devolucao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("devolucao");

            entity.HasIndex(e => e.IdPessoaUsuario, "fk_Devolucao_Pessoa1_idx");

            entity.HasIndex(e => e.IdPessoaBalconista, "fk_Devolucao_Pessoa2_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdPessoaBalconista).HasColumnName("idPessoaBalconista");
            entity.Property(e => e.IdPessoaUsuario).HasColumnName("idPessoaUsuario");
            entity.Property(e => e.Multa)
                .HasPrecision(10)
                .HasColumnName("multa");
            entity.Property(e => e.ValorPago)
                .HasPrecision(10)
                .HasColumnName("valorPago");

            entity.HasOne(d => d.IdPessoaBalconistaNavigation).WithMany(p => p.DevolucaoIdPessoaBalconistaNavigations)
                .HasForeignKey(d => d.IdPessoaBalconista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Devolucao_Pessoa2");

            entity.HasOne(d => d.IdPessoaUsuarioNavigation).WithMany(p => p.DevolucaoIdPessoaUsuarioNavigations)
                .HasForeignKey(d => d.IdPessoaUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Devolucao_Pessoa1");
        });

        modelBuilder.Entity<Doacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("doacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
        });

        modelBuilder.Entity<Editora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("editora");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(30)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(30)
                .HasColumnName("cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(30)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Emprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("emprestimo");

            entity.HasIndex(e => e.IdPessoaUsuario, "fk_Emprestimo_Pessoa1_idx");

            entity.HasIndex(e => e.IdPessoaBalconista, "fk_Emprestimo_Pessoa2_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdPessoaBalconista).HasColumnName("idPessoaBalconista");
            entity.Property(e => e.IdPessoaUsuario).HasColumnName("idPessoaUsuario");

            entity.HasOne(d => d.IdPessoaBalconistaNavigation).WithMany(p => p.EmprestimoIdPessoaBalconistaNavigations)
                .HasForeignKey(d => d.IdPessoaBalconista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Emprestimo_Pessoa2");

            entity.HasOne(d => d.IdPessoaUsuarioNavigation).WithMany(p => p.EmprestimoIdPessoaUsuarioNavigations)
                .HasForeignKey(d => d.IdPessoaUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Emprestimo_Pessoa1");
        });

        modelBuilder.Entity<Itemacervo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itemacervo");

            entity.HasIndex(e => e.IdBiblioteca, "fk_ItemAcervo_Biblioteca1_idx");

            entity.HasIndex(e => e.IdDoacao, "fk_ItemAcervo_Doacao1_idx");

            entity.HasIndex(e => e.IdLivro, "fk_ItemAcervo_Livro1_idx");

            entity.HasIndex(e => e.IdSituacaoItemAcervo, "fk_ItemAcervo_SituacaoItemAcervo1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataAquisicao)
                .HasColumnType("datetime")
                .HasColumnName("dataAquisicao");
            entity.Property(e => e.IdBiblioteca).HasColumnName("idBiblioteca");
            entity.Property(e => e.IdDoacao).HasColumnName("idDoacao");
            entity.Property(e => e.IdLivro).HasColumnName("idLivro");
            entity.Property(e => e.IdSituacaoItemAcervo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("idSituacaoItemAcervo");

            entity.HasOne(d => d.IdBibliotecaNavigation).WithMany(p => p.Itemacervos)
                .HasForeignKey(d => d.IdBiblioteca)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ItemAcervo_Biblioteca1");

            entity.HasOne(d => d.IdDoacaoNavigation).WithMany(p => p.Itemacervos)
                .HasForeignKey(d => d.IdDoacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ItemAcervo_Doacao1");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Itemacervos)
                .HasForeignKey(d => d.IdLivro)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ItemAcervo_Livro1");

            entity.HasOne(d => d.IdSituacaoItemAcervoNavigation).WithMany(p => p.Itemacervos)
                .HasForeignKey(d => d.IdSituacaoItemAcervo)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ItemAcervo_SituacaoItemAcervo1");

            entity.HasMany(d => d.IdDevolucaos).WithMany(p => p.IdItemAcervos)
                .UsingEntity<Dictionary<string, object>>(
                    "Itemacervodevolucao",
                    r => r.HasOne<Devolucao>().WithMany()
                        .HasForeignKey("IdDevolucao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_ItemAcervoDevolucao_Devolucao1"),
                    l => l.HasOne<Itemacervo>().WithMany()
                        .HasForeignKey("IdItemAcervo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_ItemAcervoDevolucao_ItemAcervo1"),
                    j =>
                    {
                        j.HasKey("IdItemAcervo", "IdDevolucao").HasName("PRIMARY");
                        j.ToTable("itemacervodevolucao");
                        j.HasIndex(new[] { "IdDevolucao" }, "fk_ItemAcervoDevolucao_Devolucao1_idx");
                        j.HasIndex(new[] { "IdItemAcervo" }, "fk_ItemAcervoDevolucao_ItemAcervo1_idx");
                        j.IndexerProperty<uint>("IdItemAcervo").HasColumnName("idItemAcervo");
                        j.IndexerProperty<uint>("IdDevolucao").HasColumnName("idDevolucao");
                    });

            entity.HasMany(d => d.IdEmprestimos).WithMany(p => p.IdItemAcervos)
                .UsingEntity<Dictionary<string, object>>(
                    "Itemacervoemprestimo",
                    r => r.HasOne<Emprestimo>().WithMany()
                        .HasForeignKey("IdEmprestimo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_ItemAcervoEmprestimo_Emprestimo1"),
                    l => l.HasOne<Itemacervo>().WithMany()
                        .HasForeignKey("IdItemAcervo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_ItemAcervoEmprestimo_ItemAcervo1"),
                    j =>
                    {
                        j.HasKey("IdItemAcervo", "IdEmprestimo").HasName("PRIMARY");
                        j.ToTable("itemacervoemprestimo");
                        j.HasIndex(new[] { "IdEmprestimo" }, "fk_ItemAcervoEmprestimo_Emprestimo1_idx");
                        j.HasIndex(new[] { "IdItemAcervo" }, "fk_ItemAcervoEmprestimo_ItemAcervo1_idx");
                        j.IndexerProperty<uint>("IdItemAcervo").HasColumnName("idItemAcervo");
                        j.IndexerProperty<uint>("IdEmprestimo").HasColumnName("idEmprestimo");
                    });
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("livro");

            entity.HasIndex(e => e.IdEditora, "fk_Livro_Editora1_idx");

            entity.HasIndex(e => e.Nome, "idx_nome");

            entity.HasIndex(e => e.Isbn, "isbn_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataPublicacao)
                .HasColumnType("date")
                .HasColumnName("dataPublicacao");
            entity.Property(e => e.FotoCapa)
                .HasColumnType("blob")
                .HasColumnName("fotoCapa");
            entity.Property(e => e.IdEditora).HasColumnName("idEditora");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("isbn");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Resumo)
                .HasMaxLength(300)
                .HasColumnName("resumo");

            entity.HasOne(d => d.IdEditoraNavigation).WithMany(p => p.Livros)
                .HasForeignKey(d => d.IdEditora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Livro_Editora1");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Cpf, "cpf_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(45)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Fone)
                .HasMaxLength(12)
                .HasColumnName("fone");
            entity.Property(e => e.Fone2)
                .HasMaxLength(12)
                .HasColumnName("fone2");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(15)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(45)
                .HasColumnName("rua");
            entity.Property(e => e.TipoPessoa)
                .HasDefaultValueSql("'U'")
                .HasColumnType("enum('U','B','A')")
                .HasColumnName("tipoPessoa");
        });

        modelBuilder.Entity<Situacaoitemacervo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("situacaoitemacervo");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Situacao)
                .HasMaxLength(45)
                .HasColumnName("situacao");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
