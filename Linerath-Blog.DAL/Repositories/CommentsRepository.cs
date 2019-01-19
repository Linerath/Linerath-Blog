using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Dapper;

namespace Linerath_Blog.DAL.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private String connectionString;

        public CommentsRepository(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Comment> GetComments(int articleId)
        {
            String sql = "SELECT * FROM Comments WHERE Article_Id=@articleId";

            using (var connection = new SqlConnection(connectionString))
            {
                List<Comment> result = connection.Query<Comment>(sql, new { articleId }).ToList();

                return result;
            }
        }
    }
}
