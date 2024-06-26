﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Cartools.Models

{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IFormFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; }
        public string PathImagensProduto { get; set; }
    }
}
