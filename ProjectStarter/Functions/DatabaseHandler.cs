using Npgsql;
using ProjectStarter.Entities.Address;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class DatabaseHandler
{
    private string connectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=produck2024;Database=produck_db";

    public void InsertCountries(List<Countries> countries)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            foreach (var country in countries)
            {
                string query = "INSERT INTO countries (country_code, country_name, country_dial_code) VALUES (@code, @name, @dialCode)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    // Explicitly setting parameter types using NpgsqlDbType
                    cmd.Parameters.Add("@code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = country.code;
                    cmd.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = country.name;
                    cmd.Parameters.Add("@dialCode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = country.dial_code;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void InsertCities(List<Cities> cities)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            foreach (var city in cities)
            {
                string query = "INSERT INTO Cities (city_id, city_name, country_id) VALUES (@id, @name, 215)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", city.sehir_id);
                    cmd.Parameters.AddWithValue("@name", city.sehir_adi);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void InsertDistricts(List<Districts> districts)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            foreach (var district in districts)
            {
                string query = "INSERT INTO Districts (district_id, district_name, city_id,country_id) VALUES (@id, @name, @city_id,215)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", district.ilce_id);
                    cmd.Parameters.AddWithValue("@name", district.ilce_adi);
                    cmd.Parameters.AddWithValue("@city_id", district.sehir_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void InsertNeighborhoods(List<Neighborhoods> neighborhoods)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            foreach (var neighborhood in neighborhoods)
            {
                string checkQuery = "SELECT COUNT(1) FROM Neighborhoods WHERE neighborhood_id = @id";
                using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", neighborhood.mahalle_id);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count == 0) 
                    {
                        string insertQuery = "INSERT INTO Neighborhoods (neighborhood_id, neighborhood_name, district_id, city_id,country_id) VALUES (@id, @name, @district_id, @city_id,215)";
                        using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@id", neighborhood.mahalle_id);
                            insertCmd.Parameters.AddWithValue("@name", neighborhood.mahalle_adi);
                            insertCmd.Parameters.AddWithValue("@district_id", neighborhood.ilce_id);
                            insertCmd.Parameters.AddWithValue("@city_id", neighborhood.sehir_id);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Record with ID {neighborhood.mahalle_id} already exists. Skipping insert.");
                    }
                }
            }
        }
    }

}