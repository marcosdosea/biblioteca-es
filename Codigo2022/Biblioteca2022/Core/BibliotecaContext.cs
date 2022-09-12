using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core
{
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
        public virtual DbSet<Autorlivro> Autorlivros { get; set; }
        public virtual DbSet<Biblioteca> Bibliotecas { get; set; }
        public virtual DbSet<Devolucao> Devolucaos { get; set; }
        public virtual DbSet<Devolucaoitemacervo> Devolucaoitemacervos { get; set; }
        public virtual DbSet<Doacao> Doacaos { get; set; }
        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Emprestimo> Emprestimos { get; set; }
        public virtual DbSet<Emprestimoitemacervo> Emprestimoitemacervos { get; set; }
        public virtual DbSet<Itemacervo> Itemacervos { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Situacaolivro> Situacaolivros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=Biblioteca");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PRIMARY");

                entity.ToTable("autor");

                entity.Property(e => e.IdAutor)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAutor");

                entity.Property(e => e.AnoNascimento)
                    .HasColumnType("date")
                    .HasColumnName("anoNascimento");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Autorlivro>(entity =>
            {
                entity.HasKey(e => new { e.IdAutor, e.IdLivro })
                    .HasName("PRIMARY");

                entity.ToTable("autorlivro");

                entity.HasIndex(e => e.IdAutor, "fk_AutorLivro_Autor1_idx");

                entity.HasIndex(e => e.IdLivro, "fk_AutorLivro_Livro1_idx");

                entity.Property(e => e.IdAutor)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAutor");

                entity.Property(e => e.IdLivro)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idLivro");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Autorlivros)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AutorLivro_Autor1");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.Autorlivros)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AutorLivro_Livro1");
            });

            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.HasKey(e => e.IdBiblioteca)
                    .HasName("PRIMARY");

                entity.ToTable("biblioteca");

                entity.Property(e => e.IdBiblioteca)
                    .HasColumnType("int(11)")
                    .HasColumnName("idBiblioteca");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Devolucao>(entity =>
            {
                entity.HasKey(e => e.IdDevolucao)
                    .HasName("PRIMARY");

                entity.ToTable("devolucao");

                entity.HasIndex(e => e.IdPessoaUsuario, "fk_Devolucao_Pessoa1_idx");

                entity.HasIndex(e => e.IdPessoaBalconista, "fk_Devolucao_Pessoa2_idx");

                entity.Property(e => e.IdDevolucao)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDevolucao");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdPessoaBalconista)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPessoaBalconista");

                entity.Property(e => e.IdPessoaUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPessoaUsuario");

                entity.Property(e => e.Multa)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("multa");

                entity.Property(e => e.ValorPago)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorPago");

                entity.HasOne(d => d.IdPessoaBalconistaNavigation)
                    .WithMany(p => p.DevolucaoIdPessoaBalconistaNavigations)
                    .HasForeignKey(d => d.IdPessoaBalconista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_Pessoa2");

                entity.HasOne(d => d.IdPessoaUsuarioNavigation)
                    .WithMany(p => p.DevolucaoIdPessoaUsuarioNavigations)
                    .HasForeignKey(d => d.IdPessoaUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_Pessoa1");
            });

            modelBuilder.Entity<Devolucaoitemacervo>(entity =>
            {
                entity.HasKey(e => new { e.IdDevolucao, e.IdItemAcervo })
                    .HasName("PRIMARY");

                entity.ToTable("devolucaoitemacervo");

                entity.HasIndex(e => e.IdDevolucao, "fk_Devolucao_has_ItemAcervo_Devolucao1_idx");

                entity.HasIndex(e => e.IdItemAcervo, "fk_Devolucao_has_ItemAcervo_ItemAcervo1_idx");

                entity.Property(e => e.IdDevolucao)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDevolucao");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idItemAcervo");

                entity.HasOne(d => d.IdDevolucaoNavigation)
                    .WithMany(p => p.Devolucaoitemacervos)
                    .HasForeignKey(d => d.IdDevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_has_ItemAcervo_Devolucao1");

                entity.HasOne(d => d.IdItemAcervoNavigation)
                    .WithMany(p => p.Devolucaoitemacervos)
                    .HasForeignKey(d => d.IdItemAcervo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_has_ItemAcervo_ItemAcervo1");
            });

            modelBuilder.Entity<Doacao>(entity =>
            {
                entity.HasKey(e => e.IdDoacao)
                    .HasName("PRIMARY");

                entity.ToTable("doacao");

                entity.Property(e => e.IdDoacao)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDoacao");

                entity.Property(e => e.Data).HasColumnName("data");
            });

            modelBuilder.Entity<Editora>(entity =>
            {
                entity.HasKey(e => e.IdEditora)
                    .HasName("PRIMARY");

                entity.ToTable("editora");

                entity.Property(e => e.IdEditora)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEditora");

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
                    .IsRequired()
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
                entity.HasKey(e => e.IdEmprestimo)
                    .HasName("PRIMARY");

                entity.ToTable("emprestimo");

                entity.HasIndex(e => e.IdPessoaUsuario, "fk_Emprestimo_Pessoa1_idx");

                entity.HasIndex(e => e.IdPessoaBalconista, "fk_Emprestimo_Pessoa2_idx");

                entity.Property(e => e.IdEmprestimo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmprestimo");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdPessoaBalconista)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPessoaBalconista");

                entity.Property(e => e.IdPessoaUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPessoaUsuario");

                entity.HasOne(d => d.IdPessoaBalconistaNavigation)
                    .WithMany(p => p.EmprestimoIdPessoaBalconistaNavigations)
                    .HasForeignKey(d => d.IdPessoaBalconista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Emprestimo_Pessoa2");

                entity.HasOne(d => d.IdPessoaUsuarioNavigation)
                    .WithMany(p => p.EmprestimoIdPessoaUsuarioNavigations)
                    .HasForeignKey(d => d.IdPessoaUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Emprestimo_Pessoa1");
            });

            modelBuilder.Entity<Emprestimoitemacervo>(entity =>
            {
                entity.HasKey(e => new { e.IdItemAcervo, e.IdEmprestimo })
                    .HasName("PRIMARY");

                entity.ToTable("emprestimoitemacervo");

                entity.HasIndex(e => e.IdEmprestimo, "fk_ItemAcervo_has_Emprestimo_Emprestimo1_idx");

                entity.HasIndex(e => e.IdItemAcervo, "fk_ItemAcervo_has_Emprestimo_ItemAcervo1_idx");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idItemAcervo");

                entity.Property(e => e.IdEmprestimo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmprestimo");

                entity.HasOne(d => d.IdEmprestimoNavigation)
                    .WithMany(p => p.Emprestimoitemacervos)
                    .HasForeignKey(d => d.IdEmprestimo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_has_Emprestimo_Emprestimo1");

                entity.HasOne(d => d.IdItemAcervoNavigation)
                    .WithMany(p => p.Emprestimoitemacervos)
                    .HasForeignKey(d => d.IdItemAcervo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_has_Emprestimo_ItemAcervo1");
            });

            modelBuilder.Entity<Itemacervo>(entity =>
            {
                entity.HasKey(e => e.IdItemAcervo)
                    .HasName("PRIMARY");

                entity.ToTable("itemacervo");

                entity.HasIndex(e => e.IdBiblioteca, "fk_ItemAcervo_Biblioteca1_idx");

                entity.HasIndex(e => e.IdDoacao, "fk_ItemAcervo_Doacao1_idx");

                entity.HasIndex(e => e.IdLivro, "fk_ItemAcervo_Livro1_idx");

                entity.HasIndex(e => e.IdSituacaoLivro, "fk_ItemAcervo_SituacaoLivro1_idx");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idItemAcervo");

                entity.Property(e => e.IdBiblioteca)
                    .HasColumnType("int(11)")
                    .HasColumnName("idBiblioteca");

                entity.Property(e => e.IdDoacao)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDoacao");

                entity.Property(e => e.IdLivro)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idLivro");

                entity.Property(e => e.IdSituacaoLivro)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("idSituacaoLivro")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdBibliotecaNavigation)
                    .WithMany(p => p.Itemacervos)
                    .HasForeignKey(d => d.IdBiblioteca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_Biblioteca1");

                entity.HasOne(d => d.IdDoacaoNavigation)
                    .WithMany(p => p.Itemacervos)
                    .HasForeignKey(d => d.IdDoacao)
                    .HasConstraintName("fk_ItemAcervo_Doacao1");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.Itemacervos)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_Livro1");

                entity.HasOne(d => d.IdSituacaoLivroNavigation)
                    .WithMany(p => p.Itemacervos)
                    .HasForeignKey(d => d.IdSituacaoLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_SituacaoLivro1");
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PRIMARY");

                entity.ToTable("livro");

                entity.HasIndex(e => e.IdEditora, "fk_Livro_Editora1_idx");

                entity.HasIndex(e => e.Nome, "idx_nome");

                entity.HasIndex(e => e.Isbn, "isbn_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdLivro)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("idLivro");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnType("date")
                    .HasColumnName("dataPublicacao");

                entity.Property(e => e.IdEditora)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEditora");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("isbn")
                    .IsFixedLength(true);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Resumo)
                    .HasMaxLength(300)
                    .HasColumnName("resumo");

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdEditora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Livro_Editora1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf, "cpf_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPessoa)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPessoa");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(45)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(45)
                    .HasColumnName("cidade");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(45)
                    .HasColumnName("endereco");

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
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.TipoPessoa)
                    .IsRequired()
                    .HasColumnType("enum('U','B','A')")
                    .HasColumnName("tipoPessoa")
                    .HasDefaultValueSql("'U'");
            });

            modelBuilder.Entity<Situacaolivro>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoLivro)
                    .HasName("PRIMARY");

                entity.ToTable("situacaolivro");

                entity.Property(e => e.IdSituacaoLivro)
                    .HasMaxLength(1)
                    .HasColumnName("idSituacaoLivro")
                    .IsFixedLength(true);

                entity.Property(e => e.Situacao)
                    .HasMaxLength(45)
                    .HasColumnName("situacao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
