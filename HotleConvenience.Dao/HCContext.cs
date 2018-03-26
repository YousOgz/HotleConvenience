using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace HotleConvenience.Dao
{
    public class HCContext : DbContext
    {
        public HCContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configTypes = this.GetConfigTypes();
            foreach (var configType in configTypes)
            {
                dynamic instance = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(instance);
            }
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 获取设置项
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> GetConfigTypes()
        {
            var @interface = typeof(IEntityTypeConfiguration<>);
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(@interface));
            return types.ToList();
        }
    }
}
