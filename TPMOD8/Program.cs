// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

class Program()
{
    static void Main(string[] args)
    {
        double suhu;
        int hari_demam;

        CovidConfig covidconf = new CovidConfig();

        var Covidata = JsonSerializer.Deserialize<CovidConfig>(covidconf.JSON);
        
        //sebelum ubah satuan
        Console.Write("Berapa Suhu Badan Anda Saat" +
            " ini? Dalam nilai " + Covidata.config1 + " ");
        String input = Console.ReadLine();
        double.TryParse(input, out suhu);
        Boolean S1 = Covidata.cekSyaratsuhu(suhu);
        Console.Write("Berapa hari yang lalu (perkiraan)" +
            " anda terakhir mengalami gejala demam " );
        input = Console.ReadLine();
        int.TryParse(input , out hari_demam);
        Boolean S2 = Covidata.cekSyaratSakit(hari_demam);
        Console.WriteLine(S1);
        Console.WriteLine(S2);
        if (S1 == true && S2 == true)
        {
            Console.WriteLine(Covidata.config4);
        }
        else
        {
            Console.WriteLine(Covidata.config3);
        }
        // setelah ubah satuan
        Covidata.ubahsatuan("farenheit");
        Console.Write("Berapa Suhu Badan Anda Saat" +
            " ini? Dalam nilai " + Covidata.config1 + " ");
        input = Console.ReadLine();
        double.TryParse(input, out suhu);
        S1 = Covidata.cekSyaratsuhu(suhu);
        Console.Write("Berapa hari yang lalu (perkiraan)" +
            " anda terakhir mengalami gejala demam ");
        input = Console.ReadLine();
        int.TryParse(input, out hari_demam);
        S2 = Covidata.cekSyaratSakit(hari_demam);
        Console.WriteLine(S1);
        Console.WriteLine(S2);
        if (S1 == true && S2 == true)
        {
            Console.WriteLine(Covidata.config4);
        }
        else
        {
            Console.WriteLine(Covidata.config3);
        }
    }
}
