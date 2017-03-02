using System;
using Torrent.Client;
using Torrent.Client.Events;

namespace Torrent.ConsoleTest
{
    internal class Program
    {
        private const string Path = @"D:\Temp\Torrents\tor.torrent";
        private TorrentTransfer _torrent;

        private static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            try
            {
                _torrent = new TorrentTransfer(Path, @"D:\Temp\Torrents");
                _torrent.StateChanged += Torrent_StateChanged;
                _torrent.ReportStats += _torrent_ReportStats;
                _torrent.Start();
                Console.ReadKey();
            }
            finally
            {
                Console.Read();
            }
        }

        private void _torrent_ReportStats(object sender, StatsEventArgs e)
        {
            Console.WriteLine(e.BytesCompleted);
            Console.WriteLine(e.TotalPeers);
            Console.WriteLine(e.ChokedBy);
        }

        private void Torrent_StateChanged(object sender, EventArgs<TorrentState> e)
        {
            Console.WriteLine(e.Value);
        }

        private void torrent_GotPeers(object sender, EventArgs e)
        {
            Console.WriteLine(_torrent.Data.InfoHash);
            Console.WriteLine(_torrent.Data.Name);
        }
    }
}