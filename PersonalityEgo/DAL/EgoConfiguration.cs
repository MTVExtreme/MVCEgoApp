using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace PersonalityEgo.DAL
{
    public class EgoConfiguration : DbConfiguration
    {
        public EgoConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
        
    }
}