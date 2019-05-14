using System.IO;
using System.Collections.Generic;
using System.Linq;
using HelloWorldASPCore.ResponseModels;
using HelloWorldASPCore.Services;

namespace HelloWorldASPCore.RequestModels
{
    public class PathRequest
    {
        public string pathString;
        public bool showFolder;
        public PathRequest(string pS, bool sF) { pathString = pS; showFolder = sF; }
        public List<PathResponse> ScanFolder() { return FolderServices.ScanFolderService(pathString, showFolder); }            
    }
}
