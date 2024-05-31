#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using Microsoft.EntityFrameworkCore;
using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using System;

/// <summary>
/// Represents the database context for the local database.
/// </summary>
public partial class LocalDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocalDbContext"/> class.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public LocalDbContext(DbContextOptions<LocalDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet of users.
    /// </summary>
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of roles.
    /// </summary>
    public virtual DbSet<Role> Roles { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of farmers.
    /// </summary>
    public virtual DbSet<Farmer> Farmers { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of posts.
    /// </summary>
    public DbSet<Post> Posts { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of products.
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of chat messages.
    /// </summary>
    public DbSet<ChatMessage> Collaboration { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of resources.
    /// </summary>
    public DbSet<Resource> Resources { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of projects.
    /// </summary>
    public DbSet<Project> Projects { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of comments.
    /// </summary>
    public DbSet<Comment> Comments { get; set; }

    /// <summary>
    /// Configures the relationships between entities in the database.
    /// </summary>
    /// <param name="modelBuilder">The model builder instance used to construct the model for the context being created.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define primary keys for each entity
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Call partial method to further configure the model
        OnModelCreatingPartial(modelBuilder);
    }

    // Partial method that can be implemented in another file
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
