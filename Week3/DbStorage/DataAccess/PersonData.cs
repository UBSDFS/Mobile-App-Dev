
using SQLite;
using Mobile_app_dev.Week3.DbStorage.Models;

namespace Mobile_app_dev.Week3.DbStorage.DataAccess
{
    public class PersonData
    {
        SQLiteAsyncConnection? database;

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(
                DatabaseConstants.DatabasePath,
                DatabaseConstants.Flags);

            await database.CreateTableAsync<Person>();
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            await Init();
            return await database!.Table<Person>().ToListAsync();
        }

        public async Task<Person?> GetPersonAsync(int id)
        {
            await Init();
            return await database!.Table<Person>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SavePersonAsync(Person person)
        {
            await Init();

            if (person.Id != 0)
            {
                // Update existing person
                return await database!.UpdateAsync(person);
            }
            else
            {
                // Insert new person
                return await database!.InsertAsync(person);
            }
        }

        public async Task<int> DeletePersonAsync(Person person)
        {
            await Init();
            return await database!.DeleteAsync(person);
        }
    }
}
