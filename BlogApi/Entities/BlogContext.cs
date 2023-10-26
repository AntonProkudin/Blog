using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogApi.Entities;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    { }

    public virtual DbSet<UserTbl> UsersTbl { get; set; } = null!;
    public virtual DbSet<RecordTbl> RecordTbl { get; set; } = null!;
    public virtual DbSet<CommentTbl> CommentTbl { get; set; } = null!;
}

