using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Chat.Service.Helpers
{
    public class MyMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public string strFilename { get; set; }

        public MyMultipartFormDataStreamProvider(string path)
            : base(path)
        {

        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                string fileNameGuid = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
                string renameImage = string.Format("{0}{1}", fileNameGuid, extension);

                //fileName = string.Format("{0}{1}", this.RootPath, renameImage);
                fileName = renameImage;
            }
            else
            {
                fileName = Guid.NewGuid().ToString() + ".jpg";
                //fileName = string.Format("{0}{1}", this.RootPath, fileName);
            }
            strFilename = fileName;
            return fileName.Replace("\"", string.Empty);
        }
    }
}