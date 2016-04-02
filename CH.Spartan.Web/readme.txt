切换使用mysql数据库

1.删除所有的 迁移文件 (CH.Spartan.EntityFramework/Migrations) 默认的迁移文件是mssql的
2.nuget 中搜索MySql.Data.Entity 并安装到CH.Spartan.EntityFramework和CH.Spartan.Web 然后配置Web.config
  
 <connectionStrings>
    <add name="Default" connectionString="data source=localhost;user id=root;password=pwd;database=ucall-abp;pooling=true;max pool size=50;min pool size=5;" providerName="MySql.Data.MySqlClient" />
  </connectionStrings>
  <entityFramework codeConfigurationType="MySql.Data.Entity.MySqlEFConfiguration, MySql.Data.Entity.EF6">
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
    <providers>
      <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.9.7.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d">
      </provider>
    </providers>
  </entityFramework>
  <system.data>
    <DbProviderFactories>
      <remove invariant="MySql.Data.MySqlClient" />
      <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.9.7.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
    </DbProviderFactories>
  </system.data>

3.生成迁移文件 先配置Configuration文件 使用mysql生成器 然后执行 Add-Migration init 和 Update-Database
    internal sealed class Configuration : DbMigrationsConfiguration<Spartan.EntityFramework.SpartanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Spartan";
            //在这里添加生成器
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Spartan.EntityFramework.SpartanDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }

4.设置Hangfire(后台任务管理) 为Memory 在nuget 中搜索Hangfire.MemoryStorage 并安装 并在Web项目中配置
 在文件 SpartanWebModule 中配置
 Configuration.BackgroundJobs.UseHangfire(configuration =>
 {
                configuration.GlobalConfiguration.UseMemoryStorage();
                //configuration.GlobalConfiguration.UseSqlServerStorage("Default");
});

