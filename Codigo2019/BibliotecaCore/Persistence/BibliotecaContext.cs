using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence
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

        public virtual DbSet<TbAutor> TbAutor { get; set; }
        public virtual DbSet<TbBiblioteca> TbBiblioteca { get; set; }
        public virtual DbSet<TbCartaobiblioteca> TbCartaobiblioteca { get; set; }
        public virtual DbSet<TbDevolucao> TbDevolucao { get; set; }
        public virtual DbSet<TbDevolucaoitemacervo> TbDevolucaoitemacervo { get; set; }
        public virtual DbSet<TbDoacao> TbDoacao { get; set; }
        public virtual DbSet<TbEditora> TbEditora { get; set; }
        public virtual DbSet<TbEmprestimo> TbEmprestimo { get; set; }
        public virtual DbSet<TbEmprestimoitemacervo> TbEmprestimoitemacervo { get; set; }
        public virtual DbSet<TbItemacervo> TbItemacervo { get; set; }
        public virtual DbSet<TbLivro> TbLivro { get; set; }
        public virtual DbSet<TbLivroautor> TbLivroautor { get; set; }
        public virtual DbSet<TbSituacaolivro> TbSituacaolivro { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			//if (!optionsBuilder.IsConfigured)
			// {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=Biblioteca");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TbAutor>(entity =>
            {
                entity.HasKey(e => e.IdAutor);

                entity.ToTable("tb_autor", "biblioteca");

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

            modelBuilder.Entity<TbBiblioteca>(entity =>
            {
                entity.HasKey(e => e.IdBiblioteca);

                entity.ToTable("tb_biblioteca", "biblioteca");

                entity.Property(e => e.IdBiblioteca)
                    .HasColumnName("idBiblioteca")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCartaobiblioteca>(entity =>
            {
                entity.HasKey(e => e.IdCartaoBiblioteca);

                entity.ToTable("tb_cartaobiblioteca", "biblioteca");

                entity.Property(e => e.IdCartaoBiblioteca)
                    .HasColumnName("idCartaoBiblioteca")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Validade).HasColumnName("validade");
            });

            modelBuilder.Entity<TbDevolucao>(entity =>
            {
                entity.HasKey(e => e.IdDevolucao);

                entity.ToTable("tb_devolucao", "biblioteca");

                entity.HasIndex(e => e.CpfBalconista)
                    .HasName("fk_Devolucao_Usuario_idx");

                entity.HasIndex(e => e.CpfUsuario)
                    .HasName("fk_Devolucao_Usuario1_idx");

                entity.Property(e => e.IdDevolucao)
                    .HasColumnName("idDevolucao")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CpfBalconista)
                    .IsRequired()
                    .HasColumnName("cpfBalconista")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CpfUsuario)
                    .IsRequired()
                    .HasColumnName("cpfUsuario")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Multa)
                    .HasColumnName("multa")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ValorPago)
                    .HasColumnName("valorPago")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.CpfBalconistaNavigation)
                    .WithMany(p => p.TbDevolucaoCpfBalconistaNavigation)
                    .HasForeignKey(d => d.CpfBalconista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_Usuario");

                entity.HasOne(d => d.CpfUsuarioNavigation)
                    .WithMany(p => p.TbDevolucaoCpfUsuarioNavigation)
                    .HasForeignKey(d => d.CpfUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_Usuario1");
            });

            modelBuilder.Entity<TbDevolucaoitemacervo>(entity =>
            {
                entity.HasKey(e => new { e.IdDevolucao, e.IdItemAcervo });

                entity.ToTable("tb_devolucaoitemacervo", "biblioteca");

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
                    .WithMany(p => p.TbDevolucaoitemacervo)
                    .HasForeignKey(d => d.IdDevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_has_ItemAcervo_Devolucao1");

                entity.HasOne(d => d.IdItemAcervoNavigation)
                    .WithMany(p => p.TbDevolucaoitemacervo)
                    .HasForeignKey(d => d.IdItemAcervo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Devolucao_has_ItemAcervo_ItemAcervo1");
            });

            modelBuilder.Entity<TbDoacao>(entity =>
            {
                entity.HasKey(e => e.IdDoacao);

                entity.ToTable("tb_doacao", "biblioteca");

                entity.Property(e => e.IdDoacao)
                    .HasColumnName("idDoacao")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");
            });

            modelBuilder.Entity<TbEditora>(entity =>
            {
                entity.HasKey(e => e.IdEditora);

                entity.ToTable("tb_editora", "biblioteca");

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

            modelBuilder.Entity<TbEmprestimo>(entity =>
            {
                entity.HasKey(e => e.IdEmprestimo);

                entity.ToTable("tb_emprestimo", "biblioteca");

                entity.HasIndex(e => e.CpfBalconista)
                    .HasName("fk_Emprestimo_Usuario1_idx");

                entity.HasIndex(e => e.CpfUsuario)
                    .HasName("fk_Emprestimo_Usuario2_idx");

                entity.Property(e => e.IdEmprestimo)
                    .HasColumnName("idEmprestimo")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CpfBalconista)
                    .IsRequired()
                    .HasColumnName("cpfBalconista")
                    .HasColumnType("char(11)");

                entity.Property(e => e.CpfUsuario)
                    .IsRequired()
                    .HasColumnName("cpfUsuario")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.HasOne(d => d.CpfBalconistaNavigation)
                    .WithMany(p => p.TbEmprestimoCpfBalconistaNavigation)
                    .HasForeignKey(d => d.CpfBalconista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Emprestimo_Usuario1");

                entity.HasOne(d => d.CpfUsuarioNavigation)
                    .WithMany(p => p.TbEmprestimoCpfUsuarioNavigation)
                    .HasForeignKey(d => d.CpfUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Emprestimo_Usuario2");
            });

            modelBuilder.Entity<TbEmprestimoitemacervo>(entity =>
            {
                entity.HasKey(e => new { e.IdItemAcervo, e.IdEmprestimo });

                entity.ToTable("tb_emprestimoitemacervo", "biblioteca");

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
                    .WithMany(p => p.TbEmprestimoitemacervo)
                    .HasForeignKey(d => d.IdEmprestimo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_has_Emprestimo_Emprestimo1");

                entity.HasOne(d => d.IdItemAcervoNavigation)
                    .WithMany(p => p.TbEmprestimoitemacervo)
                    .HasForeignKey(d => d.IdItemAcervo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_has_Emprestimo_ItemAcervo1");
            });

            modelBuilder.Entity<TbItemacervo>(entity =>
            {
                entity.HasKey(e => e.IdItemAcervo);

                entity.ToTable("tb_itemacervo", "biblioteca");

                entity.HasIndex(e => e.IdBiblioteca)
                    .HasName("fk_ItemAcervo_Biblioteca1_idx");

                entity.HasIndex(e => e.IdDoacao)
                    .HasName("fk_ItemAcervo_Doacao1_idx");

                entity.HasIndex(e => e.IdSituacaoLivro)
                    .HasName("fk_ItemAcervo_SituacaoLivro1_idx");

                entity.HasIndex(e => e.Isbn)
                    .HasName("fk_ItemAcervo_Livro1_idx");

                entity.Property(e => e.IdItemAcervo)
                    .HasColumnName("idItemAcervo")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBiblioteca)
                    .HasColumnName("idBiblioteca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdDoacao)
                    .HasColumnName("idDoacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSituacaoLivro)
                    .IsRequired()
                    .HasColumnName("idSituacaoLivro")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasColumnType("char(20)");

                entity.HasOne(d => d.IdBibliotecaNavigation)
                    .WithMany(p => p.TbItemacervo)
                    .HasForeignKey(d => d.IdBiblioteca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_Biblioteca1");

                entity.HasOne(d => d.IdDoacaoNavigation)
                    .WithMany(p => p.TbItemacervo)
                    .HasForeignKey(d => d.IdDoacao)
                    .HasConstraintName("fk_ItemAcervo_Doacao1");

                entity.HasOne(d => d.IdSituacaoLivroNavigation)
                    .WithMany(p => p.TbItemacervo)
                    .HasForeignKey(d => d.IdSituacaoLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_SituacaoLivro1");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.TbItemacervo)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemAcervo_Livro1");
            });

            modelBuilder.Entity<TbLivro>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.ToTable("tb_livro", "biblioteca");

                entity.HasIndex(e => e.IdEditora)
                    .HasName("fk_Livro_Editora1_idx");

                entity.HasIndex(e => e.Nome)
                    .HasName("idx_nome");

                entity.Property(e => e.Isbn)
                    .HasColumnName("isbn")
                    .HasColumnType("char(20)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataPublicacao)
                    .HasColumnName("dataPublicacao")
                    .HasColumnType("date");

                entity.Property(e => e.IdEditora)
                    .HasColumnName("idEditora")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resumo)
                    .HasColumnName("resumo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.TbLivro)
                    .HasForeignKey(d => d.IdEditora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Livro_Editora1");
            });

            modelBuilder.Entity<TbLivroautor>(entity =>
            {
                entity.HasKey(e => new { e.Isbn, e.IdAutor });

                entity.ToTable("tb_livroautor", "biblioteca");

                entity.HasIndex(e => e.IdAutor)
                    .HasName("fk_Livro_has_Autor_Autor1_idx");

                entity.HasIndex(e => e.Isbn)
                    .HasName("fk_Livro_has_Autor_Livro1_idx");

                entity.Property(e => e.Isbn)
                    .HasColumnName("isbn")
                    .HasColumnType("char(20)");

                entity.Property(e => e.IdAutor)
                    .HasColumnName("idAutor")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.TbLivroautor)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Livro_has_Autor_Autor1");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.TbLivroautor)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Livro_has_Autor_Livro1");
            });

            modelBuilder.Entity<TbSituacaolivro>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoLivro);

                entity.ToTable("tb_situacaolivro", "biblioteca");

                entity.Property(e => e.IdSituacaoLivro)
                    .HasColumnName("idSituacaoLivro")
                    .HasColumnType("char(1)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.Cpf);

                entity.ToTable("tb_usuario", "biblioteca");

                entity.HasIndex(e => e.IdCartaoBiblioteca)
                    .HasName("fk_Usuario_CartaoBiblioteca1_idx");

                entity.HasIndex(e => e.Nome)
                    .HasName("IDX_Nome");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasColumnType("char(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");

                entity.Property(e => e.Debito)
                    .HasColumnName("debito")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IdCartaoBiblioteca)
                    .HasColumnName("idCartaoBiblioteca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(20)
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

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("tipoUsuario")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("U");

                entity.HasOne(d => d.IdCartaoBibliotecaNavigation)
                    .WithMany(p => p.TbUsuario)
                    .HasForeignKey(d => d.IdCartaoBiblioteca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_CartaoBiblioteca1");
            });
        }
    }
}
