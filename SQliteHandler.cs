using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Kortspel
{
    class SQliteHandler
    {
        //Note that for the SQliteHandler class to work properly, you need to completely reset and empty the "kortspel.db" databse before play.
        string _db_name;
        string _cs;
        SQLiteConnection _connection;
        SQLiteCommand _cmd;
        List<string> player = new List<string>();
        List<string> playerChips = new List<string>();

        private void Open()
        {
            _connection.Open();
        }

        private void Close()
        {
            _connection.Close();
        }

        public SQliteHandler(string databaseName)
        {
            _db_name = databaseName;
            _cs = "URI=file:" + databaseName;
            _connection = new SQLiteConnection(_cs);
            Open();
            _cmd = new SQLiteCommand("", _connection);

            Close();
        }

        //Creates table in database if one is not present.
        public void CreateTable()
        {
            Open();
            _cmd.CommandText = "CREATE TABLE IF NOT EXISTS blackjack(id INTEGER PRIMARY KEY AUTOINCREMENT, player TEXT, chips INTEGER);";
            _cmd.ExecuteNonQuery();


            Close();
        }

        //Currently unused
        public void WriteFromTableInfo()
        {
            Open();

            _cmd.CommandText = "SELECT player, chips FROM blackjack;";

            using SQLiteDataReader rdr = _cmd.ExecuteReader();

            while (rdr.Read())
            {
                player.Add($"{rdr.GetString(0)}");
                playerChips.Add($"{rdr.GetInt32(1)}");
            }

            Close();
        }

        public List<string> GetPlayerName()
        {
            return player;
        }

        public List<string> GetChipAmount()
        {
            return playerChips;
        }

        //Adds player to table if one does not already exist.
        public void AddPlayerToTable(Player player)
        {
            Open();
            _cmd.CommandText = "INSERT INTO blackjack(player, chips) SELECT@player, @chips WHERE NOT EXISTS (SELECT * FROM blackjack);";

            SQLiteParameter playerParam = new SQLiteParameter("@player", System.Data.DbType.String);
            SQLiteParameter chipsParam = new SQLiteParameter("@chips", System.Data.DbType.Int32);

            playerParam.Value = player.GetName();
            chipsParam.Value = player.GetChipAmount();

            _cmd.Parameters.Add(playerParam);
            _cmd.Parameters.Add(chipsParam);

            _cmd.Prepare();
            _cmd.ExecuteNonQuery();
            Close();
        }

        //Returns the database's chip amount.
        public int ReturnPlayerChipAmount()
        {
            try 
            {
                Open();
                int chips = 0;
                _cmd.CommandText = "SELECT chips FROM blackjack;";
                using SQLiteDataReader rdr = _cmd.ExecuteReader();
                while (rdr.Read())
                {
                    chips = rdr.GetInt32(0);
                }
                Close();
                return chips;
            }
            catch
            {
                Close();
                return 1500;
            }
            

            
        }

        //Updates database's chips row.
        public void UpdateDatabaseChipAmount(string chips, int id)
        {
            Open();
            _cmd.CommandText = "UPDATE blackjack SET chips = @chips WHERE id = @id;";

            SQLiteParameter chipsParam = new SQLiteParameter("@chips", System.Data.DbType.String);
            SQLiteParameter idParam = new SQLiteParameter("@id", System.Data.DbType.Int32);

            chipsParam.Value = chips;
            idParam.Value = id;

            _cmd.Parameters.Add(chipsParam);
            _cmd.Parameters.Add(idParam);

            _cmd.Prepare();
            _cmd.ExecuteNonQuery();
            Close();
        }

        //Unused for now
        public void DeletePlayerFromTable(int id)

        {
            Open();
            _cmd.CommandText = "DELETE FROM blackjack WHERE id = @id;";

            SQLiteParameter idParam = new SQLiteParameter("@id", System.Data.DbType.String);

            idParam.Value = id;

            _cmd.Parameters.Add(idParam);

            _cmd.Prepare();
            _cmd.ExecuteNonQuery();

            Close();
        }
    }
}

