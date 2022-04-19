using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoYi;
using System.Windows.Forms;

namespace XGitSupport
{
    class XGit
    {
        #region Values
        private List<XGitVersion> _versionLst;
        private string _url;
        #endregion

        #region Function
        #region Public
        public void SetUrl(string url)
        {
            _url = url;
            _versionLst = GetCommitIDLst(false);
        }
        public string GetUrl()
        {
            return _url;
        }
        public List<string> GetFileLst(string commit_id)
        {
            List<string> exts = new List<string>()
            {
                ".exe",
                ".cs",
                ".c",
                ".sln",
                ".config",
                ".csproj",
                ".user",
                ".licx",
                ".xml",
                ".pdb",
            };

            var cacheDir = GetCacheDir(commit_id);
            DownloadRepository(cacheDir, _url, commit_id);

            var dir = XConsole.ThisExeDir() + cacheDir.Substring(2);
            dir = XPath.Format(dir);

            var fileLst = XDirectory.GetAllFiles(dir, new List<string>() { ".git" })
                .Select(x => x.Substring(dir.Length))
                .Where(x => !exts.Contains(XFile.Extension(x)))
                .ToList();

            return fileLst;
        }
        public string GetName()
        {
            return _url.Substring(_url.LastIndexOf('/') + 1);
        }
        public List<XGitVersion> GetCommitIDLst(bool cover = true)
        {
            if (_versionLst != null && _versionLst.Count != 0 && !cover)
                return _versionLst;

            var cacheDir = GetCacheDir();
            DownloadRepository(cacheDir, _url, null, cover, true);

            var ret = XConsole.RunCmdRet("cd {0}&&git log --pretty=oneline", cacheDir);

            var idx = ret.IndexOf("&exit");
            ret = ret.Substring(idx + "&exit".Length + 2);
            ret = XString.ReplaceAll(ret, "  ", " ");

            var splitLst = ret.Split('\n').Where(x => x != "").ToList();

            List<XGitVersion> res = new List<XGitVersion>();
            foreach (var line in splitLst)
            {
                var lineTemp = line;
                XGitVersion temp = new XGitVersion();

                idx = lineTemp.IndexOf(' ');
                temp.hash_code = lineTemp.Substring(0, idx);
                lineTemp = lineTemp.Substring(idx + 1);

                lineTemp = lineTemp.ToLower();
                idx = lineTemp.IndexOf("bertvu");
                if (idx != -1)
                {
                    lineTemp = lineTemp.Substring(idx + 6);
                    while (lineTemp.StartsWith(" "))
                        lineTemp = lineTemp.Substring(1);


                    var min = -1;
                    bool flag;
                    for (int i = 0; i < lineTemp.Length; i++)
                    {
                        flag = false;
                        if (lineTemp[i] >= '0' && lineTemp[i] <= '9')
                            flag = true;
                        if (lineTemp[i] == '+' || lineTemp[i] == '.')
                            flag = true;

                        if (!flag)
                            break;

                        min = i;
                    }


                    if (min != -1)
                        temp.bert_version = lineTemp.Substring(0, min + 1);
                    else
                        temp.bert_version = "";
                }


                res.Add(temp);
            }

            _versionLst = res;
            return res;
        }
        /// <summary>
        /// 获取缓存地址
        /// </summary>
        /// <returns></returns>
        public string GetCacheDir(string id = null)
        {
            return "./Cache/" + GetName() + (id != null ? ("." + id) : "");
        }


        public static XGit FromDir(string dir)
        {
            List<string> dirPathLst = new List<string>()
            {
                dir
            };

            while (dirPathLst.Count != 0)
            {
                dir = dirPathLst[0];
                dirPathLst.Remove(dir);

                var subDirPathLst = XDirectory.GetDirs(dir);
                var gitDir = subDirPathLst.Find(x => XDirectory.Direcotry(x) == ".git");
                if (gitDir != null)
                {
                    var path = string.Format("{0}/config", gitDir);
                    var lineLst = XFile.ReadLines(path);
                    var urlLine = lineLst.Find(x => x.ToLower().StartsWith("\turl = "));
                    var url = urlLine.Substring("\turl = ".Length);

                    XGit res = new XGit();
                    res._url = url;

                    return res;
                }
                else
                {
                    dirPathLst.AddRange(subDirPathLst);
                }
            }
            return null;
        }
        #endregion

        #region Private
        /// <summary>
        /// 下载仓库
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <returns></returns>
        private void DownloadRepository(string cacheDir, string url, string commit_id = null, bool cover = false, bool noCheckOut = false)
        {
            if (cover)
                XDirectory.Delete(cacheDir);

            if (XDirectory.Exists(cacheDir))
                return;

            var cmd = string.Format("git clone {0} {1}", url, cacheDir);
            if (noCheckOut)
                cmd += " -n";
            XConsole.RunCmdWait(cmd);
            if (commit_id != null)
            {
                XConsole.RunCmdWait("cd {0}&&git reset --hard {1}", cacheDir, commit_id);
            }
        }
        #endregion
        #endregion
    }
}
