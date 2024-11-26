using SQLite;
using AgainMaui.Classses;

namespace AgainMaui.Classses
{
    public class LocalDBService
    {
        public const string DB_NAME = "user_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;
        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));
            _connection.CreateTableAsync<Users>();
            _connection.CreateTableAsync<Tasks>();
        }
        public async Task<List<Tasks>> GetTasks()
        {
            return await _connection.Table<Tasks>().ToListAsync();

        }
        public async Task<List<Users>> GetUsers()
        {
            return await _connection.Table<Users>().ToListAsync();
        }
        public async Task<Tasks> GetTaskByName(string name)
        {
            return await _connection.Table<Tasks>().Where(x => x.Title == name).FirstOrDefaultAsync();
        }
        public async Task<Users> GetByName(string name)
        {
            return await _connection.Table<Users>().Where(x=>x.UserName == name).FirstOrDefaultAsync();
        }
        public async Task Create(Users u)
        {
           await _connection.InsertAsync(u);
        }
        public async Task CreateTask(Tasks u)
        {
            await _connection.InsertAsync(u);
        }
        public async Task Update(Users u)
        {
            await _connection.UpdateAsync(u);
        }
        public async Task UpdateTask(Tasks u)
        {
            await _connection.UpdateAsync(u);
        }
        public async Task Delete(Users u)
        {
            await _connection.DeleteAsync(u);

        }
        public async Task DeleteTask(Tasks u)
        {
            await _connection.DeleteAsync(u);
            //TasksList.tasksList = await GetTasks();
        }
    }

}
