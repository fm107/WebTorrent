﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Torrent.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebTorrent.Controllers
{
    [Route("api/[controller]")]
    public class TorrentController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public TorrentController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            string fileName = null;

            Directory.CreateDirectory(uploads);

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    fileName = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            try
            {
                var torrent = new TorrentTransfer(fileName, uploads);
                torrent.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Accepted();
        }

        [HttpGet("[action]")]
        public string ShowDirectory()
        {
            string ret = null;
            foreach (string file in Directory.EnumerateFiles(Path.Combine(_environment.WebRootPath, "uploads"), "*",SearchOption.AllDirectories))
            {
                ret += string.Format("{0} Size: {1}",file, new FileInfo(file).Length) + Environment.NewLine;

            }
            return ret;
        }
    }
}
