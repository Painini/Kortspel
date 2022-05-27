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
        //Work on SQlite next
        string _db_name;
        string _cs;
        SQLiteConnection _connection;
        SQLiteCommand _cmd;
        List<string> player = new List<string>();
        List<string> chips = new List<string>();

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

            //string stm = "SELECT SQLITE_VERSION();";
            _cmd = new SQLiteCommand("", _connection);

            Close();
        }


        public void CreateTable()
        {
            Open();
            _cmd.CommandText = "DROP TABLE IF EXISTS blackjack;";
            _cmd.ExecuteNonQuery();
            _cmd.CommandText = "CREATE TABLE IF NOT EXISTS blackjack(id INTEGER PRIMARY KEY AUTOINCREMENT, player TEXT, chips INTEGER);";
            _cmd.ExecuteNonQuery();


            Close();
        }

        public void WriteFromTableInfo()
        {
            Open();

            _cmd.CommandText = "SELECT player, chips FROM blackjack;";

            using SQLiteDataReader rdr = _cmd.ExecuteReader();

            while (rdr.Read())
            {
                player.Add($"{rdr.GetString(0)}");
                chips.Add($"{rdr.GetInt32(1)}");
            }

            Close();
        }

        public List<string> GetPlayerName()
        {
            return player;
        }

        public List<string> GetChipAmount()
        {
            return chips;
        }

        public void AddPlayerToTable(string player)
        {
            Open();
            _cmd.CommandText = "INSERT INTO blackjack(player, chips) VALUES(@player, "+0+");";

            SQLiteParameter playerParam = new SQLiteParameter("@player", System.Data.DbType.String);

            playerParam.Value = player;

            _cmd.Parameters.Add(playerParam);

            _cmd.Prepare();
            _cmd.ExecuteNonQuery();
            Close();
        }

        public void UpdatePlayerChipAmount(string chips, int id)
        {
            Open();
            _cmd.CommandText = "UPDATE blackjack SET chips = @chips WHERE id = @id;";

            SQLiteParameter chipsParam = new SQLiteParameter("@chips", System.Data.DbType.String);
            SQLiteParameter idParam = new SQLiteParameter("@id", System.Data.DbType.String);

            chipsParam.Value = chips;
            idParam.Value = id;

            _cmd.Parameters.Add(chipsParam);
            _cmd.Parameters.Add(idParam);

            _cmd.Prepare();
            _cmd.ExecuteNonQuery();



            Close();
        }

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

