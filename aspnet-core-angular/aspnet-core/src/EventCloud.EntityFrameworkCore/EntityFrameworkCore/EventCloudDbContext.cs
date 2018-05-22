﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EventCloud.Authorization.Roles;
using EventCloud.Authorization.Users;
using EventCloud.Blog.Notes;
using EventCloud.Events;
using EventCloud.MultiTenancy;

namespace EventCloud.EntityFrameworkCore
{
    public class EventCloudDbContext : AbpZeroDbContext<Tenant, Role, User, EventCloudDbContext>
    {
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

        public EventCloudDbContext(DbContextOptions<EventCloudDbContext> options)
            : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteBook> NoteBooks { get; set; }
        public DbSet<NoteToNoteBook> NoteToNoteBook { get; set; }
    }
}
