using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Unity2018ReferenceFixer
{
    class Program
    {
        private static List<string> filesToFix = new List<string>();

        private static Dictionary<string, string> fixMap = new Dictionary<string, string>
        {
            {"  m_Script: {fileID: 11500000, guid: 67db9e8f0e2ae9c40bc1e2b64352a6b4, type: 3}",
                "  m_Script: {fileID: -113659843, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 31a19414c41e5ae4aae2af33fee712f6, type: 3}",
                "  m_Script: {fileID: -1200242548, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 86710e43de46f6f4bac7c8e50813a599, type: 3}",
                "  m_Script: {fileID: -1254083943, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 306cc8c2b49d7114eaa3623786fc2126, type: 3}",
                "  m_Script: {fileID: 1679637790, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 5f7201a12d95ffc409449d95f23cf332, type: 3}",
                "  m_Script: {fileID: 708705254, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 0d0b652f32a2cc243917e4028fa0f046, type: 3}",
                "  m_Script: {fileID: 853051423, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: d199490a83bb2b844b9695cbf13b01ef, type: 3}",
                "  m_Script: {fileID: 575553740, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: dc42784cf147c0c48a680349fa168899, type: 3}",
                "  m_Script: {fileID: 1301386320, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 1344c3c82d62a2a41a3576d8abb8e3ea, type: 3}",
                "  m_Script: {fileID: -98529514, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 3312d7739989d2b4e91e6319e9a96d76, type: 3}",
                "  m_Script: {fileID: -146154839, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 1aa08ab6e0800fa44ae55d278d1423e3, type: 3}",
                "  m_Script: {fileID: 1367256648, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 8a8695521f0d02e499659fee002a26c2, type: 3}",
                "  m_Script: {fileID: -2095666955, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 2fafe2cfe61f6974895a912c3755e8f1, type: 3}",
                "  m_Script: {fileID: -1184210157, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 2a4db7a114972834c8e4117be1d82ba3, type: 3}",
                "  m_Script: {fileID: -2061169968, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 7a98125502f715b4b83cfb77b434e436, type: 3}",
                "  m_Script: {fileID: -234403039, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 0cd44c1031e13a943bb63640046fad76, type: 3}",
                "  m_Script: {fileID: 1980459831, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 9085046f02f69544eb97fd06b6048fe2, type: 3}",
                "  m_Script: {fileID: 2109663825, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: fe87c0e1cc204ed48ad3b37840f39efc, type: 3}",
                "  m_Script: {fileID: -765806418, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: e19747de3f5aca642ab2be37e372fb86, type: 3}",
                "  m_Script: {fileID: -900027084, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: d0b148fe25e99eb48b9724523833bab1, type: 3}",
                "  m_Script: {fileID: -1862395651, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 4e29b1a8efbd4b44bb3f3716e73f07ff, type: 3}",
                "  m_Script: {fileID: 1392445389, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 30649d3a9faa99c48a7b1166b86bf2a0, type: 3}",
                "  m_Script: {fileID: -405508275, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 59f8146938fff824cb5fd77236b75775, type: 3}",
                "  m_Script: {fileID: 1297475563, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 76c392e42b5098c458856cdf6ecaaaa1, type: 3}",
                "  m_Script: {fileID: -619905303, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: cfabb0440166ab443bba8876756fdfa9, type: 3}",
                "  m_Script: {fileID: 1573420865, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
            {"  m_Script: {fileID: 11500000, guid: 4f231c4fb786f3946a6b90b886c48677, type: 3}",
                "  m_Script: {fileID: 1077351063, guid: f70555f144d8491a825f0804e09c671c, type: 3}"},
        };
        
        static void Main(string[] args)
        {
            DirSearch(Directory.GetCurrentDirectory());

            foreach (var f in filesToFix)
            {
                Console.WriteLine(f);
                ReadAndFixFile(f);
            }

            Console.ReadKey();
        }

        static void ReadAndFixFile(string path)
        {
            var arr = File.ReadAllLines(path);
            var needSave = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!arr[i].Contains("fileID: 11500000"))
                    continue;

                foreach (var pair in fixMap.Where(pair => pair.Key == arr[i]))
                {
                    arr[i] = pair.Value;
                    Console.WriteLine($"Fixed: {pair.Key} ---> {pair.Value}");
                    needSave = true;
                    break;
                }
            }

            if (needSave)
            {
                File.WriteAllLines(path, arr);
                Console.WriteLine();
            }
        }

        static void DirSearch(string sDir)
        {
            try
            {
                foreach (var d in Directory.GetDirectories(sDir))
                {
                    foreach (var f in Directory.GetFiles(d))
                        if (f.Contains(".unity") || f.Contains(".prefab"))
                            filesToFix.Add(f);
                    
                    DirSearch(d);
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}