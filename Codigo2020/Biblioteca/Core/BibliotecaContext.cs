using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Autorlivro> Autorlivro { get; set; }
        public virtual DbSet<Biblioteca> Biblioteca { get; set; }
        public virtual DbSet<Devolucao> Devolucao { get; set; }
        public virtual DbSet<Devolucaoitemacervo> Devolucaoitemacervo { get; set; }
        public virtual DbSet<Doacao> Doacao { get; set; }
        public virtual DbSet<Editora> Editora { get; set; }
        public virtual DbSet<Emprestimo> Emprestimo { get; set; }
        public virtual DbSet<Emprestimoitemacervo> Emprestimoitemacervo { get; set; }
        public virtual DbSet<Itemacervo> Itemacervo { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Situacaolivro> Situacaolivro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=Biblioteca");
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
                    .HasColumnName("idAutor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnoNascimento)
                    .HasColumnName("anoNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Autorlivro>(entity =>
            {
                entity.HasKey(e => new { e.IdAutor, e.IdLivro })
                    .HasName("PRIMARY");

                entity.ToTable("autorlivro");

                entity.HasIndex(e => e.IdAutor)
                    .HasName("fk_AutorLivro_Autor1_idx");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("fk_AutorLivro_Livro1_idx");

                entity.Property(e => e.IdAutor)
                    .HasColumnName("idAutor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdLivro)
                    .HasColumnName("idLivro")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Autorlivro)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AutorLivro_Autor1");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.Autorlivro)
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
                    .HasColumnName("idBiblioteca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Devolucao>(entity =>
            {
                entity.HasKey(e => e.IdDevolucao)
                    .HasName("PRIMARY");

                entity.ToTable("devolucao");

                entity.HasIndex(e => e.IdPessoaBalconista)
                    .HasName("fk_Devolucao_Pessoa2_idx");

                entity.HasIndex(e => e.IdPessoaUsuario)
                    .HasName("fk_Devolucao_Pessoa1_idx");

                entity.Property(e => e.IdDevolucao)
                    .HasColumnName("idDevolucao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdPessoaBalconista)
                    .HasColumnName("idPessoaBalconista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPessoaUsuario)
                    .HasColumnName("idPessoaUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Multa)
                    .HasColumnName("multa")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ValorPago)
                    .HasColumnName("valorPago")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdPessoaBalconistaNavigation)
                    .WithMany(p => p.DevolucaoIdPessoaBalconistaNavigation)
                    .HasForeignKey(d => d.IdPessoaBalconista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_Pessoa2");

                entity.HasOne(d => d.IdPessoaUsuarioNavigation)
                    .WithMany(p => p.DevolucaoIdPessoaUsuarioNavigation)
                    .HasForeignKey(d => d.IdPessoaUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_Pessoa1");
            });

            modelBuilder.Entity<Devolucaoitemacervo>(entity =>
            {
                entity.HasKey(e => new { e.IdDevolucao, e.IdItemAcervo })
                    .HasName("PRIMARY");

                entity.ToTable("devolucaoitemacervo");

                entity.HasIndex(e => e.IdDevolucao)
                    .HasName("fk_Devolucao_has_ItemAcervo_Devolucao1_idx");

                entity.HasIndex(e => e.IdItemAcervo)
                    .HasName("fk_Devolucao_has_ItemAcervo_ItemAcervo1_idx");

                entity.Property(e => e.IdDevolucao)
                    .HasColumnName("idDevolucao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnName("idItemAcervo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdDevolucaoNavigation)
                    .WithMany(p => p.Devolucaoitemacervo)
                    .HasForeignKey(d => d.IdDevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_has_ItemAcervo_Devolucao1");

                entity.HasOne(d => d.IdItemAcervoNavigation)
                    .WithMany(p => p.Devolucaoitemacervo)
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
                    .HasColumnName("idDoacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");
            });

            modelBuilder.Entity<Editora>(entity =>
            {
                entity.HasKey(e => e.IdEditora)
                    .HasName("PRIMARY");

                entity.ToTable("editora");

                entity.Property(e => e.IdEditora)
                    .HasColumnName("idEditora")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .HasColumnName("rua")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.IdEmprestimo)
                    .HasName("PRIMARY");

                entity.ToTable("emprestimo");

                entity.HasIndex(e => e.IdPessoaBalconista)
                    .HasName("fk_Emprestimo_Pessoa2_idx");

                entity.HasIndex(e => e.IdPessoaUsuario)
                    .HasName("fk_Emprestimo_Pessoa1_idx");

                entity.Property(e => e.IdEmprestimo)
                    .HasColumnName("idEmprestimo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdPessoaBalconista)
                    .HasColumnName("idPessoaBalconista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPessoaUsuario)
                    .HasColumnName("idPessoaUsuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPessoaBalconistaNavigation)
                    .WithMany(p => p.EmprestimoIdPessoaBalconistaNavigation)
                    .HasForeignKey(d => d.IdPessoaBalconista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Emprestimo_Pessoa2");

                entity.HasOne(d => d.IdPessoaUsuarioNavigation)
                    .WithMany(p => p.EmprestimoIdPessoaUsuarioNavigation)
                    .HasForeignKey(d => d.IdPessoaUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Emprestimo_Pessoa1");
            });

            modelBuilder.Entity<Emprestimoitemacervo>(entity =>
            {
                entity.HasKey(e => new { e.IdItemAcervo, e.IdEmprestimo })
                    .HasName("PRIMARY");

                entity.ToTable("emprestimoitemacervo");

                entity.HasIndex(e => e.IdEmprestimo)
                    .HasName("fk_ItemAcervo_has_Emprestimo_Emprestimo1_idx");

                entity.HasIndex(e => e.IdItemAcervo)
                    .HasName("fk_ItemAcervo_has_Emprestimo_ItemAcervo1_idx");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnName("idItemAcervo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmprestimo)
                    .HasColumnName("idEmprestimo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEmprestimoNavigation)
                    .WithMany(p => p.Emprestimoitemacervo)
                    .HasForeignKey(d => d.IdEmprestimo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_has_Emprestimo_Emprestimo1");

                entity.HasOne(d => d.IdItemAcervoNavigation)
                    .WithMany(p => p.Emprestimoitemacervo)
                    .HasForeignKey(d => d.IdItemAcervo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_has_Emprestimo_ItemAcervo1");
            });

            modelBuilder.Entity<Itemacervo>(entity =>
            {
                entity.HasKey(e => e.IdItemAcervo)
                    .HasName("PRIMARY");

                entity.ToTable("itemacervo");

                entity.HasIndex(e => e.IdBiblioteca)
                    .HasName("fk_ItemAcervo_Biblioteca1_idx");

                entity.HasIndex(e => e.IdDoacao)
                    .HasName("fk_ItemAcervo_Doacao1_idx");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("fk_ItemAcervo_Livro1_idx");

                entity.HasIndex(e => e.IdSituacaoLivro)
                    .HasName("fk_ItemAcervo_SituacaoLivro1_idx");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnName("idItemAcervo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdBiblioteca)
                    .HasColumnName("idBiblioteca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdDoacao)
                    .HasColumnName("idDoacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdLivro)
                    .HasColumnName("idLivro")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdSituacaoLivro)
                    .IsRequired()
                    .HasColumnName("idSituacaoLivro")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.IdBibliotecaNavigation)
                    .WithMany(p => p.Itemacervo)
                    .HasForeignKey(d => d.IdBiblioteca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_Biblioteca1");

                entity.HasOne(d => d.IdDoacaoNavigation)
                    .WithMany(p => p.Itemacervo)
                    .HasForeignKey(d => d.IdDoacao)
                    .HasConstraintName("fk_ItemAcervo_Doacao1");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.Itemacervo)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_Livro1");

                entity.HasOne(d => d.IdSituacaoLivroNavigation)
                    .WithMany(p => p.Itemacervo)
                    .HasForeignKey(d => d.IdSituacaoLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_SituacaoLivro1");
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PRIMARY");

                entity.ToTable("livro");

                entity.HasIndex(e => e.IdEditora)
                    .HasName("fk_Livro_Editora1_idx");

                entity.HasIndex(e => e.Isbn)
                    .HasName("isbn_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("idx_nome");

                entity.Property(e => e.IdLivro)
                    .HasColumnName("idLivro")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnName("dataPublicacao")
                    .HasColumnType("date");

                entity.Property(e => e.IdEditora)
                    .HasColumnName("idEditora")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resumo)
                    .HasColumnName("resumo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Livro)
                    .HasForeignKey(d => d.IdEditora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Livro_Editora1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf)
                    .HasName("cpf_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fone)
                    .HasColumnName("fone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Fone2)
                    .HasColumnName("fone2")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .IsRequired()
                    .HasColumnName("tipoPessoa")
                    .HasColumnType("enum('U','B','A')")
                    .HasDefaultValueSql("'U'");
            });

            modelBuilder.Entity<Situacaolivro>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoLivro)
                    .HasName("PRIMARY");

                entity.ToTable("situacaolivro");

                entity.Property(e => e.IdSituacaoLivro)
                    .HasColumnName("idSituacaoLivro")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
