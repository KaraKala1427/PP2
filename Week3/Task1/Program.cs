using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    enum FSIMode
    {
        DirectoryInfo = 1,
        File = 2
    }
    class Layer                                  //creating the class
    {
        int selectedItemIndex;
        public FileSystemInfo[] Items
        {
            get;
            set;
        }

        public int SelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            set
            {
                if (value >= Items.Length)
                {
                    selectedItemIndex = 0;
                }
                else if (value < 0)                        //controller of pressedkey
                {
                    selectedItemIndex = Items.Length - 1;
                }
                else
                {
                    selectedItemIndex = value;
                }
            }
        }


        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Items.Length; ++i)
            {
                if (i == selectedItemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {                                                        //function that control the color of files and directories
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (Items[i].GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                Console.WriteLine((i + 1) + ". " + Items[i].Name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\test");   //implying the path
            Layer l = new Layer
            {
                Items = dir.GetFileSystemInfos(),            //making exemplar whose argument is Items and SelectedItemIndex
                SelectedItemIndex = 0
            };

            FSIMode curMode = FSIMode.DirectoryInfo;        //making variable curMode whose тип данные FSIMode
            Stack<Layer> history = new Stack<Layer>();        //creating the stack

            history.Push(l);

            bool quit = false;
            while (!quit)
            {
                if (curMode == FSIMode.DirectoryInfo)
                {
                    history.Peek().Draw();                   //calling the function 
                }
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    history.Peek().SelectedItemIndex--;
                }                                                              //results of pressedkeys
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    history.Peek().SelectedItemIndex++;
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {

                    int index = history.Peek().SelectedItemIndex;
                    FileSystemInfo fsi = history.Peek().Items[index];
                    if (fsi.GetType() == typeof(DirectoryInfo))
                    {
                        curMode = FSIMode.DirectoryInfo;
                        // DirectoryInfo d = (DirectoryInfo)fsi;
                        DirectoryInfo d = fsi as DirectoryInfo;                      //if it is directory, showing content
                        history.Push(new Layer
                        {
                            Items = d.GetFileSystemInfos(),
                            SelectedItemIndex = 0
                        });
                    }
                    else
                    {
                        curMode = FSIMode.File;
                        using (FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;                 //if it is file, showing content
                                Console.Clear();
                                Console.WriteLine(sr.ReadToEnd());
                            }
                        }
                    }


                }
                else if (pressedKey.Key == ConsoleKey.Delete)
                {
                    int x2 = history.Peek().SelectedItemIndex;
                    FileSystemInfo fileSystemInfo2 = history.Peek().Items[x2];
                    if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                        Directory.Delete(fileSystemInfo2.FullName, true);
                        history.Peek().Items = d.Parent.GetFileSystemInfos();
                    }
                    else
                    {
                        FileInfo f = fileSystemInfo2 as FileInfo;
                        File.Delete(fileSystemInfo2.FullName);
                        history.Peek().Items = f.Directory.GetFileSystemInfos();
                    }
                    history.Peek().SelectedItemIndex--;

                }
                else if (pressedKey.Key == ConsoleKey.F6)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    string name = Console.ReadLine();
                    int x3 = history.Peek().SelectedItemIndex;
                    FileSystemInfo fileSystemInfo3 = history.Peek().Items[x3];
                    if (fileSystemInfo3.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo;
                        Directory.Move(fileSystemInfo3.FullName, directoryInfo.Parent + "/" + name);
                        history.Peek().Items = directoryInfo.Parent.GetFileSystemInfos();
                    }
                    else
                    {
                        FileInfo fileInfo = fileSystemInfo3 as FileInfo;
                        File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name);
                        history.Peek().Items = fileInfo.Directory.GetFileSystemInfos();
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Backspace)
                {
                    if (curMode == FSIMode.DirectoryInfo)
                    {
                        history.Pop();
                    }
                    else
                    {
                        curMode = FSIMode.DirectoryInfo;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Escape)
                {
                    quit = true;
                }
            }
        }
    }
}

//                else if (pressedKey.Key == ConsoleKey.Delete)
//                {
//                    int x2 = history.Peek().SelectedItemIndex;
//FileSystemInfo fileSystemInfo2 = history.Peek().Items[x2];
//                    if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
//                    {
//                        DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
//Directory.Delete(fileSystemInfo2.FullName, true);
//                        history.Peek().Items = d.Parent.GetFileSystemInfos();
//                    }
//                    else
//                    {
//                        FileInfo f = fileSystemInfo2 as FileInfo;
//File.Delete(fileSystemInfo2.FullName);
//                        history.Peek().Items = f.Directory.GetFileSystemInfos();
//                    }
//                    history.Peek().SelectedItemIndex--;

//                }
