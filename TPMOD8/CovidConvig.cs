using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

public class CovidConfig
{
	[JsonPropertyName("satuan_suhu")]
	public String config1 {  get; set; }

	[JsonPropertyName("batas_hari_demam")]
	public int config2 {  get; set; }

    [JsonPropertyName("pesan_ditolak")]
    public String config3 { get; set; }

    [JsonPropertyName("pesan_diterima")]
    public String config4 { get; set; }

    public const String path = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\C#\TPMOD8\TPMOD8\Covid_config.json";
    public String JSON = System.IO.File.ReadAllText(path);

    public void readJSON()
    {
        Console.WriteLine("Json: " + JSON);
    }

    public Boolean cekSyaratsuhu(double n)
    {
        Boolean cek = false;
        if (config1 == "celcius")
        {
            if(n>= 36.5 && n <= 37.5)
            {
                cek = true;
            }
        }else if ( config1 == "farenheit")
        {
            if (n >= 97.7 && n <= 99.5)
            {
                cek = true;
            }
        }
        return cek;
    }
    public Boolean cekSyaratSakit(int n)
    {
        Boolean cek = false;
        if (config2 > n)
        {
            cek = true;
        }
        return cek;
    }

    private void newconf()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };
        String newJson = JsonSerializer.Serialize(JSON, options);
    }
    public void ubahsatuan(String newsatuan)
    {
        Boolean valid = (newsatuan == "celcius" || newsatuan == "farenheit");

        if (!valid)
        {
            throw new ArgumentException("tidak valid");
        }
        config1 = newsatuan;
        newconf();
    }
}
