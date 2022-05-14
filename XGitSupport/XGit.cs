using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoYi;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace XGitSupport
{
    class XGit
    {
        #region Values
        private List<XGitVersion> _versionLst;
        private string _url;

        private log4net.ILog _log = log4net.LogManager.GetLogger("");
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

        private static string GetMatchGroups(string pattern, string text)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);
            if (!match.Success)
                return null;
            return match.Groups[1].ToString();
        }

        public List<XGitVersion> GetCommitIDLst(bool cover = true, string branch = null)
        {
            if (_versionLst != null && _versionLst.Count != 0 && !cover)
                return _versionLst;

            var cacheDir = GetCacheDir();
            if (!DownloadRepository(cacheDir, _url, null, cover, true, branch))
                return null;

            var ret = XConsole.RunCmdRet("cd {0}&&git log --pretty=format:\"<hash>%H</hash><tag_content>%d %s</tag_content>\"", cacheDir);
            var idx = ret.IndexOf("&exit");
            ret = ret.Substring(idx + "&exit".Length + 2);
            ret = XString.ReplaceAll(ret, "  ", " ");

            Console.WriteLine("URL = {0}", _url);
            //Debuger.WriteLog("", "XTest", "Ret = [{0}]", ret);

            if (ret.Contains("your current branch 'master' does not have any commits yet"))
            {
                return null;
            }

            var splitLst = ret.Split('\n').Where(x => x != "").ToList();

            List<XGitVersion> res = new List<XGitVersion>();
            foreach (var line in splitLst)
            {
                var lineTemp = line;
                var hash = GetMatchGroups("<hash>(.+)</hash>", lineTemp);
                var tag = GetMatchGroups("<tag_content>(.+)</tag_content>", lineTemp);

                XGitVersion temp = new XGitVersion();
                temp.hash_code = hash;
                temp.bert_version = "";

                var ver = GetMatchGroups("(BERTVu[_ ]6\\.[0-9]{1,2}\\.[0-9]{1,4})", tag);
                if (ver != null)
                    temp.bert_version = ver;

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
        private bool DownloadRepository(string cacheDir, string url, string commit_id = null, bool cover = false, bool noCheckOut = false, string branch = null)
        {
            if (cover)
                XDirectory.Delete(cacheDir);

            if (XDirectory.Exists(cacheDir))
                return false;

            var cmd = string.Format("git clone {0} {1}", url, cacheDir);
            if (noCheckOut)
                cmd += " -n";
            XConsole.RunCmdWait(cmd);
            if (branch != null)
            {
                var ret1 = XConsole.RunCmdRet("cd {0}&&git checkout \"{1}\"", cacheDir, branch);
                if (ret1.Contains("did not match any file(s) known to git"))
                    return false;
            }
            if (commit_id != null)
            {
                XConsole.RunCmdWait("cd {0}&&git reset --hard {1}", cacheDir, commit_id);
            }
            return true;
        }
        #endregion
        #endregion
    }
}
