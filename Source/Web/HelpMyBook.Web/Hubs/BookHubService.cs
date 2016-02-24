namespace HelpMyBook.Web.Hubs
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class BookHubService
    {
        public IEnumerable<AmountHolder> GetData(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [Amount] FROM [HelpMyBook].[dbo].[Donations] WHERE BookId=" + id + " AND IsDeleted = 'False'", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency.Start(connection.ConnectionString);

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(this.Dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Cast<IDataRecord>()
                            .Select(x => new AmountHolder { Amount = x.GetDecimal(0) }).ToList();
                    }
                }
            }
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            BookHub.Show();
        }
    }
}
